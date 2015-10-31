using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowPacketParser.Misc;

namespace WowPacketParser.SQL
{
    public class DictionaryComparer : IEqualityComparer<Dictionary<string, object>>
    {
        public bool Equals(Dictionary<string, object> x, Dictionary<string, object> y)
        {
            return x.DictionaryEqual(y);
        }

        public int GetHashCode(Dictionary<string, object> obj)
        {
            // bad impl 2.0
            return obj.Aggregate(0, (current, o) => current ^ o.GetHashCode());
        }
    }

    public class SQLWhere<T> where T : IDataModel
    {
        private readonly RowList<T> _row;

        private readonly bool _onlyPrimaryKeys;

        public SQLWhere(RowList<T> rowList, bool onlyPrimaryKeys = false)
        {
            _row = rowList;
            _onlyPrimaryKeys = onlyPrimaryKeys;
        }

        public bool HasConditions => _row != null && _row.Count != 0;

        public string Build()
        {
            if (_row == null || _row.Count == 0)
                return string.Empty;

            StringBuilder whereClause = new StringBuilder();

            if (_onlyPrimaryKeys && _row.GetPrimaryKeyCount() == 1)
            {
                var field = SQLUtil.GetFields<T>().Single(f => f.Item2 == _row.GetFirstPrimaryKey());

                whereClause.Append(field.Item1);
                if (_row.Count == 1)
                {
                    whereClause.Append(" = ");
                    whereClause.Append(field.Item2.GetValue(_row.First()));
                }
                else
                {
                    whereClause.Append(" IN (");

                    foreach (Row<T> c in _row)
                    {
                        object value = field.Item2.GetValue(c.Data);
                        whereClause.Append(SQLUtil.ToSQLValue(value));

                        if (!string.IsNullOrEmpty(c.Comment))
                            whereClause.Append(" /*" + c.Comment + "*/");

                        whereClause.Append(SQLUtil.CommaSeparator);
                    }
                    whereClause.Remove(whereClause.Length - SQLUtil.CommaSeparator.Length, SQLUtil.CommaSeparator.Length); // remove last ", "

                    whereClause.Append(")");
                }
            }
            else
            {
                foreach (Row<T> c in _row)
                {
                    whereClause.Append("(");
                    foreach (var field in SQLUtil.GetFields<T>())
                    {
                        object value = field.Item2.GetValue(c.Data);

                        if (value == null ||
                            (_onlyPrimaryKeys &&
                             field.Item3.Any(a => !a.IsPrimaryKey)))
                            continue;

                        whereClause.Append(field.Item1);

                        whereClause.Append(" = ");
                        whereClause.Append(SQLUtil.ToSQLValue(value));
                        whereClause.Append(" AND ");
                    }

                    whereClause.Remove(whereClause.Length - 5, 5); // remove last " AND "
                    whereClause.Append(")");
                    whereClause.Append(" OR ");
                }
                whereClause.Remove(whereClause.Length - 4, 4); // remove last " OR ";
            }

            return whereClause.ToString();
        }
    }

    /// <summary>
    /// Represents a SQL SELECT statement of the specified data model.
    /// </summary>
    /// <typeparam name="T">The data model</typeparam>
    public class SQLSelect<T> : ISQLQuery where T : IDataModel
    {
        private readonly SQLWhere<T> _whereClause;

        private readonly string _database;

        public SQLSelect(RowList<T> rowList = null, string database = null, bool onlyPrimaryKeys = true)
        {
            _whereClause = new SQLWhere<T>(rowList, onlyPrimaryKeys);
            _database = database;
        }

        public string Build()
        {
            string tableName = SQLUtil.GetTableName<T>();
            var fields = SQLUtil.GetFields<T>();

            StringBuilder fieldNames = new StringBuilder();
            
            foreach (var field in fields)
            {
                fieldNames.Append(field.Item1);
                fieldNames.Append(SQLUtil.CommaSeparator);
            }
            fieldNames.Remove(fieldNames.Length - 2, 2); // remove last ", "

            if (_whereClause.HasConditions)
                return $"SELECT {fieldNames} FROM {_database ?? Settings.TDBDatabase}.{tableName} WHERE {_whereClause.Build()}";

            return $"SELECT {fieldNames} FROM {_database ?? Settings.TDBDatabase}.{tableName}";
        }
    }

    public class SQLUpdate<T> : ISQLQuery where T : IDataModel
    {
        private List<SQLUpdateRow<T>> Rows { get; set; }

        /// <summary>
        /// Creates multiple update rows
        /// </summary>
        /// <param name="rows">A list of <see cref="SQLUpdateRow{T}"/> rows</param>
        public SQLUpdate(List<SQLUpdateRow<T>> rows)
        {
            Rows = rows;
        }

        /// <summary>
        /// Constructs the actual query
        /// </summary>
        /// <returns>Multiple update rows</returns>
        public string Build()
        {
            var result = new StringBuilder();

            var rowsStrings = Rows.Select(row => row.Build()).ToList();

            foreach (var rowString in rowsStrings)
                result.Append(rowString);

            result.Append(Environment.NewLine);

            return result.ToString();
        }
    }

    public class SQLUpdateRow<T> : ISQLQuery where T : IDataModel
    {
        /// <summary>
        /// <para>Comment appended to the values</para>
        /// <code>UPDATE...; -- this comment</code>
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// <para>The row will be commented out</para>
        /// <code>-- UPDATE..., </code>
        /// </summary>
        public bool CommentOut { get; set; }

        public readonly Dictionary<string, object> Values =
            new Dictionary<string, object>();

        protected readonly SQLWhere<T> WhereClause; 

        /// <summary>
        /// Returns the amount of values
        /// </summary>
        public int ValueCount => Values.Count;

        public SQLUpdateRow(RowList<T> row)
        {
            WhereClause = new SQLWhere<T>(row, true);
        }

        /// <summary>
        /// Adds a field-value pair to be updated
        /// </summary>
        /// <param name="field">The field name associated with the value</param>
        /// <param name="value">Any value (string, number, enum, ...)</param>
        /// <param name="isFlag">If set to true the value, "0x" will be append to value</param>
        /// <param name="noQuotes">If value is a string and this is set to true, value will not be 'quoted' (SQL variables)</param>
        public void AddValue(string field, object value, bool isFlag = false, bool noQuotes = false)
        {
            if (value == null)
                value = "";

            Values[SQLUtil.AddBackQuotes(field)] = SQLUtil.ToSQLValue(value, isFlag, noQuotes);
        }

        /// <summary>
        /// Adds a field-value pair to be updated. If value is equal to defaultValue, value will NOT be added to this update row
        /// </summary>
        /// <param name="field">The field name associated with the value</param>
        /// <param name="value">Any value (string, number, enum, ...)</param>
        /// <param name="defaultValue">Default value (usually defined in database structure)</param>
        /// <param name="isFlag">If set to true the value, "0x" will be append to value</param>
        /// <param name="noQuotes">If value is a string and this is set to true, value will not be 'quoted' (SQL variables)</param>
        public void AddValue(string field, T value, T defaultValue, bool isFlag = false, bool noQuotes = false)
        {
            if (value == null)
                return;

            if (value is float || value is double)
            {
                if (Math.Abs(Convert.ToDouble(value) - Convert.ToDouble(defaultValue)) < 0.000001)
                    return;
            }

            if (value.Equals(defaultValue))
                return;

            Values[SQLUtil.AddBackQuotes(field)] = SQLUtil.ToSQLValue(value, isFlag, noQuotes);
        }

        /// <summary>
        /// Constructs the actual query
        /// </summary>
        /// <returns>A single update query</returns>
        public virtual string Build()
        {
            var row = new StringBuilder();
            if (CommentOut)
                row.Append("-- ");

            // Return empty if there are no values or where clause or no table name set
            if (Values.Count == 0 || WhereClause.HasConditions)
                return string.Empty;

            row.Append("UPDATE ");
            row.Append(SQLUtil.GetTableName<T>());
            row.Append(" SET ");

            var count = 0;
            foreach (var values in Values)
            {
                count++;
                row.Append(values.Key);
                row.Append("=");
                row.Append(values.Value);
                if (Values.Count != count)
                    row.Append(SQLUtil.CommaSeparator);
            }

            row.Append(" WHERE ");
            row.Append(WhereClause.Build());
            row.Append(";");

            if (!string.IsNullOrWhiteSpace(Comment))
                row.Append(" -- " + Comment);
            row.Append(Environment.NewLine);

            return row.ToString();
        }
    }

    public class SQLInsert<T> : ISQLQuery where  T : IDataModel
    {
        private RowList<T> Rows { get; set; }
        private string Delete { get; set; }
        private readonly string _insertHeader;
        private readonly bool _deleteDuplicates;

        // Add a new insert header every 500 rows
        private const int MaxRowsPerInsert = 250;

        /// <summary>
        /// Creates an insert query including the insert header and its rows
        /// Single primary key (for delete)
        /// </summary>
        /// <param name="rows">A list of <see cref="SQLInsertRow"/> rows</param>
        /// <param name="withDelete">If set to false the full query will not include a delete query</param>
        /// <param name="ignore">If set to true the INSERT INTO query will be INSERT IGNORE INTO</param>
        /// <param name="deleteDuplicates">If set to true duplicated rows will be removed from final query</param>
        public SQLInsert(RowList<T> rows, bool withDelete = true, bool ignore = false,
            bool deleteDuplicates = true)
        {
            Rows = rows;
            _deleteDuplicates = deleteDuplicates;

            if (Rows.Count == 0)
                return;

            // Get the field names from the first row that is not a comment
            /*TableStructure = new List<string>();
            var firstProperRow = Rows.Find(row => !row.NoData);
            if (firstProperRow != null)
                TableStructure = firstProperRow.FieldNames;
            else
                return; // empty insert*/

            _insertHeader = new SQLInsertHeader<T>(ignore).Build();

            if (!withDelete)
            {
                Delete = string.Empty;
                return;
            }

            Delete = new SQLDelete<T>(values).Build();
        }


        /// <summary>
        /// Constructs the actual query
        /// </summary>
        /// <returns>Full insert AND delete queries</returns>
        public string Build()
        {
            // If we only have rows with comment, do not print any query
            if (Rows.All(row => row.NoData)) // still true if row count = 0
                return "-- " + SQLUtil.AddBackQuotes(SQLUtil.GetTableName<T>()) + " has empty data." + Environment.NewLine;

            var query = new StringBuilder();

            query.Append(Delete); // Can be empty
            query.Append(_insertHeader);

            var count = 0;
            HashSet<string> rowStrings = new HashSet<string>();
            foreach (var row in Rows)
            {
                if (count >= MaxRowsPerInsert && !_deleteDuplicates)
                {
                    query.ReplaceLast(',', ';');
                    query.Append(Environment.NewLine);
                    query.Append(_insertHeader);
                    count = 0;
                }
                string rowString = row.Build();
                if (_deleteDuplicates && !rowStrings.Add(rowString))
                    continue;

                query.Append(rowString);
                count++;
            }

            query.Append(Environment.NewLine);

            query.ReplaceLast(',', ';');

            return query.ToString();
        }
    }

    public class SQLInsertRow : ISQLQuery, IEqualityComparer<SQLInsertRow>
    {
        public readonly List<string> FieldNames = new List<string>();
        private readonly List<string> _values = new List<string>();

        // Assuming that the first <count> values will be the primary key
        public List<string> GetPrimaryKeysValues(int count = 1)
        {
            if (_values.Count < count)
            {
                // If our row does not have the request number
                // of values, forge some

                var list = new List<string>();
                for (var i = 0; i < count; i++)
                    list.Add("Unknown" + i);
                return list;
            }

            return _values.GetRange(0, count);
        }

        private string _headerComment;

        /// <summary>
        /// <para>Comment appended to the values</para>
        /// <code>(a, ..., z), -- this comment</code>
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// <para>The comment that will replace the values</para>
        /// <code>-- this comment</code>
        /// </summary>
        public string HeaderComment
        {
            set
            {
                _headerComment = value;
                NoData = true;
            }
        }

        /// <summary>
        /// Row has no data, it is just a comment
        /// </summary>
        public bool NoData { get; private set; }

        /// <summary>
        /// <para>The row will be commented out</para>
        /// <code>-- (a, ..., z), </code>
        /// </summary>
        public bool CommentOut { get; set; }

        /// <summary>
        /// <para>Adds a value to this row</para>
        /// <remarks>null value will be 0</remarks>
        /// </summary>
        /// <param name="field">The field name associated with the value</param>
        /// <param name="value">Any value (string, number, enum, ...)</param>
        /// <param name="isFlag">If set to true the value, "0x" will be append to value</param>
        /// <param name="noQuotes">If value is a string and this is set to true, value will not be 'quoted' (SQL variables)</param>
        public void AddValue(string field, object value, bool isFlag = false, bool noQuotes = false)
        {
            if (value == null)
                value = 0;

            _values.Add(SQLUtil.ToSQLValue(value, isFlag, noQuotes).ToString());
            FieldNames.Add(field);
        }

        /// <summary>
        /// Constructs the actual query
        /// </summary>
        /// <returns>Single insert row (data)</returns>
        public string Build()
        {
            if (NoData)
                return "-- " + _headerComment + Environment.NewLine;

            var row = new StringBuilder();
            if (CommentOut)
                row.Append("-- ");

            row.Append("(");

            for (var i = 0; i < _values.Count; ++i)
            {
                row.Append(_values[i]);

                // Append parenthesis if end of values
                row.Append(_values.Count - 1 != i ? SQLUtil.CommaSeparator : "),");
            }

            if (!String.IsNullOrWhiteSpace(Comment))
                row.Append(" -- " + Comment);
            row.Append(Environment.NewLine);

            return row.ToString();
        }

        public bool Equals(SQLInsertRow x, SQLInsertRow y)
        {
            return x._values.SequenceEqual(y._values);
        }

        public int GetHashCode(SQLInsertRow obj)
        {
            int hashCode = 0;
            foreach (var value in obj._values)
                hashCode ^= value.GetHashCode();

            return hashCode;
        }
    }

    public class SQLDelete<T> : ISQLQuery where T: IDataModel
    {
        private readonly bool _between;
        private readonly uint _primaryKeyNumber;

        private RowList<T> Rows { get; set; }
        private Tuple<string, string> ValuesBetweenDouble { get; set; }
        private Tuple<string, string, string> ValuesBetweenTriple { get; set; }

        /// <summary>
        /// <para>Creates a delete query with a single primary key and an arbitrary number of values</para>
        /// <code>DELETE FROM `tableName` WHERE `primaryKey` IN (values[0], ..., values[n]);</code>
        /// <code>DELETE FROM `tableName` WHERE `primaryKey`=values[0];</code>
        /// </summary>
        /// <param name="values">Collection of values to be deleted</param>
        public SQLDelete(RowList<T> values )
        {
            Rows = values;
            _between = false;
            _primaryKeyNumber = 1;
        }

        /// <summary>
        /// <para>Creates a delete query that deletes between two values</para>
        /// <code>DELETE FROM `tableName` WHERE `primaryKey` BETWEEN values[0] AND values[n];</code>
        /// </summary>
        /// <param name="values">Pair of values</param>
        public SQLDelete(Tuple<string, string> values)
        {
            ValuesBetweenDouble = values;
            _between = true;
            _primaryKeyNumber = 2;
        }

        /// <summary>
        /// <para>Creates a delete query that deletes between two values</para>
        /// <code>DELETE FROM `tableName` WHERE `primaryKey` BETWEEN values[0] AND values[n];</code>
        /// </summary>
        /// <param name="values">Pair of values</param>
        /// <param name="primaryKey">Field used in the WHERE clause</param>
        public SQLDelete(Tuple<string, string, string> values)
        {
            ValuesBetweenTriple = values;
            _between = true;
            _primaryKeyNumber = 3;
        }

        /// <summary>
        /// Constructs the actual query
        /// </summary>
        /// <returns>Delete query</returns>
        public string Build()
        {
            var query = new StringBuilder();

            if (_between)
            {
                query.Append("DELETE FROM ");
                query.Append(SQLUtil.AddBackQuotes(SQLUtil.GetTableName<T>()));
                query.Append(" WHERE ");

                switch (_primaryKeyNumber)
                {
                    case 2:
                        query.Append(SQLUtil.AddBackQuotes(PrimaryKey));
                        query.Append(" BETWEEN ");
                        query.Append(ValuesBetweenDouble.Item1);
                        query.Append(" AND ");
                        query.Append(ValuesBetweenDouble.Item2);
                        query.Append(";");
                        break;
                    case 3:
                        query.Append(SQLUtil.AddBackQuotes(PrimaryKey));
                        query.Append(" BETWEEN ");
                        query.Append(ValuesBetweenTriple.Item1);
                        query.Append(" AND ");
                        query.Append(ValuesBetweenTriple.Item2);
                        query.Append(" AND ");
                        query.Append(ValuesBetweenTriple.Item3);
                        query.Append(";");
                        break;
                }
            }
            else
            {
                switch (_primaryKeyNumber)
                {
                    case 2:
                    {
                        var counter = 0;
                        var rowsPerDelete = 0;

                        query.Append("DELETE FROM ");
                        query.Append(SQLUtil.AddBackQuotes(SQLUtil.GetTableName<T>()));
                        query.Append(" WHERE ");

                        foreach (var row in Rows)
                        {
                            counter++;
                            rowsPerDelete++;

                            query.Append("(");
                            query.Append(SQLUtil.AddBackQuotes(PrimaryKeyDouble.Item1));
                            query.Append("=");
                            query.Append(tuple.Item1);
                            query.Append(" AND ");
                            query.Append(SQLUtil.AddBackQuotes(PrimaryKeyDouble.Item2));
                            query.Append("=");
                            query.Append(tuple.Item2);
                            query.Append(")");

                            // Append an OR if not end of items
                            if (rowsPerDelete < 25 && ValuesDouble.Count != counter)
                                query.Append(" OR ");
                            else if (rowsPerDelete == 25)
                            {
                                rowsPerDelete = 0;
                                query.Append(";");

                                if (ValuesDouble.Count != counter)
                                {
                                    query.Append(Environment.NewLine);
                                    query.Append("DELETE FROM ");
                                    query.Append(SQLUtil.AddBackQuotes(SQLUtil.GetTableName<T>()));
                                    query.Append(" WHERE ");
                                }
                            }
                            else if (ValuesDouble.Count == counter)
                                query.Append(";");
                        }
                        break;
                    }
                    case 3:
                    {
                        var counter = 0;

                        var rowsPerDelete = 0;

                        query.Append("DELETE FROM ");
                        query.Append(SQLUtil.AddBackQuotes(SQLUtil.GetTableName<T>()));
                        query.Append(" WHERE ");

                        foreach (var tuple in ValuesTriple)
                        {
                            counter++;
                            rowsPerDelete++;

                            query.Append("(");
                            query.Append(SQLUtil.AddBackQuotes(PrimaryKeyTriple.Item1));
                            query.Append("=");
                            query.Append(tuple.Item1);
                            query.Append(" AND ");
                            query.Append(SQLUtil.AddBackQuotes(PrimaryKeyTriple.Item2));
                            query.Append("=");
                            query.Append(tuple.Item2);
                            query.Append(" AND ");
                            query.Append(SQLUtil.AddBackQuotes(PrimaryKeyTriple.Item3));
                            query.Append("=");
                            query.Append(tuple.Item3);
                            query.Append(")");

                            // Append an OR if not end of items
                            if (rowsPerDelete < 25 && ValuesTriple.Count != counter)
                                query.Append(" OR ");
                            else if (rowsPerDelete == 25)
                            {
                                rowsPerDelete = 0;
                                query.Append(";");

                                if (ValuesTriple.Count != counter)
                                {
                                    query.Append(Environment.NewLine);
                                    query.Append("DELETE FROM ");
                                    query.Append(SQLUtil.AddBackQuotes(SQLUtil.GetTableName<T>()));
                                    query.Append(" WHERE ");
                                }
                            }
                            else if (ValuesTriple.Count == counter)
                                query.Append(";");
                        }
                        break;
                    }
                    default:
                    {
                        query.Append("DELETE FROM ");
                        query.Append(SQLUtil.AddBackQuotes(SQLUtil.GetTableName<T>()));
                        query.Append(" WHERE ");
                        query.Append(SQLUtil.AddBackQuotes(PrimaryKey));
                        query.Append(Rows.Count == 1 ? "=" : " IN (");

                        var counter = 0;
                        var rowsPerDelete = 0;

                        foreach (var entry in Rows)
                        {
                            counter++;
                            rowsPerDelete++;

                            query.Append(entry);
                            // Append comma if not end of items
                            if (Rows.Count != counter)
                                query.Append(SQLUtil.CommaSeparator);
                            else if (Rows.Count != 1 && Rows.Count != counter)
                                query.Append(")");
                            else if (rowsPerDelete == 25)
                            {
                                rowsPerDelete = 0;
                                query.Append(";");

                                if (Rows.Count != counter)
                                {
                                    query.Append(Environment.NewLine);
                                    query.Append("DELETE FROM ");
                                    query.Append(SQLUtil.AddBackQuotes(SQLUtil.GetTableName<T>()));
                                    query.Append(" WHERE ");
                                    query.Append(SQLUtil.AddBackQuotes(PrimaryKey));
                                    query.Append(Rows.Count == 1 ? "=" : " IN (");
                                }
                            }
                            else if (Rows.Count == counter)
                            {
                                if (Rows.Count != 1)
                                    query.Append(")");
                                query.Append(";");
                            }
                        }
                        break;
                    }
                }
            }

            query.Append(Environment.NewLine);
            return query.ToString();
        }
    }

    internal class SQLInsertHeader<T> : ISQLQuery where T : IDataModel
    {
        private readonly bool _ignore;

        /// <summary>
        /// <para>Creates the header of an INSERT query</para>
        /// <code>INSERT INTO `tableName` (fields[0], ..., fields[n]) VALUES</code>
        /// </summary>
        /// <param name="ignore">If set to true the INSERT INTO query will be INSERT IGNORE INTO</param>
        public SQLInsertHeader(bool ignore = false)
        {
            //TableStructure = fields;
            _ignore = ignore;
        }

        /// <summary>
        /// Constructs the actual query
        /// </summary>
        /// <returns>Insert query header</returns>
        public string Build()
        {
            var query = new StringBuilder();

            query.Append("INSERT ");
            query.Append(_ignore ? "IGNORE " : string.Empty);
            query.Append("INTO ");
            query.Append(SQLUtil.AddBackQuotes(SQLUtil.GetTableName<T>()));

            foreach (var field in SQLUtil.GetFields<T>())
            {
                query.Append(" (");

                query.Append(field.Item1);
                query.Append(SQLUtil.CommaSeparator);
                query.Remove(query.Length - SQLUtil.CommaSeparator.Length, SQLUtil.CommaSeparator.Length); // remove last ", "

                query.Append(")");
            }

            query.Append(" VALUES" + Environment.NewLine);

            return query.ToString();
        }
    }
}

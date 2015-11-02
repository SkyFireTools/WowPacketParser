using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace WowPacketParser.SQL
{
    public class Row<T> where T : IDataModel
    {
        public Row()
        { }
         
        public Row(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public string Comment { get; set; } = string.Empty;
    }

    /// <summary>
    /// This represents a list of IDataModel which act as conditions in e.g WHERE clauses.
    /// </summary>
    /// <typeparam name="T">The <see cref="IDataModel" /></typeparam>
    public class RowList<T> : IEnumerable<Row<T>> where T : IDataModel
    {
        private readonly List<Row<T>> _rows = new List<Row<T>>();

        /// <summary>
        /// Gets the number of conditions in the <see cref="RowList{T}" />.
        /// </summary>
        public int Count => _rows.Count;

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="RowList{T}" />
        /// </summary>
        /// <returns>A <see cref="IEnumerator{T}" /> for the <see cref="RowList{T}" /></returns>
        public IEnumerator<Row<T>> GetEnumerator()
        {
            return _rows.GetEnumerator();
        }

        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public RowList<T> Add(T data)
        {
            return Add(new Row<T>(data));
        }

        /// <summary>
        /// Adds a Row to the list and performs some checks.
        /// </summary>
        /// <param name="row">The Row which should be added.</param>
        public RowList<T> Add(Row<T> row)
        {
            if (typeof(T).GetFields().All(f => f.GetValue(row.Data) == null))
                return this; // got empty Row. Do not add to list

            if (ContainsKey(row))
                return this;

            _rows.Add(row);

            return this;
        }

        public RowList<T> AddRange(IEnumerable<T> range)
        {
            foreach (T c in range)
                Add(c);

            return this;
        }

        public void Clear()
        {
            _rows.Clear();
        }

        

        public int GetPrimaryKeyCount()
        {
            return SQLUtil.GetFields<T>().Count(f => f.Item3.Any(g => g.IsPrimaryKey));
        }

        public bool ContainsKey(T key)
        {
            var pks = SQLUtil.GetFields<T>().Where(f => f.Item3.Any(g => g.IsPrimaryKey));

            return _rows.Count != 0 &&
                   _rows.Any(r => pks.All(f => (f.Item2.GetValue(r.Data).Equals(f.Item2.GetValue(key)))));
        }

        public bool ContainsKey(Row<T> key)
        {
            return ContainsKey(key.Data);
        }

        public Row<T> this[T key]
        {
            get
            {
                if (!ContainsKey(key))
                    return null;

                var pks = SQLUtil.GetFields<T>().Where(f => f.Item3.Any(g => g.IsPrimaryKey));
                return _rows.Find(r => pks.All(f => (f.Item2.GetValue(r.Data).Equals(f.Item2.GetValue(key)))));
            }
        }

        public Row<T> this[Row<T> key] => this[key];
    }
}

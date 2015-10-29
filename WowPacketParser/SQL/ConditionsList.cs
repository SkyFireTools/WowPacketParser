using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace WowPacketParser.SQL
{
    public class Condition<T> where T : IDataModel
    {
        public Condition(T data)
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
    public class ConditionsList<T> : IEnumerable<Condition<T>> where T : IDataModel
    {
        private readonly List<Condition<T>> _conditions = new List<Condition<T>>();

        /// <summary>
        /// Gets the number of conditions in the <see cref="ConditionsList{T}" />.
        /// </summary>
        public int Count => _conditions.Count;

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="ConditionsList{T}" />
        /// </summary>
        /// <returns>A <see cref="IEnumerator{T}" /> for the <see cref="ConditionsList{T}" /></returns>
        public IEnumerator<Condition<T>> GetEnumerator()
        {
            return _conditions.GetEnumerator();
        }

        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T data)
        {
            Add(new Condition<T>(data));
        }

        /// <summary>
        /// Adds a condition to the list and performs some checks.
        /// </summary>
        /// <param name="condition">The condition which should be added.</param>
        public void Add(Condition<T> condition)
        {
            if (typeof(T).GetFields().All(f => f.GetValue(condition) == null))
                return; // got empty condition. Do not add to list

            if (_conditions.Count != 0 &&
                _conditions.Any(
                    c =>
                        SQLUtil.GetFields<T>()
                            .Where(f => f.Item3.Any(g => g.IsPrimaryKey))
                            .All(f => (f.Item2.GetValue(c).Equals(f.Item2.GetValue(condition))))))
                return;

            _conditions.Add(condition);
        }

        public void AddRange(IEnumerable<T> range)
        {
            foreach (T c in range)
                Add(c);
        }

        public void Clear()
        {
            _conditions.Clear();
        }

        public FieldInfo GetFirstPrimaryKey()
        {
            FieldInfo pk = SQLUtil.GetFields<T>().Where(f => f.Item3.Any(g => g.IsPrimaryKey)).Select(f => f.Item2).FirstOrDefault();

            if (pk == null)
                throw new InvalidOperationException();

            return pk;
        }

        public int GetPrimaryKeyCount()
        {
            return SQLUtil.GetFields<T>().Count(f => f.Item3.Any(g => g.IsPrimaryKey));
        }
    }
}

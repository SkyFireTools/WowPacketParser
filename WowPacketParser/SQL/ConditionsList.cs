using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace WowPacketParser.SQL
{
    /// <summary>
    /// This represents a list of IDataModel which act as conditions in e.g WHERE clauses.
    /// </summary>
    /// <typeparam name="T">The <see cref="IDataModel" /></typeparam>
    public class ConditionsList<T> : IEnumerable<T> where T : IDataModel
    {
        private readonly List<T> _conditions = new List<T>();

        /// <summary>
        /// Gets the number of conditions in the <see cref="ConditionsList{T}" />.
        /// </summary>
        public int Count => _conditions.Count;

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="ConditionsList{T}" />
        /// </summary>
        /// <returns>A <see cref="IEnumerator{T}" /> for the <see cref="ConditionsList{T}" /></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _conditions.GetEnumerator();
        }

        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds a condition to the list and performs some checks.
        /// </summary>
        /// <param name="condition">The condition which should be added.</param>
        public void Add(T condition)
        {
            if (typeof(T).GetFields().All(f => f.GetValue(condition) == null))
                return; // got empty condition. Do not add to list

            if (_conditions.Count != 0 &&
                _conditions.Any(
                    c =>
                        SQLUtil.GetFields<T>()
                            .Where(f => f.Item2.IsPrimaryKey)
                            .All(f => (f.Item1.GetValue(c).Equals(f.Item1.GetValue(condition))))))
                throw new InvalidConstraintException("Tried to add duplicate primary key to condition list.");

            _conditions.Add(condition);
        }

        public void Clear()
        {
            _conditions.Clear();
        }
    }
}

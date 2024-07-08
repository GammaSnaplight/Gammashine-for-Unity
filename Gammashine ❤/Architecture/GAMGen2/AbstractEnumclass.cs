using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Snaplight
{
    public abstract class AbstractEnumclass : IComparable
    {
        public string Name { get; }

        public int Id { get; }

        protected AbstractEnumclass(int id, string name) => (Id, Name) = (id, name);

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : AbstractEnumclass =>
            typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly).Select(f => f.GetValue(null)).Cast<T>();

        public override bool Equals(object obj)
        {
            if (obj is not AbstractEnumclass otherValue) return false;

            bool typeMatches = GetType().Equals(obj.GetType());
            bool valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object obj) => Id.CompareTo(((AbstractEnumclass)obj).Id);

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}

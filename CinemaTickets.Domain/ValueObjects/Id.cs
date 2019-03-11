using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTickets.Domain.ValueObjects
{
    [NotMapped]
    public class Id<T> : IEquatable<Id<T>> where T : class
    {
        public Id(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public bool Equals(Id<T> other)
        {
            return other != null && Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Id<T>);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public static bool operator ==(Id<T> id1, Id<T> id2)
        {
            return EqualityComparer<Id<T>>.Default.Equals(id1, id2);
        }

        public static bool operator !=(Id<T> id1, Id<T> id2)
        {
            return !(id1 == id2);
        }
    }
}
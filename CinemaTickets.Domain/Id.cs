﻿using System;
using System.Collections.Generic;

namespace CinemaTickets.Domain
{
    public class Id<T> : IEquatable<Id<T>> where T : class
    {
        public Id(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public override bool Equals(object obj)
            => Equals(obj as Id<T>);

        public bool Equals(Id<T> other)
            => other != null && Value.Equals(other.Value);

        public override int GetHashCode()
            => HashCode.Combine(Value);

        public static bool operator ==(Id<T> id1, Id<T> id2)
            => EqualityComparer<Id<T>>.Default.Equals(id1, id2);

        public static bool operator !=(Id<T> id1, Id<T> id2)
            => !(id1 == id2);
    }
}

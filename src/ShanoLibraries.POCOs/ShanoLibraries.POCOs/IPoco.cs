using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace ShanoLibraries.POCOs
{
    public interface IPoco<TPoco> : IEquatable<TPoco>, INegativeEquatable<TPoco>, IComparable<TPoco>
    {
        Type ObjectType { get; }
    }

    class X : IPoco<X>
    {
        public Type ObjectType => throw new NotImplementedException();

        public int CompareTo(X other) => throw new NotImplementedException();
        public bool Equals(X other) => throw new NotImplementedException();
        public bool NotEquals(object obj) => throw new NotImplementedException();
        public bool NotEquals(X other) => throw new NotImplementedException();
    }
}

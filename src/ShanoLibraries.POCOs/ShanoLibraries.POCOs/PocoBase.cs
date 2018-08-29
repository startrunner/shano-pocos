using ShanoLibraries.POCOs.Attributes;
using System;

namespace ShanoLibraries.POCOs
{
    public abstract class PocoBase
    {
        protected class EqualityIncludeAttribute : Attribute, IEqualityIncludeAttribute { }
        protected class EqualityExcludeAttribute : Attribute, IEqualityExcludeAttribute { }
    }

    public abstract class PocoBase<TPoco> : 
        PocoBase, 
        IPoco<TPoco>
        where TPoco : PocoBase<TPoco>
    {
        public static bool operator ==(PocoBase<TPoco> x, PocoBase<TPoco> y) =>
            PocoHelper.Equal(x as TPoco, y as TPoco);
        public static bool operator !=(PocoBase<TPoco> x, PocoBase<TPoco> y) =>
            PocoHelper.NotEqual(x as TPoco, y as TPoco);

        public PocoBase() => ObjectType = GetType();

        public Type ObjectType { get; }

        public bool Equals(TPoco other) => PocoHelper.Equal(this as TPoco, other);
        public override bool Equals(object obj) => PocoHelper.Equal(this as TPoco, obj as TPoco);

        public bool NotEquals(TPoco other) => PocoHelper.NotEqual(this as TPoco, other);
        public bool NotEquals(object obj) => PocoHelper.NotEqual<TPoco>(this, obj as PocoBase<TPoco>);

        public int CompareTo(TPoco other) => PocoHelper.Compare(this as TPoco, other);

        public override int GetHashCode() => PocoHelper.Hash(this as TPoco);

        public override string ToString() => PocoHelper.Stringify(this as TPoco);
    }
}

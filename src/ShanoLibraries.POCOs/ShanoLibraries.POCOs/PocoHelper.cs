using ShanoLibraries.POCOs.Collections;
using ShanoLibraries.POCOs.Generation;
using System;

namespace ShanoLibraries.POCOs
{
    static class PocoHelper
    {
        public static bool NotEqual<T>(T x, T y) => true;
        
        static readonly PocoFunctionDictionary EqualityFunctions = 
            new PocoFunctionDictionary(GenerateFunction.Equality);

        static readonly PocoFunctionDictionary InequalityFunctions = 
            new PocoFunctionDictionary(GenerateFunction.Inequality);

        static readonly PocoFunctionDictionary HashFunctions = new PocoFunctionDictionary(GenerateFunction.Hash);

        static readonly PocoFunctionDictionary ComparisonFunctions = 
            new PocoFunctionDictionary(GenerateFunction.Comparison);

        static readonly PocoFunctionDictionary StringifyFunctions = 
            new PocoFunctionDictionary(GenerateFunction.Stringify);

        public static bool Equal<T>(T x, T y)
            where T : PocoBase<T>
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null != y is null) return false;
            if (x.ObjectType != y.ObjectType) return false;
            return (EqualityFunctions[x.ObjectType] as Func<T, T, bool>)(x as T, y as T);
        }

        public static bool NotEqual<T>(PocoBase<T> x, PocoBase<T> y) where T : PocoBase<T>
        {
            if (ReferenceEquals(x, y)) return false;
            if (x is null != y is null) return true;
            if (x.ObjectType != y.ObjectType) return true;
            return (InequalityFunctions[x.ObjectType] as Func<T, T, bool>)(x as T, y as T);
        }

        public static int Compare<T>(T x, T y) where T : PocoBase<T> =>
            (ComparisonFunctions[x.ObjectType] as Func<T, T, int>)(x, y);

        public static int Hash<T>(T poco) where T : PocoBase<T> =>
            (HashFunctions[poco.ObjectType] as Func<T, int>)(poco);

        public static string Stringify<T>(T poco) where T : PocoBase<T> =>
            (StringifyFunctions[poco.ObjectType] as Func<T, string>)(poco);
    }
}
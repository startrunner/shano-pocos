using System;
using System.Collections.Concurrent;

namespace ShanoLibraries.POCOs.Collections
{
    internal class PocoFunctionDictionary: ConcurrentDictionary<Type, Delegate>
    {
        readonly Func<Type, Delegate> factory;
        public PocoFunctionDictionary(Func<Type, Delegate> factory) => this.factory = factory;
        public Delegate GetOrAdd(Type key) => GetOrAdd(key, factory);
        public new Delegate this[Type key]=>GetOrAdd(key);
    }
}

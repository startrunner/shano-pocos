namespace ShanoLibraries.POCOs
{
    public interface INegativeEquatable<T>
    {
        bool NotEquals(object obj);
        bool NotEquals(T other);
    }
}

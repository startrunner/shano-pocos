namespace ShanoLibraries.POCOs
{
    class SomeClass: PocoBase<SomeClass>
    {
        void Lala()
        {
            SomeClass x=null, y=null;
            bool z = x == y;
        }
    }
}

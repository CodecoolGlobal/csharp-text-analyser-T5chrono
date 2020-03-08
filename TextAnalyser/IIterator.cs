namespace TextAnalyser
{
    public interface IIterator
    {
        bool HasNext();
        string MoveNext();
        void Remove();
    }
}

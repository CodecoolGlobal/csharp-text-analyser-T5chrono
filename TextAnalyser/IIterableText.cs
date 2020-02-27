namespace TextAnalyser
{
    interface IIterableText
    {
        IIterator GetCharIterator();
        IIterator GetWordIterator();
        string GetFilename(string path);
    }
}

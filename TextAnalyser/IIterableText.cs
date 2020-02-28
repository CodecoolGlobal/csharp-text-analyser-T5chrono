namespace TextAnalyser
{
    interface IIterableText
    {
        IIterator GetCharIterator();
        IIterator GetWordIterator();
    }
}

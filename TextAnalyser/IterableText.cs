namespace TextAnalyser
{
    interface ITerableText
    {
        ITerator CharIterator();
        ITerator WordIterator();
    }
}

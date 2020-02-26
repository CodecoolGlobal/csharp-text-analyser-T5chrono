namespace TextAnalyser
{
    interface ITerableText
    {
        string FileContentAsString { get; set; }

        CharIterator CharIterator();
        ITerator WordIterator();
        string GetFilename(string path);
    }
}

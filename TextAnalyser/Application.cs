using System;

namespace TextAnalyser
{
    class Application
    {
        static void Main(string[] args)
        {
            string path = String.Empty;
            if (args.Length > 0)
            {
                path = $@"C:\Users\Tomasz.Giela\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TestFiles\{args[0]}";
            }
            else
            {
                throw new ArgumentException("No command line arguments found.");
            }

            FileContent TextToAnalyze = new FileContent(path);
            View ResultData = new View();
            StatisticalAnalysis CharAnalyzer = new StatisticalAnalysis(TextToAnalyze.GetCharIterator());
            StatisticalAnalysis WordAnalyzer = new StatisticalAnalysis(TextToAnalyze.GetWordIterator());

            ResultData.Print(TextToAnalyze.GetFilename());
            ResultData.Print($"Char count: {Convert.ToString(CharAnalyzer.Size())}");
            ResultData.Print($"Word count: {Convert.ToString(WordAnalyzer.Size())}");
            ResultData.Print(CharAnalyzer.CountOf("a", "b", "c"));
            ResultData.Print(WordAnalyzer.CountOf("a", "ab", "abc"));
            ResultData.Print($"Number of unique characters: {Convert.ToString(CharAnalyzer.DictionarySize())}");
            ResultData.Print($"Number of unique words: {Convert.ToString(WordAnalyzer.DictionarySize())}");
        }
    }
}

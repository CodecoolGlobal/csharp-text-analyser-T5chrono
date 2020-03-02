using System;
using System.Collections.Generic;

namespace TextAnalyser
{
    class Application
    {
        private static string[] InterestingWords { get; set; } = { "love", "hate", "music" };

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

            //TODO - nicer printing
            //TODO - operation timer
            ResultData.Print(TextToAnalyze.GetFilename());
            ResultData.Print($"Char count: {Convert.ToString(CharAnalyzer.Size())}");
            ResultData.Print($"Word count: {Convert.ToString(WordAnalyzer.Size())}");
            ResultData.Print($"Dict size: {Convert.ToString(WordAnalyzer.DictionarySize())}");
            ResultData.Print(WordAnalyzer.GetListOfWordsAbovePercentage(percentage: 1));
            ResultData.Print(WordAnalyzer.CountOf(InterestingWords));
            ResultData.Print($"vowels %: {Convert.ToString(CharAnalyzer.GetVowelPercentage())}");
            ResultData.Print($"a:e count ratio : {Convert.ToString(CharAnalyzer.GetRatioOfAtoE())}");
            ResultData.Print(CharAnalyzer.GetPecentageFromOccurences());
            //Console.WriteLine(Convert.ToString(CharAnalyzer.LexicalDictionary["e"]));
        }
    }
}

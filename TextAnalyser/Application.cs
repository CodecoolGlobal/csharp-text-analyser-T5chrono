using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TextAnalyser
{
    class Application
    {
        private static string[] InterestingWords { get; set; } = { "love", "hate", "music" };

        static void Main(string[] args)
        {
            List<string> paths = GetAllPaths(args);
            foreach (var path in paths)
            {
                Stopwatch benchmarkTime = new Stopwatch();
                benchmarkTime.Start();
                //TODO - exception handling for file management
                //TODO - empty file
                //TODO - no a or e letters
                FileContent TextToAnalyze = new FileContent(path);
                StatisticalAnalysis CharAnalyzer = new StatisticalAnalysis(TextToAnalyze.GetCharIterator());
                StatisticalAnalysis WordAnalyzer = new StatisticalAnalysis(TextToAnalyze.GetWordIterator());
                benchmarkTime.Stop();
                TimeSpan ts = benchmarkTime.Elapsed;
                string elapsedTime = $"{ts.TotalMilliseconds} miliseconds";
                PrintAllData(TextToAnalyze, CharAnalyzer, WordAnalyzer, elapsedTime);
            }
        }

        private static List<string> GetAllPaths(string[] args)
        {
            if (args.Length == 0)
            {
                var Error = new View();
                Error.Print("You should provide at least one valid file name as line argument");
                throw new ArgumentException("No command line arguments found.");
            }
                
           
            List<string> paths = new List<string>();
            for (int i = 0; i < args.Length; i++)
            {
                paths.Add($@"C:\Users\Tomasz.Giela\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TestFiles\{args[i]}");
            }
            return paths;
        }

        private static void PrintAllData(FileContent TextToAnalyze, StatisticalAnalysis CharAnalyzer, StatisticalAnalysis WordAnalyzer, string elapsedTime)
        {
            View ResultData = new View();
            ResultData.Print(TextToAnalyze.GetFilename());
            ResultData.Print($"Char count: {Convert.ToString(CharAnalyzer.Size())}");
            ResultData.Print($"Word count: {Convert.ToString(WordAnalyzer.Size())}");
            ResultData.Print($"Dict size: {Convert.ToString(WordAnalyzer.DictionarySize())}");
            ResultData.Print(WordAnalyzer.GetListOfWordsAbovePercentage(percentage: 1));
            ResultData.Print(WordAnalyzer.CountOf(InterestingWords));
            ResultData.Print($"vowels %: {Convert.ToString(CharAnalyzer.GetVowelPercentage())}");
            try
            {
                ResultData.Print($"a:e count ratio : {Convert.ToString(CharAnalyzer.GetRatioOfAtoE())}");
            }
            catch (ArgumentException ex)
            {
                ResultData.Print($"a:e count ratio : {ex.Message}");
            }
            ResultData.Print(CharAnalyzer.GetPecentageFromOccurences());
            ResultData.Print($"Benchmark time: {elapsedTime}");
        }
    }
}

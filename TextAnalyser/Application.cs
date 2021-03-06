﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace TextAnalyser
{
    class Application
    {
        private static string[] InterestingWords { get; set; } = { "love", "hate", "music" };

        static void Main(string[] args)
        {
            List<string> paths = GetAllPaths(args);
            var Error = new View();

            foreach (var path in paths)
            {
                //if (File.Exists(path))
                try
                {
                    Stopwatch benchmarkTime = new Stopwatch();
                    benchmarkTime.Start();
                    FileContent TextToAnalyze = new FileContent(path);
                    StatisticalAnalysis CharAnalyzer = new StatisticalAnalysis(TextToAnalyze.GetCharIterator());
                    StatisticalAnalysis WordAnalyzer = new StatisticalAnalysis(TextToAnalyze.GetWordIterator());
                    benchmarkTime.Stop();
                    TimeSpan ts = benchmarkTime.Elapsed;
                    string elapsedTime = $"{ts.TotalMilliseconds} miliseconds";
                    
                    try
                    {
                        PrintAllData(TextToAnalyze, CharAnalyzer, WordAnalyzer, elapsedTime, path);
                    }
                    catch (ArgumentException ex)
                    {
                        Error.Print(ex.Message);
                    }   
                }
                //else
                catch (FileNotFoundException)
                {
                    Error.Print($"There is no such file {Path.GetFileName(path)}");
                }  
                catch (Exception)
                {
                    Error.Print("Something went wrong. Sorry.");
                }
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
                //paths.Add($@"C:\Users\Tomasz.Giela\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TestFiles\{args[i]}");
                paths.Add($@"C:\Users\tomas\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TestFiles\{args[i]}");
            }
            return paths;
        }

        private static void PrintAllData(FileContent TextToAnalyze, StatisticalAnalysis CharAnalyzer, StatisticalAnalysis WordAnalyzer, string elapsedTime, string path)
        {
            if (TextToAnalyze.FileContentAsString.Length == 0) throw new ArgumentException($"The file '{Path.GetFileName(path)}' is empty. No statistics available.");

            View ResultData = new View();
            Console.OutputEncoding = Encoding.UTF8;

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

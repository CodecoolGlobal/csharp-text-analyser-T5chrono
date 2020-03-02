using System;
using System.Collections.Generic;

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

            //TODO - nicer printing
            //TODO - advanced statistics
            //TODO - operation timer
            ResultData.Print(TextToAnalyze.GetFilename());
            ResultData.Print($"Char count: {Convert.ToString(CharAnalyzer.Size())}");
            ResultData.Print($"Word count: {Convert.ToString(WordAnalyzer.Size())}");
            ResultData.Print(CharAnalyzer.CountOf("a", "b", "c"));
            ResultData.Print(WordAnalyzer.CountOf("a", "ab", "abc"));
            ResultData.Print($"Number of unique characters: {Convert.ToString(CharAnalyzer.DictionarySize())}");
            ResultData.Print($"Number of unique words: {Convert.ToString(WordAnalyzer.DictionarySize())}");
            ResultData.Print(CharAnalyzer.OccurMoreThan(1));
            ResultData.Print(WordAnalyzer.OccurMoreThan(0));

            //Most used words (>1%): [a,and,had..<more>] all words that make up for more than 1% of the text
            int onePercentOfWords = WordAnalyzer.DictionarySize()/100;
            //words to check
            string[] interestingWords = { "love", "hate", "music" };
            //vowels %: 38 what part of all characters are vowels (a,o,i,e,u)
            string[] vowels = { "a", "e", "i", "o", "u", "y" };
            int allVowels = 0;
            int allLetters = 0;
            foreach (var item in CharAnalyzer.LexicalDictionary)
            {
                allLetters += item.Value;
                if (Array.Exists(vowels, vowel => vowel == item.Key))
                {
                    allVowels += item.Value;
                }
            }
            Console.WriteLine($"{allVowels} / {allLetters}");
            //a: e count ratio: 1.54 the ratio of ‘a’ to ‘e’ occurrences
            float ratio = CharAnalyzer.LexicalDictionary["a"] / CharAnalyzer.LexicalDictionary["e"];
            //[ G -> 2.16] [ R -> 5.36] ....<and the rest> % of in whole text of all the letters
            List<string> wordPercentage = new List<string>();
            foreach (var item in CharAnalyzer.LexicalDictionary)
            {
                wordPercentage.Add($"{item.Key.ToUpper()} -> {item.Value/allLetters}%");
            }
        }
    }
}

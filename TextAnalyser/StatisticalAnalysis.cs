using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalyser
{
    class StatisticalAnalysis
    {
        private IIterator LexicalIterator { get; set; }
        public Dictionary<string, int> LexicalDictionary { get; set; }

        public StatisticalAnalysis(IIterator lexicalIterator)
        {
            LexicalIterator = lexicalIterator;
            LexicalDictionary = GetLexicalDictionary();
        }

        //REQUIRED METHODS
        public int Size()
        {
            int totalCount = 0;
            while (LexicalIterator.HasNext())
            {
                totalCount += 1;
                LexicalIterator.MoveNext();   
            }
            return totalCount;
        }

        public Dictionary<string, int> CountOf(params string[] letterOrWords)
        {
            Dictionary<string, int> countOfLexicalElements = new Dictionary<string, int>();

            foreach (var lexicalElement in letterOrWords)
            {
                int total_occurrences = 0;
                while (LexicalIterator.HasNext())
                {
                    if (LexicalIterator.MoveNext() == lexicalElement)
                        total_occurrences += 1;
                }
                countOfLexicalElements.Add(lexicalElement, total_occurrences);
            }
            return countOfLexicalElements;
        }

        public int DictionarySize()
        {
            return LexicalDictionary.Count;
        }

        public IOrderedEnumerable<KeyValuePair<string, int>> OccurMoreThan(int numberOfTimes)
        {
            Dictionary<string, int> mostUsedLexicalElements = new Dictionary<string, int>();
            foreach (var lexicalElement in LexicalDictionary)
            {
                if (lexicalElement.Value > numberOfTimes)
                    mostUsedLexicalElements.Add(lexicalElement.Key, lexicalElement.Value);
            }
            return mostUsedLexicalElements.OrderBy(x => x.Value);
        }

        //HELPER METHODS FOR OTHER STATISTICS
        private Dictionary<string, int> GetLexicalDictionary()
        {
            Dictionary<string, int> lexicalDictionary = new Dictionary<string, int>();
            while (LexicalIterator.HasNext())
            {
                string newLexicalElement = LexicalIterator.MoveNext();
                if (lexicalDictionary.ContainsKey(newLexicalElement))
                    lexicalDictionary[newLexicalElement] += 1;
                else
                    lexicalDictionary.Add(newLexicalElement, 1);
            }
            return lexicalDictionary;
        }

        private int TotalNumberOfLexicalElements()
        {
            int totalLexicalElements = 0;
            while (LexicalIterator.HasNext())
            {
                totalLexicalElements += 1;
                LexicalIterator.MoveNext();
            }
            return totalLexicalElements;
        }

        public double GetLimitNumberFromPercentage(int percentage)
        {
            return TotalNumberOfLexicalElements() / 100 * percentage;
        }

        public double GetVowelPercentage()
        {
            string[] vowels = { "a", "e", "i", "o", "u" };
            int allVowels = 0;
            int allLetters = 0;
            while (LexicalIterator.HasNext())
            {
                string investigatedLetter = LexicalIterator.MoveNext();
                if (vowels.Contains(investigatedLetter))
                {
                    allLetters += 1;
                    allVowels += 1;
                }
                else
                {
                    allLetters += 1;
                }
            }
            return Math.Round((double)allVowels / allLetters * 100, 2);
        }

        public double GetRatioOfAtoE()
        {
            return Math.Round((double)LexicalDictionary["a"] / LexicalDictionary["e"], 2);
        }

        public List<string> GetListOfWordsAbovePercentage(int percentage)
        {
            List<string> listOfLexicalElementsAbovePercentageUse = new List<string>();
            foreach (var item in LexicalDictionary)
            {
                if (item.Value > GetLimitNumberFromPercentage(percentage))
                {
                    listOfLexicalElementsAbovePercentageUse.Add($"{item.Key}");
                    //Line below used for debugging
                    //listOfLexicalElementsAbovePercentageUse.Add($"{item.Key}-{(item.Value / totalNumberOfLexicalElements * 100).ToString("n2")}%");
                } 
            }
            listOfLexicalElementsAbovePercentageUse.Sort();
            return listOfLexicalElementsAbovePercentageUse;
        }

        public IOrderedEnumerable<KeyValuePair<string, double>> GetPecentageFromOccurences()
        {
            var lettersPercentage = new Dictionary<string, double>();
            foreach (var item in OccurMoreThan(0))
            {
                lettersPercentage[item.Key] = item.Value / (double)TotalNumberOfLexicalElements() * 100;
            }
            return lettersPercentage.OrderByDescending(x => x.Value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalyser
{
    class StatisticalAnalysis
    {
        private IIterator LexicalIterator { get; set; }
        private Dictionary<string, int> LexicalDictionary { get; set; }

        public StatisticalAnalysis(IIterator lexicalIterator)
        {
            LexicalIterator = lexicalIterator;
            LexicalDictionary = GetLexicalDictionary();
        }

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
                    {
                        total_occurrences += 1;
                    }
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
                {
                    mostUsedLexicalElements.Add(lexicalElement.Key, lexicalElement.Value);
                }
            }
            return mostUsedLexicalElements.OrderBy(x => x.Value);
        }

        private Dictionary<string, int> GetLexicalDictionary()
        {
            Dictionary<string, int> lexicalDictionary = new Dictionary<string, int>();
            while (LexicalIterator.HasNext())
            {
                string newLexicalElement = LexicalIterator.MoveNext();
                if (lexicalDictionary.ContainsKey(newLexicalElement))
                {
                    lexicalDictionary[newLexicalElement] += 1;
                }
                else
                {
                    lexicalDictionary.Add(newLexicalElement, 1);
                }
            }
            return lexicalDictionary;
        }
    }
}

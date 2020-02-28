using System;
using System.Collections.Generic;

namespace TextAnalyser
{
    class StatisticalAnalysis
    {
        private IIterator LexicalIterator { get; set; }

        public StatisticalAnalysis(IIterator lexicalIterator)
        {
            LexicalIterator = lexicalIterator;
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
            throw new NotImplementedException();
        }


        public ISet<string> OccurMoreThan(int numberOfTimes)
        {
            throw new NotImplementedException();
        }
    }
}

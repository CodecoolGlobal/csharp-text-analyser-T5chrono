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

        public int CountOf(params string[] words)
        {
            throw new NotImplementedException();
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

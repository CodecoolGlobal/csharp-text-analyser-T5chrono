using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    class StatisticalAnalysis
    {
        public ITerator StatisticalAnalysisOf{ get; set; }

        public int CountOf(params string[] words)
        {
            throw new NotImplementedException();
        }

        public int DictionarySize()
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }

        public ISet<string> OccurMoreThan(int numberOfTimes)
        {
            throw new NotImplementedException();
        }
    }
}

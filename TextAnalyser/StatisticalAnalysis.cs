using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    class StatisticalAnalysis
    {
        public ITerableText StatisticalAnalysisOf { get; set; }

        public StatisticalAnalysis(string path)
        {
            StatisticalAnalysisOf = new FileContent(path);

            View resultTextStatistics = new View();
            resultTextStatistics.Print(StatisticalAnalysisOf.GetFilename(path));
            resultTextStatistics.Print($"Char count: {Convert.ToString(CountOfChars())}");
        }

        public int CountOfChars()
        {
            CharIterator iter = StatisticalAnalysisOf.CharIterator();
            iter.CharIteratorOf = StatisticalAnalysisOf.FileContentAsString;

            int totalCount = 0;
            while (iter.HasNext())
            {
                if (String.IsNullOrWhiteSpace(iter.MoveNext()))
                {
                    iter.MoveNext();
                }
                else
                {
                    totalCount += 1;
                    iter.MoveNext();
                }      
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

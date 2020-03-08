using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyser;

namespace TextAnalser.Test
{
    public class StatsticalAnalysisCharFixture : IDisposable
    {
        public StatisticalAnalysis sutAnalysis { get; private set; }

        public StatsticalAnalysisCharFixture()
        {
            var sutText = new FileContent(@"C:\Users\tomas\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TextAnalser.Test\TestFiles\test_simple.txt");
            sutAnalysis = new StatisticalAnalysis(sutText.GetCharIterator());
        }

        public void Dispose()
        {
            //Cleanup
        }
    }
}

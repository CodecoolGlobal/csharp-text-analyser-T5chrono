using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyser;

namespace TextAnalser.Test
{
    public class StatsticalAnalysisWordFixture : IDisposable
    {
        public StatisticalAnalysis sutAnalysis { get; private set; }

        public StatsticalAnalysisWordFixture()
        {
            var sutText = new FileContent(@"C:\Users\tomas\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TextAnalser.Test\TestFiles\test_simple.txt");
            sutAnalysis = new StatisticalAnalysis(sutText.GetWordIterator());
        }

        public void Dispose()
        {
            //Cleanup
        }
    }
}

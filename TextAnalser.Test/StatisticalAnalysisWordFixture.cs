using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyser;

namespace TextAnalser.Test
{
    public class StatsticalAnalysisWordFixture : IDisposable
    {
        public StatisticalAnalysis sutAnalysis { get; private set; }
        public StatisticalAnalysis sutAnalysisNull { get; private set; }

        public StatsticalAnalysisWordFixture()
        {
            var testingText = new FileContent(@"C:\Users\tomas\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TextAnalser.Test\TestFiles\test_simple.txt");
            sutAnalysis = new StatisticalAnalysis(testingText.GetWordIterator());
            var testingText2 = new FileContent(@"C:\Users\tomas\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TextAnalser.Test\TestFiles\test_null.txt");
            sutAnalysisNull = new StatisticalAnalysis(testingText2.GetCharIterator());
        }

        public void Dispose()
        {
            //Cleanup
        }
    }
}

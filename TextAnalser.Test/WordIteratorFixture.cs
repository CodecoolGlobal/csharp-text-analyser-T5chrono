using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyser;

namespace TextAnalser.Test
{
    public class WordIteratorFixture : IDisposable
    {
        public IIterator sutIterator { get; private set; }

        public WordIteratorFixture()
        {
            var textToAnalyse = new FileContent(@"C:\Users\tomas\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TextAnalser.Test\TestFiles\test_simple.txt");
            sutIterator = textToAnalyse.GetWordIterator();
        }

        public void Dispose()
        {
            //Cleanup
        }
    }
}

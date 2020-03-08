using System;
using Xunit;
using TextAnalyser;
using System.Collections.Generic;

namespace TextAnalser.Test
{
    public class StatisticalAnalysisTests
    {
        [Fact]
        public void TestIfSizeReturnsProperCharInt()
        {
            //Arrange
            var sutText = new FileContent(@"C:\Users\tomas\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TextAnalser.Test\TestFiles\test_simple.txt");
            var sutAnalysis = new StatisticalAnalysis(sutText.GetCharIterator());

            //Act
            var actual_value = sutAnalysis.Size();

            //Assert
            Assert.Equal(6, actual_value);
        }

        [Fact]
        public void TestIfSizeReturnsProperWordInt()
        {
            //Arrange
            var sutText = new FileContent(@"C:\Users\tomas\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TextAnalser.Test\TestFiles\test_simple.txt");
            var sutAnalysis = new StatisticalAnalysis(sutText.GetWordIterator());

            //Act
            var actual_value = sutAnalysis.Size();

            //Assert
            Assert.Equal(2, actual_value);
        }

        [Fact]
        public void TestIfDictionarySizeReturnsProperCharDictionarySize()
        {
            //Arrange
            var sutText = new FileContent(@"C:\Users\tomas\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TextAnalser.Test\TestFiles\test_simple.txt");
            var sutAnalysis = new StatisticalAnalysis(sutText.GetCharIterator());

            //Act
            var actual_value = sutAnalysis.DictionarySize();

            //Assert
            Assert.Equal(6, actual_value);
        }

        [Fact]
        public void TestIfDictionarySizeReturnsProperWordDictionarySize()
        {
            //Arrange
            var sutText = new FileContent(@"C:\Users\tomas\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TextAnalser.Test\TestFiles\test_simple.txt");
            var sutAnalysis = new StatisticalAnalysis(sutText.GetWordIterator());

            //Act
            var actual_value = sutAnalysis.DictionarySize();

            //Assert
            Assert.Equal(2, actual_value);
        }

        [Fact]
        public void TestIfGetVowelPercentageReturnsProperPercentage()
        {
            //Arrange
            var sutText = new FileContent(@"C:\Users\tomas\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TextAnalser.Test\TestFiles\test_simple.txt");
            var sutAnalysis = new StatisticalAnalysis(sutText.GetCharIterator());

            //Act
            var actual_value = sutAnalysis.GetVowelPercentage();

            //Assert
            Assert.Equal(33.33, actual_value);
        }

        [Fact]
        public void TestIfGetRatioOfAtoEReturnsProperRatio()
        {
            //Arrange
            var sutText = new FileContent(@"C:\Users\tomas\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TextAnalser.Test\TestFiles\test_simple.txt");
            var sutAnalysis = new StatisticalAnalysis(sutText.GetCharIterator());

            //Act
            var actual_value = sutAnalysis.GetRatioOfAtoE();

            //Assert
            Assert.Equal(1, actual_value);
        }

        [Fact]
        public void TestIfGetRatioOfAtoEThrowsArgumentExceptionWhenThereIsNoLetterE()
        {
            //Arrange
            var sutText = new FileContent(@"C:\Users\tomas\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TextAnalser.Test\TestFiles\test_no_e_letter.txt");
            var sutAnalysis = new StatisticalAnalysis(sutText.GetCharIterator());

            //Assert
            Assert.Throws<ArgumentException>(() => sutAnalysis.GetRatioOfAtoE());
        }

        [Fact]
        public void TestIfCountOfReturnsProperCount()
        {
            //Arrange
            var sutText = new FileContent(@"C:\Users\tomas\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\TextAnalser.Test\TestFiles\test_simple.txt");
            var sutAnalysis = new StatisticalAnalysis(sutText.GetWordIterator());
            string[] testedWords = { "abc", "def" };
            var expected = new Dictionary<string, int>
            {
                ["abc"] = 1,
                ["def"] = 1,
            };

            //Act
            var actual = sutAnalysis.CountOf(testedWords);

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TextAnalser.Test;
using Xunit;

namespace TextAnalyser.Test
{
    [Collection("WordIterator collection")]
    public class WordIteratorTests
    {
        private readonly WordIteratorFixture _wordIteratorFixture;
        public WordIteratorTests(WordIteratorFixture wordIteratorFixture)
        {
            _wordIteratorFixture = wordIteratorFixture;
        }

        [Fact]
        public void TestIfHasNextHasNextValue()
        {
            //Assert
            Assert.True(_wordIteratorFixture.sutIterator.HasNext());
        }

        [Fact]
        public void TestIfMoveNextReturnsProperValue()
        {
            //Arrange
            var expected = "abc";

            //Act
            var actual = _wordIteratorFixture.sutIterator.MoveNext();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TextAnalser.Test;
using Xunit;

namespace TextAnalyser.Test
{
    public class WordIteratorCollection
    {
        [CollectionDefinition("WordIterator collection")]
        public class GameStateCollection : ICollectionFixture<WordIteratorFixture> { }
    }
}

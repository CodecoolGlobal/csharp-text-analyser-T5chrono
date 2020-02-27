using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    class WordIterator : IIterator
    {
        public FileContent WordIteratorOf { get; set; }
        public int index { get; private set; } = 0;

        public WordIterator(FileContent fileContentAsArray)
        {
            WordIteratorOf = fileContentAsArray;
        }

        public bool HasNext()
        {
            return (index < WordIteratorOf.FileContentAsArray.Length) ? true : false;
        }

        public string MoveNext()
        {
            if (this.HasNext())
            {
                index++;
                return WordIteratorOf.FileContentAsArray[index-1].Trim().ToLower();
            }
            return null;
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}

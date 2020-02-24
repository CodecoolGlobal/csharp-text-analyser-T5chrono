using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    class CharIterator : ITerator
    {
        public FileContent CharIteratorOf { get; set; }

        public bool HasNext()
        {
            throw new NotImplementedException();
        }

        public string MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}

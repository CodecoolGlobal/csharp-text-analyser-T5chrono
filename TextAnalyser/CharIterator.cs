using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    class CharIterator : IIterator
    {
        public FileContent CharIteratorOf { get; set; }
        public int index { get; private set; } =  0;

        public CharIterator(FileContent fileContentAsString)
        {
            CharIteratorOf = fileContentAsString;
        }

        public bool HasNext()
        {
            return (index < CharIteratorOf.FileContentAsString.Length) ? true : false;
        }

        public string MoveNext()
        {
            if (this.HasNext())
            {
                index++;
                return Char.ToString(CharIteratorOf.FileContentAsString[index - 1]).ToLower();
            }
            return null;
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}

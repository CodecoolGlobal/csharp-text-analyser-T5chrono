using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    class CharIterator : ITerator
    {
        public FileContent CharIteratorOf { get; set; }
        public int index { get; private set; } =  0;

        public bool HasNext()
        {
            return (index < CharIteratorOf.FileContentAsString.Length) ? true : false;
        }

        public string MoveNext()
        {
            if (this.HasNext())
            {
                if (Char.IsWhiteSpace(CharIteratorOf.FileContentAsString[index]))
                {
                    index++;
                    return Char.ToString(CharIteratorOf.FileContentAsString[index-1]).ToLower();
                }
                else
                {
                    index++;
                }       
            }
            return null;
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}

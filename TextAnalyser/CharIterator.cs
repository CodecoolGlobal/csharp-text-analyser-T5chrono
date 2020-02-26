using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    class CharIterator : ITerator
    {
        public string CharIteratorOf { get; set; }
        public int index { get; private set; } =  0;

        public bool HasNext()
        {
            return (index < CharIteratorOf.Length) ? true : false;
        }

        public string MoveNext()
        {
            if (this.HasNext())
            {
                index++;
                return Char.ToString(CharIteratorOf[index - 1]).ToLower();
            }
            return null;
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}

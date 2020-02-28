using System;

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
                if (!Char.IsWhiteSpace(CharIteratorOf.FileContentAsString[index]))
                {
                    index++; 
                    return Char.ToString(CharIteratorOf.FileContentAsString[index - 1]).ToLower();
                }
                else
                {
                    index++;
                    MoveNext();
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

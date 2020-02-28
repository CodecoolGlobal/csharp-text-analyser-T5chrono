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
            if (index < CharIteratorOf.FileContentAsString.Length)
            {
                return true;
            }
            else
            {
                index = 0;
                return false;
            }
        }

        public string MoveNext()
        {
            if (this.HasNext())
            {
                if (Char.IsWhiteSpace(CharIteratorOf.FileContentAsString[index]))
                {
                    index += 1;
                    return MoveNext();
                }
                else
                {
                    index += 1; 
                    return Char.ToString(CharIteratorOf.FileContentAsString[index - 1]).ToLower();
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

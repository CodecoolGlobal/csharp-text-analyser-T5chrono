using System;

namespace TextAnalyser
{
    class CharIterator : IIterator
    {
        public FileContent CharIteratorOf { get; set; }
        public int index { get; private set; } =  0;

        public CharIterator(FileContent fileContentAsStringWithoutWhitespaces)
        {
            CharIteratorOf = fileContentAsStringWithoutWhitespaces;
        }

        public bool HasNext()
        {
            return (index < CharIteratorOf.FileContentAsStringWithoutWhitespaces.Length) ? true : false;
        }

        public string MoveNext()
        {
            if (this.HasNext())
            {
                index++;
                return Char.ToString(CharIteratorOf.FileContentAsStringWithoutWhitespaces[index - 1]).ToLower();
            }
            return null;
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}

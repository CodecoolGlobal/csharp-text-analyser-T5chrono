﻿using System;

namespace TextAnalyser
{
    class WordIterator : IIterator
    {
        public FileContent WordIteratorOf { get; set; }
        public int index { get; private set; } = 0;

        public WordIterator(FileContent fileContentAsArrayOfWords)
        {
            WordIteratorOf = fileContentAsArrayOfWords;
        }

        public bool HasNext()
        {
            if (index < WordIteratorOf.FileContentAsArrayOfWords.Length)
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
                index++;
                return WordIteratorOf.FileContentAsArrayOfWords[index-1].Trim().ToLower();
            }
            return null;
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}

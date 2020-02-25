using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    class FileContent : ITerableText
    {
        public string FileContentAsString { get; set; }
        public string[] FileContentAsArray { get; set; }

        public string GetFilename()
        {
            throw new NotImplementedException();
        }

        public ITerator CharIterator()
        {
            return new CharIterator();
        }

        public ITerator WordIterator()
        {
            return new WordIterator();
        }

        //Otwieranie pliku i podawanie danych
    }
}

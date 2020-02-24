using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    class FileContent : ITerableText
    {
        public string FileContents { get; set; }

        public string GetFilename()
        {
            throw new NotImplementedException();
        }

        public ITerator CharIterator()
        {
            throw new NotImplementedException();
        }

        public ITerator WordIterator()
        {
            throw new NotImplementedException();
        }
    }
}

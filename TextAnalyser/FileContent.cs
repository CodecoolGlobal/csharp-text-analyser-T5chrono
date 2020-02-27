using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextAnalyser
{
    class FileContent : IIterableText
    {
        public string FileContentAsString { get; private set; }
        public string[] FileContentAsArray { get; private set; }

        public FileContent(string path)
        {
            FileContentAsString = ReadFileContent(path);
            FileContentAsArray = ReadFileContent(path).Split(" ");
        }

        //TODO exception handling for this method
        private static string ReadFileContent(string path)
        {
            using (var reader = File.OpenText(path))
            {
                return reader.ReadToEnd().Replace("\r\n", " ").Replace("  ", " ");
            }
        }

        public string GetFilename(string path)
        {
            return Path.GetFileName(path);
        }

        public IIterator GetCharIterator()
        {
            return new CharIterator(this);
        }

        public IIterator GetWordIterator()
        {
            return new WordIterator(this);
        }
    }
}

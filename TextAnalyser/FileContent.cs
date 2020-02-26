using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextAnalyser
{
    class FileContent : ITerableText
    {
        public string FileContentAsString { get; set; }
        public string[] FileContentAsArray { get; set; }

        public FileContent(string path)
        {
            FileContentAsString = ReadFileContent(path);
            FileContentAsArray = ReadFileContent(path).Split(" ");
        }

        public string GetFilename(string path)
        {
            return Path.GetFileName(path);
        }

        //TODO exception handling for this method
        private static string ReadFileContent(string path)
        {
            using (var reader = File.OpenText(path))
            {
                return reader.ReadToEnd().Replace("\r\n", " ").Replace("  ", " ");
            }
        }

        public CharIterator CharIterator()
        {
            return new CharIterator();
         }

        public ITerator WordIterator()
        {
            return new WordIterator();
        }
    }
}

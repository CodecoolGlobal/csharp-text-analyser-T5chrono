using System.IO;

namespace TextAnalyser
{
    class FileContent : IIterableText
    {
        public string FileName { get; private set; }
        public string FileContentAsString { get; private set; }
        public string[] FileContentAsArrayOfWords { get; private set; }


        public FileContent(string path)
        {
            FileName = Path.GetFileName(path);
            FileContentAsString = ReadFileContent(path);
            FileContentAsArrayOfWords = FileContentAsString.Split(" ");
        }

        //TODO exception handling for this method
        private static string ReadFileContent(string path)
        {
            using (var reader = File.OpenText(path))
            {
                return reader.ReadToEnd().Replace("\r\n", " ").Replace("  ", " ");
            }
        }

        public string GetFilename()
        {
            return FileName;
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

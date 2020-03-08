using System.IO;
using System.Linq;
using System.Text;

namespace TextAnalyser
{
    public class FileContent : IIterableText
    {
        public string FileName { get; private set; }
        public string FileContentAsString { get; private set; }
        public string[] FileContentAsArrayOfWords { get; private set; }


        public FileContent(string path)
        {
            FileName = Path.GetFileName(path);
            FileContentAsString = ReadFileContent(path).Trim();
            FileContentAsArrayOfWords = FileContentAsString.Split(" ").Select(word => word.Trim()).Where(word => !string.IsNullOrEmpty(word)).ToArray();
        }

        private static string ReadFileContent(string path)
        {
            //EDUCATION - below different method for opening file with UTF-8
            //using (var reader = File.OpenText(path))
            using (var reader = new StreamReader(path, Encoding.UTF8))
            {
                return reader.ReadToEnd().Replace("\r\n", " ");
            }
        }

        public string GetFilename()
        {
            return $"==={FileName}===";
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

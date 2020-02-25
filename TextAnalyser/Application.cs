using System;
using System.IO;
 

namespace TextAnalyser
{
    class Application
    {
        static void Main(string[] args)
        {
            View Menu = new View();
            FileContent TextToAnalyze = new FileContent(@"C:\Users\Tomasz.Giela\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\test.txt");

            Menu.Print("Welcome to the Text Analyser.");
            Menu.Print(TextToAnalyze.FileContentAsString);



        }
    }
}

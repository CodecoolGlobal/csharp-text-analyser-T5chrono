using System;
using System.IO;
 

namespace TextAnalyser
{
    class Application
    {
        static void Main(string[] args)
        {
            string path = String.Empty;
            if (args.Length > 0)
            {
                path = $@"C:\Users\Tomasz.Giela\Dropbox\Codecool - C#\csharp-text-analyser-T5chrono\{args[0]}";
            }
            else
            {
                throw new ArgumentException("No command line arguments found.");
            }

            StatisticalAnalysis TextStatistics = new StatisticalAnalysis(path);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    public class View
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }

        public void Print(List<string> text)
        {
            throw new NotImplementedException();
        }

        public void Print(Dictionary<string, int> text)
        {
            throw new NotImplementedException();
        }
    }
}

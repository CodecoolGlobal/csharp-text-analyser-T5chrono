using System;
using System.Collections.Generic;

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

        public void Print(Dictionary<string, int> userDictionary)
        {
            foreach (KeyValuePair<string, int> item in userDictionary)
            {
                Console.WriteLine($"{item.Key} occurs: {item.Value} times");
            }
        }
    }
}

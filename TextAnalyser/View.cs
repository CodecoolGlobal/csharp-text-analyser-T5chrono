using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Print(IOrderedEnumerable<KeyValuePair<string, int>> orderedDictionry)
        {
            foreach (KeyValuePair<string, int> item in orderedDictionry)
            {
                Console.WriteLine($"{item.Key} occurs: {item.Value} times");
            }
        }
    }
}

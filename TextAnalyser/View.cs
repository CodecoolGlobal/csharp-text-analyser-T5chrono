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

        public void Print(List<string> textList)
        {
            Console.WriteLine($"Most used words(> 1 %): [{String.Join(", ", textList)}]");
        }

        public void Print(Dictionary<string, int> userDictionary)
        {
            foreach (KeyValuePair<string, int> item in userDictionary)
            {
                Console.WriteLine($"'{item.Key}' count: {item.Value}");
            }
        }

        public void Print(IOrderedEnumerable<KeyValuePair<string, float>> orderedDictionry)
        {
            string concatonatedString = String.Empty;
            foreach (var item in orderedDictionry)
            {
                concatonatedString += $"[{item.Key.ToUpper()} -> {item.Value.ToString("n2")}] ";
            }
            Console.WriteLine(concatonatedString.Trim());
        }
    }
}

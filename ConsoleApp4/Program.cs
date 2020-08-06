using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ConsoleApp4
{
    public static class Program
    {
        public class Conclusion
        {
            public int lineNumberWithMaxSum = -1;
            public List<int> wrongFormatLineNumbers = new List<int>();
        }

        public static Conclusion ProcessText(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return null;
            Conclusion result = new Conclusion();
            double maxSum = double.MinValue;
            string[] lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    var sum = lines[i].Split(',').Select(x => double.Parse(x, NumberStyles.Any, CultureInfo.InvariantCulture)).Sum();
                    if(sum > maxSum)
                    {
                        maxSum = sum;
                        result.lineNumberWithMaxSum = i + 1;
                    }
                }
                catch (FormatException)
                {
                    result.wrongFormatLineNumbers.Add(i + 1);
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            string path;
            if (args.Length > 0)
            {
                path = args[0];
            }
            else
            {
                Console.WriteLine("Enter file path:");
                path = Console.ReadLine();
            }
            if (!File.Exists(path))
            {
                Console.WriteLine("File not exist");
                return;
            }
            var conclusion = ProcessText(File.ReadAllText(path));
            if(conclusion == null)
            {
                Console.WriteLine("Empty file");
                return;
            }
            if(conclusion.lineNumberWithMaxSum != -1)
            {
                Console.WriteLine("Line number with max sum: {0}", conclusion.lineNumberWithMaxSum);
            }
            Console.WriteLine("Wrong file lines: {0}", string.Join(",", conclusion.wrongFormatLineNumbers));
            Console.ReadKey();
        }
    }
}

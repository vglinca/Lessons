using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            //let's read some colors from a simple .txt file
            string input = System.IO.File.ReadAllText(@"D:\dev\lesson6\Lesson6\Strings\input.txt");
            Console.WriteLine($"String from \"input.txt\": {input}\n");
            
            WorkWithStrings(input);
            WorkWithStringBuilder(input);
        }

        private static void WorkWithStringBuilder(string str)
        {
            var builder = new StringBuilder($"\"Colors: ");
            
            str = str.Trim();
            var splitStr = str.Split(',');

            int i = 0;
            foreach (var s in splitStr)
            {
                i++;
                var trimmedStr = s.Trim();
                //if this is the last element of array, we append point
                builder.Append(trimmedStr).Append(i == splitStr.Length ? "." : ", ");
            }
            builder.Append($"\"");

            Console.WriteLine($"Builder: {builder}");
        }

        private static void WorkWithStrings(string input)
        {
            string buf = "";

            //split input string from file by ','
            var splitInput = input.Split(',');
            foreach (var str in splitInput)
            {
                //trim each item to eleminate spaces
                var trimmedStr = str.Trim();
                
                if (trimmedStr.StartsWith('b'))
                {
                    trimmedStr = trimmedStr.ToUpper();
                }
                //at the same time make some concatenation with buf to work with it later. Make space as delimeter
                buf = String.Concat(buf, trimmedStr, ' ');
                Console.WriteLine(trimmedStr);
            }

            //join split input and add ',' delimeter back and cw it.
            var joinedString = string.Join(',', splitInput);
            Console.WriteLine($"Joined string: {joinedString}\n");

            //insert "Colors: " in from of joined string.
            joinedString = joinedString.Insert(0, "Colors: ");
            Console.WriteLine($"{joinedString}\n");

            Console.WriteLine($"buf: {buf}\n");

            //trim buf because there are may be space characters at the beginning and at the end of a string
            buf = buf.Trim();

            var splitBuf = buf.Split(' ');
            foreach (var c in splitBuf)
            {
                var trimmedC = c.Trim();
                trimmedC = trimmedC.ToLower();
                Console.WriteLine($"Color\t\"{trimmedC}\"\n");
            }

            if(input.Contains("blue"))
            {
                Console.WriteLine("String contains \"blue\" color.\n");
            }
        }
    }
}

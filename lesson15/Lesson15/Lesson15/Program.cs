﻿using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Lesson15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"1 - Work with strings\n2 - Work with dateTimes\n3 - Disposal\nEnter number: ");
            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    WorkWithStrings();
                    break;
                case 2:
                    WorkWithDateTime();
                    break;
                case 3:
                    WorkWithDisposable();
                    break;
                default:
                    break;
            }
            
        }

        

        private static void WorkWithDateTime()
        {
            //timespan & datetime
            DateTime date1 = new DateTime(1998, 2, 17, 12, 0, 0, DateTimeKind.Utc);
            DateTime date2 = DateTime.Now;

            TimeSpan diff = date2 - date1;

            Console.WriteLine($"From {date1} {date1.Kind} to {date2} {date2.Kind} passed:");
            Console.WriteLine("{0:0.00} {1,30}", diff.TotalDays, "days");
            Console.WriteLine("{0:0.00} {1,30}", diff.TotalHours, "hours");
            Console.WriteLine("{0:0.00} {1,30}", diff.TotalMinutes, "minutes");
            Console.WriteLine("{0:0.00} {1,30}", diff.TotalSeconds, "seconds");

            //get datetimeoffset and pass to it current local datetime
            //localOffset will contain date on local machine
            //we can get from this localOffset UTC time by accessing UtcDateTime property
            var localOffset = new DateTimeOffset(DateTime.Now);
            DateTimeOffset utcOffset = DateTime.UtcNow;
            Console.WriteLine($"Local time: {localOffset}\nUtc time: {localOffset.UtcDateTime}");
            //time zones
            TimeZoneInfo zoneInfo = TimeZoneInfo.Local;
            Console.WriteLine($"Local Time zone base utc offset: {zoneInfo.BaseUtcOffset}");
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            Console.WriteLine("Enter date in format: dd-MM-yyyy");
            string inputDate = Console.ReadLine();

            //Console.WriteLine($"{dto}");
            //byte[] utf8Bytes = Encoding.UTF8.GetBytes(inputDate);
            //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(inputDate);
            using (var writer = new BinaryWriter(File.Create(@"D:\dev\lesson15\Lesson15\date.txt")))
            {
                foreach (var b in utf8Bytes)
                {
                    writer.Write(b);
                }
            }
            using (var reader = new StreamReader(File.OpenRead(@"D:\dev\lesson15\Lesson15\date.txt")))
            {
                var readStr = reader.ReadLine();
                Console.WriteLine($"Date from file: {readStr}");
                var dateFromFile = DateTime.Parse(readStr);
                var dateFromFile1 = DateTimeOffset.Parse(readStr, CultureInfo.InvariantCulture);
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine($"Current culture date: {dateFromFile.ToString(CultureInfo.CurrentCulture)}");
                Console.WriteLine($"Palau date: {dateFromFile.ToString(CultureInfo.GetCultureInfo("en-PW"))}");
                Console.WriteLine($"US date: {dateFromFile.ToString(CultureInfo.GetCultureInfo("en-US"))}");
                Console.WriteLine($"Dutch date: {dateFromFile.ToString(CultureInfo.GetCultureInfo("nl"))}");
            }
        }

        private static void WorkWithStrings()
        {
            //initialize some string variable which contains non-ASCII characters
            //when we will write this string to a file and non-ASCII characters will be shown as '?' 
            //use string format to format double as a number with two digits after decimal point
            var str1 = String.Format("{0:0.00}", 123.4454654);
            var str = "Here are some non-ASCII characters: ¢¥©«±¶ϑÐ×ûΔhΛℜΣΨζ\nLet see how they will be encoded in file.\n" + str1;
            //passing OrdinalIgnoreCase we will return true when "here" is compared with "Here"
            //OrdinalIgnoreCase will not count up case of the letter
            if (str.StartsWith("here", StringComparison.OrdinalIgnoreCase))
            {
                str += "\nstr.Startswith returned true.";
            }
            else
            {
                str += "\nstr.Startswith returned false.";
            }
            //use String.Contains() method
            if (str.Contains('h'))
            {
                str = str.Replace('h', 'H');
            }
            //use Encoding to convert string to ASCII symbols. They will bw stored in a byte array.
            byte[] asciiBytes = Encoding.ASCII.GetBytes(str);
            //use binary writer to write characters as bytes to a file.
            using var writer = new BinaryWriter(File.Create(@"D:\dev\lesson15\Lesson15\output.txt"));
            foreach (var b in asciiBytes)
            {
                writer.Write(b);
            }
        }

        private static void WorkWithDisposable()
        {
            using (var vec = new MyVector<int> { 2, 4, 5, 6, 7, 8 })
            {
                foreach (var item in vec)
                {
                    Console.WriteLine($"Item: {item}");
                }
            }
            Console.WriteLine("Exited from using");
            var vecFin = new VectorFin<int> { 5, 6, 8, 7, 54, 8 };
            foreach (var item in vecFin)
            {
                Console.WriteLine($"Item: {item}");
            }
        }
    }
}

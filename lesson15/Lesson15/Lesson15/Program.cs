using System;
using System.IO;
using System.Text;

namespace Lesson15
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialize some string variable which contains non-ASCII characters
            //when we will write this string to a file and non-ASCII characters will be shown as '?' 
            //use string format to format double as a number with two digits after decimal point
            var str1 = String.Format("{0:0.00}", 123.4454654);
            var str = "Here are some non-ASCII characters: ¢¥©«±¶ϑÐ×ûΔhΛℜΣΨζ\nLet see how they will be encoded in file.\n" + str1;
            //passing OrdinalIgnoreCase we will return true when "here" is compared with "Here"
            if (str.StartsWith("here", StringComparison.OrdinalIgnoreCase))
            {
                str += "\nstr.Startswith returned true.";
            } else
            {
                str += "\nstr.Startswith returned false.";
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
    }
}

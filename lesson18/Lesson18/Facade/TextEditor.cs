using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class TextEditor
    {
        public void WriteCode()
        {
            Console.WriteLine("Writing some code...");
        }
        public void SaveFile()
        {
            Console.WriteLine("Saving a .java file...");
        }
    }
}

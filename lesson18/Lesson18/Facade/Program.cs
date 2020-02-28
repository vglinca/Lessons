using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var maven = new Maven(new BuildValidator(), new Compiler(), new DependencyLoader(), new PackageHandler(), new TestHandler());
            var ide = new IntelliJIdea(new TextEditor(), maven);
            Developer dev = new Developer { Ide = ide};

            dev.DoWork();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class Developer
    {
        public IntelliJIdea Ide { get; set; }

        public void DoWork()
        {
            Ide.HandleCodeWriting();
            Ide.BuildProject();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    //this is the general command interface
    public interface ICommand
    {
        void Execute();
    }
}

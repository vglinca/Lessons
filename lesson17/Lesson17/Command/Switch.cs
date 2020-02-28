using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    //this is the invoker
    //it will send command to receiver
    public class Switch
    {
        public Switch()
        {
        }

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }
}

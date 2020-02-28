using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    //concrete command 1
    //this command is responsible for turning light on
    public class LightOnCommand : ICommand
    {
        private readonly Light _light;
        public LightOnCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            _light.On();
        }
    }
}

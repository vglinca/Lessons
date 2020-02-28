using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    //concrete command 2
    //this command will be responsible for switching light off
    public class LightOffCommand : ICommand
    {
        private readonly Light _light;
        public LightOffCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            _light.Off();
        }
    }
}

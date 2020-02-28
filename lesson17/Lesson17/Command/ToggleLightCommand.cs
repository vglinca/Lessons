using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    //concrete command 2
    //it toggles light managing it's state
    public class ToggleLightCommand : ICommand
    {
        private readonly Light _light;
        public ToggleLightCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.Toggle();
        }
    }
}

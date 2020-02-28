using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    //concrete command 3
    //it toggles all lights
    public class ToggleAllLightsCommand : ICommand
    {
        private List<Light> _lights;
        public ToggleAllLightsCommand(List<Light> lights)
        {
            _lights = lights;
        }
        public void Execute()
        {
            foreach (var light in _lights)
            {
                if (light.IsOn)
                {
                    light.Toggle();
                }
            }
        }
    }
}

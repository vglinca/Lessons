using System;
using System.Collections.Generic;

namespace Command
{
    //command pattern encapsulates each request as an object
    class Program
    {
        static void Main(string[] args)
        {
            var light = new Light();
            var lightSwitch = new Switch();

            var onCommand = new LightOnCommand(light);
            var offCommand = new LightOffCommand(light);

            //lightSwitch.ExecuteCommand(onCommand);
            //lightSwitch.ExecuteCommand(offCommand);

            var toggleCommand = new ToggleLightCommand(light);
            //lightSwitch.ExecuteCommand(toggleCommand);
            //lightSwitch.ExecuteCommand(toggleCommand);

            var room1Light = new Light();
            var room2Light = new Light();
            var kitchenLight = new Light();
            var bedroomLight = new Light();

            lightSwitch.ExecuteCommand(new ToggleLightCommand(room1Light));
            lightSwitch.ExecuteCommand(new ToggleLightCommand(room2Light));
            var lights = new List<Light>
            {
                room1Light, room2Light, kitchenLight, bedroomLight
            };
            var toggleallLightsCommand = new ToggleAllLightsCommand(lights);
            lightSwitch.ExecuteCommand(toggleallLightsCommand);
        }
    }
}

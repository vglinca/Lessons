using System;
using System.Collections.Generic;
using System.Text;

namespace Command
{
    //this is the receiver
    public class Light
    {
        public bool IsOn { get; private set; } = false;
        public void Toggle()
        {
            if (IsOn)
            {
                Off();
            } 
            else
            {
                On();
            }
        }
        public void On()
        {
            IsOn = true;
            Console.WriteLine("Light switched on.");
        }
        public void Off()
        {
            IsOn = false;
            Console.WriteLine("Light switched off.");
        }
    }
}

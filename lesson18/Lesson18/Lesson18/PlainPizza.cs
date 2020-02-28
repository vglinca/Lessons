using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    //concrete component
    //an object with additional properties can be attached
    public class PlainPizza : IPizza
    {
        private string _description;
        public PlainPizza(string description)
        {
            _description = description;
        }

        public double CalculatePrice()
        {
            return 50;
        }

        public string GetDescription()
        {
            return _description;
        }
    }
}

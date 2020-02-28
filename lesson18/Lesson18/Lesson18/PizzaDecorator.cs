using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    //decorator maintains a reference to component
    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza _pizza;
        public PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }
        public virtual double CalculatePrice()
        {
            return _pizza.CalculatePrice();
        }

        public virtual string GetDescription()
        {
            return _pizza.GetDescription();
        }
    }
}

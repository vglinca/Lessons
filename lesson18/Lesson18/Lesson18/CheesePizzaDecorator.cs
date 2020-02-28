using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public class CheesePizzaDecorator : PizzaDecorator
    {
        public CheesePizzaDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override double CalculatePrice()
        {
            return base.CalculatePrice() + 25;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " with cheese";
        }
    }
}

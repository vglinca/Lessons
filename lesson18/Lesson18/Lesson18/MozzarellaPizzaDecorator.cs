using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public class MozzarellaPizzaDecorator : PizzaDecorator
    {
        public MozzarellaPizzaDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override double CalculatePrice()
        {
            return base.CalculatePrice() + 35;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " with mozzarella";
        }
    }
}

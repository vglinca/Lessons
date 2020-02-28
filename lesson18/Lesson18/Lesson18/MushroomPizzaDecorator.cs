using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public class MushroomPizzaDecorator : PizzaDecorator
    {
        public MushroomPizzaDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override double CalculatePrice()
        {
            return base.CalculatePrice() + 15;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " with mushrooms";
        }
    }
}

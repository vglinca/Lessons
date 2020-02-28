using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            IPizza plainPizza = new PlainPizza("Plain pizza");
            var cheesePizza = new CheesePizzaDecorator(plainPizza);
            var mozzarellaPizza = new MozzarellaPizzaDecorator(plainPizza);

            Console.WriteLine($"{cheesePizza.GetDescription()}");
            Console.WriteLine($"Price: {cheesePizza.CalculatePrice()}");

            Console.WriteLine($"{mozzarellaPizza.GetDescription()}");
            Console.WriteLine($"Price: {mozzarellaPizza.CalculatePrice()}");

            var mozzarellaPizzaWithCheese = new MozzarellaPizzaDecorator(cheesePizza);

            Console.WriteLine($"{mozzarellaPizzaWithCheese.GetDescription()}");
            Console.WriteLine($"Price: {mozzarellaPizzaWithCheese.CalculatePrice()}");

            var cheeseWithMozzarellaAndMushroomsPizza = new MushroomPizzaDecorator(mozzarellaPizzaWithCheese);

            Console.WriteLine($"{cheeseWithMozzarellaAndMushroomsPizza.GetDescription()}");
            Console.WriteLine($"Price: {cheeseWithMozzarellaAndMushroomsPizza.CalculatePrice()}");
        }
    }
}

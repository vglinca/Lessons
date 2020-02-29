using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace Lesson10
{
    class Program
    {
        delegate double OrderDelegate(Car c);
        static void Main(string[] args)
        {
            var cars = ProcessCsvFile(@"D:\dev\lesson10\Lesson10\Lesson10\cars.csv");

            //regular query using method syntax
            //select  cars where origin is USA, model is Chevrolet, and order them by horsepower ascending and then by name desc
            var q = cars
                .Where(c => c.Origin == "US" && c.Name.Contains("Chevrolet"))
                .OrderBy(c => c.Horsepower)
                .ThenByDescending(c => c.Name)
                .Select(c => c);
            foreach (var car in q)
            {
                WriteLine($"Car Model: {car.Name} |\t\tHorsepower: {car.Horsepower} | {car.Origin}");
            }

            //using sql query syntax
            var q1 = from car in cars
                     where car.Origin == "US" && car.Name.Contains("Chevrolet")
                     orderby car.Horsepower, car.Name descending
                     select car;
            //foreach (var car in q1)
            //{
            //    WriteLine($"Car Model: {car.Name} |\t\tHorsepower: {car.Horsepower} |\t\tcylinders: {car.Cylinders}");
            //}

            //using delegates and anonymous functions
            var queryUsingDelegates = cars
                .Where(delegate (Car c)
                {
                    return c.Origin == "US" && c.Name.Contains("Chevrolet");
                }).OrderBy(delegate (Car c)
                {
                    return c.Horsepower;
                }).ThenByDescending(delegate (Car c)
                {
                    return c.Name;
                });

            //this is the function which will be passed as parameter into Where() method
            Func<Car, bool> predicate = delegate (Car c){
                return c.Origin == "US" && c.Name.Contains("Chevrolet");
            };
            //anonymous function to order items
            Func<Car, double> order = delegate (Car c) {
                return c.Horsepower;
            };

            //using anonymous functions
            var queryWithFunc = cars
                .Where(predicate)
                .OrderBy(order);

            //foreach (var car in queryUsingDelegates)
            //{
            //    WriteLine($"Car Model: {car.Name} |\t\tHorsepower: {car.Horsepower} |\t\tcylinders: {car.Cylinders}");
            //}
        }

        private static int SumOfEven (List<int> numbers)
        {
            var sum = 0;
            foreach (var item in numbers)
            {
                if (item % 2 == 0)
                    sum += item;
            }
            //return numbers
            //    .Where(n => n % 2 == 0)
            //    //.Aggregate((a, b) => a + b);
            //    .Aggregate(1, (a,b) => a * b);


            var evenNumbers = new List<int> { 1, 2, 3 }
                .Where(x => {
                    Console.WriteLine(x);
                    return x % 2 == 0;
                })
                .Where(x => {
                    Console.WriteLine(x);
                    return x < 10;
                })
                .FirstOrDefault();



            //return sum;
        }

        private static IEnumerable<Car> ProcessCsvFile(string path)
        {
            var query = File.ReadAllLines(path)
                .Skip(2)
                .Where(l => l.Length > 1)
                .ToCar();
            return query.ToList();
        }

        static double OrderByFunc(Car c)
        {
            return c.Horsepower;
        }
    }
}

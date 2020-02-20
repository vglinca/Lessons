using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace Lesson10
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessCsvFile(@"D:\dev\lesson10\Lesson10\Lesson10\cars.csv");

            //regular query using method syntax
            var q = cars
                .Where(c => c.Origin == "US")
                .Where(c => c.Name.Contains("Chevrolet"))
                .OrderBy(c => c.Horsepower)
                .ThenByDescending(c => c.Name)
                .Select(c => c);

            //using sql query syntax
            var q1 = from car in cars
                     where car.Origin == "US" && car.Name.Contains("Chevrolet")
                     orderby car.Horsepower, car.Name descending
                     select car;
            
            //using delegates
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
            //Predicate<Car> predicate1=c=> c.Origin == "US" && c.Name.Contains("Chevrolet");
            Func<Car, bool> predicate = delegate (Car c)
            {
                return c.Origin == "US" && c.Name.Contains("Chevrolet");
            };

            //using anonymous functions
            var queryWithFunc = cars.Where(predicate);

            foreach (var car in queryUsingDelegates)
            {
                WriteLine($"Car Model: {car.Name} |\t\tHorsepower: {car.Horsepower} |\t\tcylinders: {car.Cylinders}");
            }
        }

        private static IEnumerable<Car> ProcessCsvFile(string path)
        {
            var query = File.ReadAllLines(path)
                .Skip(2)
                .Where(l => l.Length > 1)
                .ToCar();
            return query.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lesson11
{
    class Program
    {
        static void Main(string[] args)
        {
            //getting our collections to work with
            var cars = ProcessCsvFile(@"D:\dev\lesson11\Lesson11\Lesson11\fuel.csv");
            var manufacturers = ProcessManufacturersCsv(@"D:\dev\lesson11\Lesson11\Lesson11\manufacturers.csv");
            //-----------------------------------------------------------------------------------------------
            //usual query using method syntax
            var query1 = cars
                .Where(c => c.Manufacturer.Contains("BMW") || c.Manufacturer.Contains("Chevrolet"))
                .OrderBy(c => c.Manufacturer)
                .ThenBy(c => c.CombinedEfficiency);

            //foreach (var car in query1)
            //{
            //    Console.WriteLine($"Manufacturer: {car.Manufacturer} | Model: {car.ModelName} | CombinedEfficiency: {car.CombinedEfficiency}");
            //}
           
            //-----------------------------------------------------------------------------------------------
            //group ny queries
            var query2 =
                from car in cars
                group car by car.Manufacturer.ToUpper()
                into manufacturer
                orderby manufacturer.Key
                select manufacturer;
            //       ||     equivalent
            var query21 = cars
                .GroupBy(c => c.Manufacturer)
                .OrderBy(m => m.Key);


            //foreach (var carGroup in query21)
            //{
            //    Console.WriteLine($"{carGroup.Key} has total {carGroup.Count()} cars.");
            //    foreach (var car in carGroup.OrderByDescending(c => c.CombinedEfficiency).Take(4))
            //    {
            //        Console.WriteLine($"\tModel: {car.ModelName} | Combined Fuel Effciency: {car.CombinedEfficiency}");
            //    }
            //}

            //--------------------------------------------------------------------------------------------------
            //join queries
            var query3 =
                from car in cars
                join manufacturer in manufacturers
                    on car.Manufacturer.ToUpper() equals manufacturer.Name.ToUpper()
                orderby manufacturer.Name, car.CombinedEfficiency descending
                select new {
                    Headquarters = manufacturer.Country,
                    car.Manufacturer,
                    Model = car.ModelName,
                    Combined = car.CombinedEfficiency
                };

            var query31 =
                cars.Join(manufacturers,
                c => c.Manufacturer,
                m => m.Name,
                (c, m) => new {
                    Headquarters = m.Country,
                    c.Manufacturer,
                    Model = c.ModelName,
                    Combined = c.CombinedEfficiency
                })
                .OrderBy(cm => cm.Manufacturer)
                .ThenByDescending(cm => cm.Combined);

            //foreach (var item in query31)
            //{
            //    Console.WriteLine($"Country: {item.Headquarters} | Model: {item.Manufacturer} {item.Model} | Combined Fuel Efficiency: {item.Combined}");
            //}

            //----------------------------------------------------------------------------------
            //groupJoin queries
            var query4 =
                from manufacturer in manufacturers
                join car in cars
                    on manufacturer.Name.ToUpper() equals car.Manufacturer.ToUpper()
                into carGroup
                orderby manufacturer.Country
                select new {
                    Manufacturer = manufacturer,
                    Cars = carGroup
                }
                into result
                group result by result.Manufacturer.Country;

            var query41 =
                manufacturers.GroupJoin(cars,
                m => m.Name,
                c => c.Manufacturer,
                (m, cars) => new {
                    Manufacturer = m,
                    Cars = cars
                })
                .OrderBy(m => m.Manufacturer.Country)
                .GroupBy(m => m.Manufacturer.Country);

            foreach (var item in query41)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var car in item.SelectMany(g => g.Cars)
                    .OrderByDescending(c => c.CombinedEfficiency)
                    .Take(4))
                {
                    Console.WriteLine($"\t{car.ModelName}:{car.CombinedEfficiency}");
                }
            }

            //foreach (var item in query41)
            //{
            //    Console.WriteLine($"{item.Manufacturer.Name}:{item.Manufacturer.Country}");
            //    foreach (var car in item.Cars.OrderByDescending(c => c.CombinedEfficiency).Take(3))
            //    {
            //        Console.WriteLine($"\tModel - {car.ModelName}: Combined Consumption - {car.CombinedEfficiency}");
            //    }
            //}
        }

        private static IEnumerable<Manufacturer> ProcessManufacturersCsv(string path)
        {
            return File.ReadAllLines(path)
                .Where(l => l.Length > 1)
                .MapToManufacturer()
                .ToList();
        }

        private static IEnumerable<Car> ProcessCsvFile(string path)
        {
            var q = File.ReadAllLines(path)
                .Skip(1)
                .Where(l => l.Length > 1)
                .MapToCar();
            return q.ToList();
        }
    }
}

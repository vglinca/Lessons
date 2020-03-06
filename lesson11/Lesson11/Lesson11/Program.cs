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
			//get collections to work with
			var cars = ProcessCarsCsv(@"D:\dev\lesson11\Lesson11\Lesson11\fuel.csv");
			var manufacturers = ProcessManufacturersCsv(@"D:\dev\lesson11\Lesson11\Lesson11\manufacturers.csv");

			//var cars = ProcessCsvFile(@"D:\dev\Amdaris_lessons\Lessons\lesson11\Lesson11\Lesson11\fuel.csv");
			//var manufacturers = ProcessManufacturersCsv(@"D:\dev\Amdaris_lessons\Lessons\lesson11\Lesson11\Lesson11\manufacturers.csv");
			//-----------------------------------------------------------------------------------------------
			//usual query using method syntax
			var query1 = cars
				.Where(c => c.Manufacturer.Contains("BMW") || c.Manufacturer.Contains("Chevrolet"))
				.OrderBy(c => c.Manufacturer)
				.ThenBy(c => c.CombinedEfficiency);


			var query = cars
				.Where(c => c.CityEfficiency > 20 && !c.Manufacturer.Contains("BMW"))
				.OrderBy(c => c.Manufacturer)
				.ThenByDescending(c => c.CityEfficiency)
				.Select(c => new {
					Company = c.Manufacturer,
					Car = c.ModelName,
					c.CityEfficiency
				})
				.Take(5)
				;

			//foreach (var car in query)
			//{
			//	Console.WriteLine($"{car.Manufacturer} {car.ModelName} {car.CityEfficiency}");
			//}

			//foreach (var car in query)
			//{
			//	Console.WriteLine($"{car.Company} {car.Car} {car.CityEfficiency}");
			//}

			//foreach (var car in query1)
			//{
			//	Console.WriteLine($"Model: {car.Manufacturer} {car.ModelName} | CombinedEfficiency: {car.CombinedEfficiency}");
			//}

			//-----------------------------------------------------------------------------------------------
			//group by queries
			var query2 =
				from car in cars
				group car by car.Manufacturer.ToUpper()
				into result
				orderby result.Key.ToUpper()
				select result;
	

			var query21 = cars
				.GroupBy(c => c.Manufacturer.ToUpper())
				.OrderBy(m => m.Key.ToUpper());


			//foreach (var carGroup in query21)
			//{
			//	Console.WriteLine($"{carGroup.Key} has total {carGroup.Count()} cars.");
			//	foreach (var car in carGroup.OrderByDescending(c => c.CombinedEfficiency).Take(4))
			//	{
			//		Console.WriteLine($"\tModel: {car.ModelName} | Combined Fuel Effciency: {car.CombinedEfficiency}");
			//	}
			//}

			//--------------------------------------------------------------------------------------------------
			//join queries
			var query3 =
				from car in cars
				join manufacturer in manufacturers
					on car.Manufacturer.ToUpper() equals manufacturer.Name.ToUpper()
				orderby manufacturer.Name, car.CombinedEfficiency descending
				select new
				{
					Headquarters = manufacturer.Country,
					car.Manufacturer,
					Model = car.ModelName,
					Combined = car.CombinedEfficiency
				};

			var query31 =
				cars.Join(manufacturers,
				c => c.Manufacturer,
				m => m.Name,
				(c, m) => new
				{
					Headquarters = m.Country,
					c.Manufacturer,
					Model = c.ModelName,
					Combined = c.CombinedEfficiency
				})
				.OrderBy(cm => cm.Manufacturer)
				.ThenByDescending(cm => cm.Combined);

			//foreach (var item in query31)
			//{
			//	Console.WriteLine($"Country: {item.Headquarters} | Model: {item.Manufacturer} {item.Model} | Combined Fuel Efficiency: {item.Combined}");
			//}

			//----------------------------------------------------------------------------------
			//groupJoin queries & group by Country
			var query4 =
				from manufacturer in manufacturers
				join car in cars
					on manufacturer.Name.ToUpper() equals car.Manufacturer.ToUpper()
				into carGroup
				orderby manufacturer.Country
				select new
				{
					Manufacturer = manufacturer,
					Cars = carGroup
				}
				into result
				group result by result.Manufacturer.Country;

			var query41 =
				manufacturers.GroupJoin(cars,
				m => m.Name,
				c => c.Manufacturer,
				(m, cars) => new
				{
					Manufacturer = m,
					Cars = cars
				})
				.OrderBy(m => m.Manufacturer.Country)
				.GroupBy(m => m.Manufacturer.Country);

			//foreach (var item in query41)
			//{
			//	Console.WriteLine($"{item.Key}");
			//	foreach (var car in item.SelectMany(g => g.Cars)
			//		.OrderByDescending(c => c.CombinedEfficiency)
			//		.Take(4))
			//	{
			//		Console.WriteLine($"\t{car.ModelName}:{car.CombinedEfficiency}");
			//	}
			//}

			//------------------------------------------------------------------------
			//groupJoin & grouping by Manufacturer
			var query5 =
				from manufacturer in manufacturers
				join car in cars
					on manufacturer.Name.ToUpper() equals car.Manufacturer.ToUpper()
				into carsCollection
				orderby manufacturer.Name.ToUpper() descending
				select new
				{
					Manufacturer = manufacturer,
					Cars = carsCollection
				};

			var query51 =
				manufacturers.GroupJoin(cars,
					m => m.Name,
					c => c.Manufacturer,
					(m, cars) => new
					{
						Manufacturer = m,
						Cars = cars
					});

			

			//foreach (var item in query51)
			//{
			//	Console.WriteLine($"{item.Manufacturer.Name}:{item.Manufacturer.Country}");
			//	foreach (var car in item.Cars.OrderByDescending(c => c.CombinedEfficiency).Take(4))
			//	{
			//		Console.WriteLine($"\tModel - {car.ModelName}: Combined Consumption - {car.CombinedEfficiency}");
			//	}
			//}

			//----------------------------------------------------------------------
			//agregation functions
			var query6 =
				from car in cars
				group car by car.Manufacturer
				into grouppedCars
				select new
				{
					Manufacturer = grouppedCars.Key,
					Max = grouppedCars.Max(c => c.CombinedEfficiency),
					Min = grouppedCars.Min(c => c.CombinedEfficiency),
					Avg = grouppedCars.Average(c => c.CombinedEfficiency)
				} into result
				orderby result.Max descending, result.Min
				select result;

			foreach (var item in query6)
			{
				Console.WriteLine($"{item.Manufacturer}");
				Console.WriteLine($"\tMax: {item.Max}\n\tMin: {item.Min}\n\tAvg: {item.Avg}");
			}

			//-------------------------------------------------------------------------------------------
			//union concat except intersect....
			var cars1 = cars
				.Where(c => c.Manufacturer.Contains("Mercedes") ||
					c.Manufacturer.Contains("Audi") ||
					c.Manufacturer.Contains("BMW"))
				.Take(80);

			var cars2 = cars
				.Where(c => c.Manufacturer.Contains("Mercedes") ||
					c.Manufacturer.Contains("Audi") ||
					c.Manufacturer.Contains("BMW"))
				.Skip(60)
				.Take(75);

			var carsExcept = cars1.Except(cars2);
			var carsUnion = cars1.Union(cars2);
			var carsIntersect = cars1.Intersect(cars2);
			var carsConcat = cars1.Concat(cars2).Distinct();
			
			int i = 1;

			//Console.WriteLine($"{cars1.Count()}\t{cars2.Count()}\t{carsConcat.Count()}");
			//foreach (var car in carsConcat)
			//{
			//	Console.WriteLine($"{i++}: {car.Manufacturer} {car.ModelName}");
			//}

			//--------------------------------------------------------------------------------------------
			//repeat

			var carsRepeat = Enumerable
				.Repeat(cars.FirstOrDefault(c => c.Manufacturer.Contains("Porsche")), 10);

			var empty = Enumerable.Empty<Car>();

			//foreach (var car in carsRepeat)
			//{
			//	Console.WriteLine($"{car.Manufacturer} {car.ModelName}");
			//}

			//--------------------------------------------------------------------------------------------
			// all any
			
			//if(cars.Any(c => c.CombinedEfficiency > 35))
			//{
			//	var car = cars.FirstOrDefault(c => c.CombinedEfficiency > 35);
			//	Console.WriteLine($"{car.Manufacturer} {car.ModelName} | {car.CombinedEfficiency}");
			//}

			//if(cars.All(c => c.HighwayEfficiency > 10))
			//{
			//	var car = cars.FirstOrDefault(c => c.HighwayEfficiency > 20);
			//	Console.WriteLine($"{car.Manufacturer} {car.ModelName} | {car.HighwayEfficiency}");
			//}
		}

		private static IEnumerable<Manufacturer> ProcessManufacturersCsv(string path)
		{
			return File.ReadAllLines(path)
				.Where(l => l.Length > 1)
				.MapToManufacturer()
				.ToList();
		}

		private static IEnumerable<Car> ProcessCarsCsv(string path)
		{
			var q = File.ReadAllLines(path)
				.Skip(1)
				.Where(l => l.Length > 1)
				.MapToCar();
			return q.ToList();
		}
	}
}

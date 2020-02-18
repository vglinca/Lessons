using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson11
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<Car> MapToCar(this IEnumerable<string> source)
        {
            return source
                .Select(line => line.Split(','))
                .Select(items => new Car
                {
                    Year = int.Parse(items[0]),
                    Manufacturer = items[1],
                    ModelName = items[2],
                    Displacement = double.Parse(items[3], System.Globalization.NumberStyles.AllowDecimalPoint,
                        System.Globalization.NumberFormatInfo.InvariantInfo),
                    Cylinders = int.Parse(items[4]),
                    CityEfficiency = int.Parse(items[5]),
                    HighwayEfficiency = int.Parse(items[6]),
                    CombinedEfficiency = int.Parse(items[7])
                });
        }

        public static IEnumerable<Manufacturer> MapToManufacturer(this IEnumerable<string> source)
        {
            return source
                .Select(line => line.Split(','))
                .Select(items => new Manufacturer
                {
                    Name = items[0],
                    Country = items[1],
                    Year = int.Parse(items[2])
                });
        }
    }
}

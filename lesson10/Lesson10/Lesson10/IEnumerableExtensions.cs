using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson10
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> src)
        {
            return src.Select(line => line.Split(';'))
                .Select(items => new Car
                {
                    Name = items[0],
                    MPG = double.Parse(items[1], System.Globalization.NumberStyles.AllowDecimalPoint,
                        System.Globalization.NumberFormatInfo.InvariantInfo),
                    Cylinders = int.Parse(items[2]),
                    Displacement = double.Parse(items[3], System.Globalization.NumberStyles.AllowDecimalPoint,
                        System.Globalization.NumberFormatInfo.InvariantInfo),
                    Horsepower = double.Parse(items[4], System.Globalization.NumberStyles.AllowDecimalPoint,
                        System.Globalization.NumberFormatInfo.InvariantInfo),
                    Weight = double.Parse(items[5], System.Globalization.NumberStyles.AllowDecimalPoint,
                        System.Globalization.NumberFormatInfo.InvariantInfo),
                    Acceleration = double.Parse(items[6], System.Globalization.NumberStyles.AllowDecimalPoint,
                        System.Globalization.NumberFormatInfo.InvariantInfo),
                    Model = int.Parse(items[7]),
                    Origin = items[8]
                });
        }
    }
}

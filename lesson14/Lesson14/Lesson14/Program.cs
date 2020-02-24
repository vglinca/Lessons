using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson14
{
    class Program
    {
        static void Main(string[] args)
        {
            //make dynamic var as integer
            dynamic dynamicVar = 5;
            //use nameof() to write variable name
            Console.WriteLine($"{nameof(dynamicVar)}: {dynamicVar}");
            //now assign dynamic variable with a string
            dynamicVar = "I'm almost like JavaScript!";
            Console.WriteLine($"{nameof(dynamicVar)}: {dynamicVar}");

            //trying to call unexisting method
            //it's obvious that some exception will be thrown.
            try
            {
                dynamicVar.Process();
            } catch (Exception e)
            {
                Console.WriteLine($"{e.StackTrace}\nVariable {nameof(dynamicVar)} does not have method Process().");
            }

            var workers = new List<Worker>
            {
                new Worker
                { FirstName = "John", LastName = "Smit", Age =45,HoursWorked = 120,Stage = 25},
                new Worker
                { FirstName = "Emy", LastName = "Farafauler",Age =31,HoursWorked = 140,Stage = 7},
                new Worker
                { FirstName = "Sheldon", LastName = "Cooper",Age =35,HoursWorked = 200,Stage = 20},
                new Worker
                { FirstName = "Hovard", LastName = "Volovits",Age =36,HoursWorked = 90,Stage = 10},
                new Worker
                { FirstName = "Ragesh", LastName = "Kutrapalli",Age =33,HoursWorked = 130,Stage = 9},
                new Worker
                { FirstName = "Andrew", LastName = "Jones",Age =47,HoursWorked = 150,Stage = 20},
                new Worker
                { FirstName = "Angela", LastName = "Mitchell",Age =39,HoursWorked = 145,Stage = 14}
            };

            foreach (var worker in workers)
            {
                //call method with optional parameters
                //we dont't specify 3d one, because it's optional.
                worker.Salary = CalculateSalary(worker.Stage,
                    worker.HoursWorked > 135 ? true : false);
                //using string interpolation
                Console.WriteLine($"Worker: {worker.Name()} - Salary: {String.Format("{0:0.00}", worker.Salary)}.");
            }

            Console.WriteLine("------------------------------------------------------------------------");

            //assign dynamic variable with workers collection
            var filteredWorkers = workers.Where(w => w.HoursWorked < 180);
            dynamicVar = filteredWorkers;
            foreach (var w in dynamicVar)
            {
                //call method with named parameters
                //this method has also some optional parameters
                var mayHaveVacation = MayHaveVacation(stage: w.Stage, hoursWorked: w.HoursWorked, particularConditions: false);
                //more string interpolation
                Console.WriteLine($"Worker {w.Name()} {(mayHaveVacation ? "Can" : "Can't")} go to vacation.");
            }

            TypeConversions();
            string str = "1";
            FilterExceptions(str);
        }

        private static void TypeConversions()
        {
            IEnumerable<object> items = new List<object>
            {
                "some string variable",
                123,
                324.54,
                new Worker{FirstName = "Vasya", LastName = "Ivanov", Age = 31 },
                543,
                Guid.NewGuid(),
            };

            foreach (var item in items)
            {
                if(item is int)
                {
                    Console.WriteLine($"Integer value found {item}");
                    var str = item as string;
                    str += " is a string.";
                    Console.WriteLine($"Covert {item} to string. {item}");
                }
            }
        }

        private static void FilterExceptions(string str)
        {
            var param = str ?? throw new ArgumentNullException(nameof(str));
            //enter two numbers
            Console.Write("Enter dividend: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Enter divisor: ");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine($"You entered: x = {x} y = {y}");
            //try to divide x by y
            //and throw exception if devision by 0 has occured
            try
            {
                var res = x / y;
                Console.WriteLine($"x/y={res}");
            } catch (DivideByZeroException ex) when (x > 0)
            {
                //if x > 0 then go here
                Console.WriteLine($"{ex.StackTrace} and {nameof(x)} > 0");
            } catch (DivideByZeroException ex)
            {
                Console.WriteLine($"{ex.StackTrace}");
            }

        }

        //using optional parameters
        static double CalculateSalary(int stage, bool hasPremium = false, bool hasTaxPrivileges = false)
        {
            //do some "extremely difficult" calculation logic
            var rnd = new Random();
            var sal = 0.0;
            for (int i = 1; i <= stage; i++)
            {
                sal += (stage % i) * 100;
                if (stage > 20)
                {
                    sal *= 1.3;
                }
            }
            if (hasPremium)
            {
                sal += rnd.Next(5000, 6000);
            }
            if (hasTaxPrivileges)
            {
                sal += 2345;
            }
            return sal;
        }

        static bool MayHaveVacation(double hoursWorked, int stage, bool particularConditions = false)
        {
            if (hoursWorked < 110 && stage < 10 && !particularConditions)
            {
                return false;
            } else if (hoursWorked > 135 && stage < 8 && !particularConditions)
            {
                return false;
            }
            return true;
        }
    }

    class Worker
    {
        //here we have some autoproperties
        public string FirstName { private get; set; }
        public string LastName { private get; set; }
        //expression body method
        //it returns concatenated FirstName and LastName
        public string Name() => FirstName + LastName;
        public int Age { get; set; }
        public double HoursWorked { get; set; }
        public int Stage { get; set; }
        public double Salary { get; set; }
    }
}

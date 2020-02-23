using System;
using System.Collections.Generic;

namespace Lesson14
{
	class Program
	{
		static void Main(string[] args)
		{
			dynamic dynamicVar = 5;
			Console.WriteLine($"{nameof(dynamicVar)}: {dynamicVar}");
			dynamicVar = "I almost like JavaScript!";
			Console.WriteLine($"{nameof(dynamicVar)}: {dynamicVar}");
			var workers = new List<Worker>
			{
				new Worker
				{
					FirstName = "John", LastName = "Smit", Age =45,HoursWorked = 120,Stage = 25
				},
				new Worker
				{
					FirstName = "Emy", LastName = "Farafauler",Age =31,HoursWorked = 140,Stage = 7
				},
				new Worker
				{
					FirstName = "Sheldon", LastName = "Cooper",Age =35,HoursWorked = 200,Stage = 20
				},
				new Worker
				{
					FirstName = "Hovard", LastName = "Volovits",Age =36,HoursWorked = 90,Stage = 10
				},
				new Worker
				{
					FirstName = "Ragesh", LastName = "Kutrapalli",Age =33,HoursWorked = 130,Stage = 9
				},
				new Worker
				{
					FirstName = "Andrew", LastName = "Jones",Age =47,HoursWorked = 150,Stage = 20
				},
				new Worker
				{
					FirstName = "Angela", LastName = "Mitchell",Age =39,HoursWorked = 145,Stage = 14
				}
			};

			foreach (var worker in workers)
			{
				worker.Salary = CalculateSalary(worker.Stage,
					worker.HoursWorked > 135 ? true : false);
				//using string interpolation
				Console.WriteLine($"Worker: {worker.Name()} - Salary: {String.Format("{0:0.00}", worker.Salary)}.");
			}

			foreach (var w in workers)
			{
				var mayHaveVacation = MayHaveVacation(stage: w.Stage, hoursWorked: w.HoursWorked, particularConditions: false);
				Console.WriteLine($"Worker {w.Name()} {(mayHaveVacation ? "Can" : "Can't")} go to vacation.");
			}

		}

		//using optional parameters
		static double CalculateSalary(int stage, bool hasPremium = false, bool hasTaxPrivileges = false)
		{
			var rnd = new Random();
			var sal = 0.0;
			for (int i = 1; i <= stage; i++)
			{
				sal += (stage % i) * 100;
				if(stage > 20)
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
			if(hoursWorked < 110 && stage < 10 && !particularConditions)
			{
				return false;
			}
			else if (hoursWorked > 135 && stage < 8 && !particularConditions)
			{
				return false;
			}
			return true;
		}
	}

	class Worker
	{
		public string FirstName { private get; set; }
		public string LastName { private get; set; }
		public string Name() => FirstName + LastName;
		public int Age { get; set; }
		public double HoursWorked { get; set; }
		public int Stage { get; set; }
		public double Salary { get; set; }
	}
}

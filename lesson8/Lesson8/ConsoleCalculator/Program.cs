using System;
using System.Diagnostics;
using static System.Console;

namespace ConsoleCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			Debug.Write("Enter method Main(string[] args)");

			AppDomain domain = AppDomain.CurrentDomain;
			domain.UnhandledException += new UnhandledExceptionEventHandler(HandleException);

			WriteLine("Enter first number");
			int number1 = int.Parse(ReadLine());

			WriteLine("Enter second number");
			int number2 = int.Parse(ReadLine());

			WriteLine("Enter operation");
			string operation = ReadLine().ToUpperInvariant();

			var calculator = new Calculator();

			try
			{
				Debug.Write("Trying to calculate result.");
				var result = calculator.Calculate(number1, number2, operation);
				DisplayResult(result);
			}
			catch (ArgumentNullException ex) when (ex.ParamName == "operation")
			{
				WriteLine($"Operation was not provided.\n{ex}");
			}
			catch (ArgumentNullException ex)
			{
				WriteLine($"Some argument is null.\n{ex}");
			}
			catch(ArgumentOutOfRangeException ex)
			{
				WriteLine($"Operation is not currently supported.\n{ex}");
			}
			catch (Exception ex)
			{
				WriteLine($"Something went wrong.\n{ex}");
			}
			finally
			{
				WriteLine("Finally block....");
			}

			WriteLine("\nPress enter to exit.");
			ReadLine();
		}

		private static void HandleException(object sender, UnhandledExceptionEventArgs e)
		{
			WriteLine($"A problem occered when programm was running. Details: {e.ExceptionObject}");
		}

		private static void DisplayResult(double result)
		{
			WriteLine($"Result is: {result}");
		}
	}
}

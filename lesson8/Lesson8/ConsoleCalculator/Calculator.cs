using System;
using static System.Console;

namespace ConsoleCalculator
{
	class Calculator
	{
		public double Calculate(int n1, int n2, string operation)
		{
			var op = operation ?? throw new ArgumentNullException(nameof(operation));
			switch (op)
			{
				case "/":
					try
					{
						return Divide(n1, n2);
					}
					catch (ArithmeticException ex)
					{
						throw new CalculationException("An error occured during division.", ex);
						//throw;
						//throw new ArithmeticException();
						//throw new ArithmeticException("An error occered while trying to calculate.", ex);
					}
				case "*":
					return Multiplicate(n1, n2);
				default:
					throw new CalculationOperationNotSupportedException(op);
			}
		}

		private double Divide(int n1, int n2)
		{
			return n1 / n2;
		}

		private double Multiplicate(int n1, int n2)
		{
			return n1 * n2;
		}
	}
}

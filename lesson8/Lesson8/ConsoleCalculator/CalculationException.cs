using System;

namespace ConsoleCalculator
{
	class CalculationException : Exception
	{
		private static readonly string msg = "An error occured during calculation." +
			"Ensure the operator is supported by calculator " +
			"and provided values are within the valid range for the requested operation.";

		public CalculationException() : base(msg)
		{}
		public CalculationException(string message) : base(message)
		{}
		public CalculationException(Exception innerEx) : base(msg, innerEx)
		{}
		public CalculationException(string message, Exception innerEx) : base(message, innerEx)
		{}
	}
}

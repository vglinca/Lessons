using System;

namespace ConsoleCalculator
{
	class CalculationOperationNotSupportedException : CalculationException
	{
		public string Operation { get; }
		public override string Message
		{
			get
			{
				var message = base.Message;
				if(Operation != null)
				{
					return message + Environment.NewLine + $"Unsopported operation: {Operation}";
				}
				return message;
			}
		}

		public CalculationOperationNotSupportedException()
			: base("Specified operation was out of defined operation values.")
		{}

		public CalculationOperationNotSupportedException(string operation) : this()
		{
			Operation = operation;
		}

		public CalculationOperationNotSupportedException(string message, Exception innerEx)
			: base(message, innerEx)
		{}
		public CalculationOperationNotSupportedException(string operation, string message)
			: base(message)
		{
			Operation = operation;
		}
	}
}

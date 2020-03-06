using System;
using static System.Console;

namespace Lesson20
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDomain domain = AppDomain.CurrentDomain;
            domain.UnhandledException += new UnhandledExceptionEventHandler(HandleException);
            
            HandleInput();
        }

        public static void HandleInput()
        {
            WriteLine($"Choose operation:\n1: +\n2: -\n3: *\n4: /\n0: Exit\n\nEnter number: ");
            int operation = int.Parse(ReadLine());
            
            StartCalculator(new Calculator(), operation);
        }

        public static void StartCalculator(Calculator calc, int operation)
        {
            if (operation < 0 || operation > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(operation), $"Operation for input {operation} not found.");
            }
            int num = 0;
            while (operation != 0)
            {
                switch (operation)
                {
                    case 0:
                        break;
                    case 1:
                        WriteLine("Number of components: ");
                        num = int.Parse(ReadLine());
                        var sumArr = new int[num];
                        for (int i = 0; i < num; i++)
                        {
                            WriteLine($"Component #{i + 1}: ");
                            sumArr[i] = int.Parse(ReadLine());
                        }
                        var res = calc.Add(sumArr);
                        WriteLine($"Result is: {res}");
                        break;
                    case 2:
                        WriteLine("Number of components: ");
                        num = int.Parse(ReadLine());
                        var diffArr = new int[num];
                        for (int i = 0; i < num; i++)
                        {
                            WriteLine($"Component #{i + 1}: ");
                            diffArr[i] = int.Parse(ReadLine());
                        }
                        var diff = calc.Substract(diffArr);
                        WriteLine($"Result id: {diff}");
                        break;
                    case 3:
                        WriteLine("Number of components: ");
                        num = int.Parse(ReadLine());
                        var mulArr = new int[num];
                        for (int i = 0; i < num; i++)
                        {
                            WriteLine($"Component #{i + 1}: ");
                            mulArr[i] = int.Parse(ReadLine());
                        }
                        var prod = calc.Multiply(mulArr);
                        WriteLine($"Result id: {prod}");
                        break;
                    case 4:
                        WriteLine("Dividend: ");
                        int dividend = int.Parse(ReadLine());
                        WriteLine("Divisor: ");
                        int divisor = int.Parse(ReadLine());
                        var quotient = calc.Divide(dividend, divisor);
                        WriteLine($"Result is: {quotient}");
                        break;
                    default:
                        break;
                }
                WriteLine($"Choose operation:\n1: +\n2: -\n3: *\n4: /\n0: Exit\n\nEnter number: ");
                operation = int.Parse(ReadLine());
            }
        }

        private static void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            WriteLine($"A problem occered when programm was running. Details: {e.ExceptionObject}");
        }
    }
}

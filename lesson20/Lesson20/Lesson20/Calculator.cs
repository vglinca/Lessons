using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson20
{
    public class Calculator
    {
        public Calculator()
        {
        }
        public int Add(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Substract(int[] arr)
        {
            var diff = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                diff -= arr[i];
            }
            return diff;
        }

        public int Multiply(int[] arr)
        {
            var acc = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                acc *= arr[i];
            }
            return acc;
        }

        public double Divide(int dividend, int divisor)
        {
            try
            {
                return dividend / divisor;
            }
            catch (DivideByZeroException ex)
            {
                throw new CalculationException("An error occured during calculation.", ex);
            }
        }
    }
}

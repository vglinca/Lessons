using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    //each concrete strategy will inherit from this class
    public abstract class CardValidationStrategy
    {
        //this method must be overriden by each cobcrete strategy.
        //this method will contain validation logic depending on card
        public abstract bool IsValid(CreditCard card);
        //use Luhn algorithm for additional validation check
        //method returns true if given card number is valid
        public bool IsPassedLuhn(string num)
        {
            int sum = 0;
            int nDigits = num.Length;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {
                //get integer representation of each 'digit' character
                int d = num[i] - '0';
                if (isSecond)
                {
                    d *= 2;
                }
                sum += d / 10;
                sum += d % 10;
                isSecond = !isSecond;
            }
            //if sum is a multiple of 10, then card number is valid
            return sum % 10 == 0;
        }
    }
}

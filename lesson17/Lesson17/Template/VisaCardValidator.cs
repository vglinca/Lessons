using System;
using System.Collections.Generic;
using System.Text;

namespace Template
{
    public class VisaCardValidator : CardValidator
    {
        public override bool BeginsWithCorrectNumbers(string cardNumber)
        {
            return cardNumber.StartsWith('4');
        }

        public override bool HasCorrectLength(string cardNumber)
        {
            return cardNumber.Length == 13 || cardNumber.Length == 16 || cardNumber.Length == 19;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Template
{
    public class MasterCardValidator : CardValidator
    {
        public override bool BeginsWithCorrectNumbers(string cardNumber)
        {
            return cardNumber.StartsWith("51") || cardNumber.StartsWith("52") || cardNumber.StartsWith("53") ||
                cardNumber.StartsWith("54") || cardNumber.StartsWith("55") || cardNumber.StartsWith("222100-272099");
        }

        public override bool HasCorrectLength(string cardNumber)
        {
            return cardNumber.Length == 16;
        }
    }
}

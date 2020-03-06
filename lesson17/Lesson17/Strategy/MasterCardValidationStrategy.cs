using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    //concrete strategy1
    class MasterCardValidationStrategy : CardValidationStrategy
    {
        public override bool IsValid(CreditCard card)
        {
            //first validate if card number starts with right numbers
            //for master card these numbers are: 51,52,53,54,55 and 222100-272099
            var isValid = card.Number.StartsWith("51") || card.Number.StartsWith("52") || card.Number.StartsWith("53") ||
                card.Number.StartsWith("54") || card.Number.StartsWith("55") || card.Number.StartsWith("222100-272099");

            //secondly we check if card number length is correct
            //for master card length should be equals to 16
            if (isValid)
            {
                var numberLength = card.Number.Length;
                isValid = numberLength == 16;
            }

            //last we pass card number through the algorithm for additional validation
            if (isValid)
            {
                isValid = IsPassedLuhn(card.Number);
            }

            return isValid;
        }
    }
}

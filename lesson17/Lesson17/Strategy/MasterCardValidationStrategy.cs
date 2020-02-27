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
            var isValid = card.Number.StartsWith("51") || card.Number.StartsWith("52") || card.Number.StartsWith("53") ||
                card.Number.StartsWith("54") || card.Number.StartsWith("55") || card.Number.StartsWith("222100-272099");

            if (isValid)
            {
                var numberLength = card.Number.Length;
                isValid = numberLength == 16;
            }

            if (isValid)
            {
                isValid = IsPassedLuhn(card.Number);
            }

            return isValid;
        }
    }
}

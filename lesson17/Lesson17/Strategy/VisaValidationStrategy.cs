
namespace Strategy
{
    //concrete strategy2
    class VisaValidationStrategy : CardValidationStrategy
    {
        public override bool IsValid(CreditCard card)
        {
            //visa card number starts with '4'. We check if it's true
            var isValid = card.Number.StartsWith('4');

            if (isValid)
            {
                //visa card number length equals either 13 either 16 either 19
                var numberLength = card.Number.Length;
                isValid = numberLength == 13 || numberLength == 16 || numberLength == 19;
            }

            if (isValid)
            {
                //last we check number using Luhn algorithm
                isValid = IsPassedLuhn(card.Number);
            }

            return isValid;   
        }
    }
}

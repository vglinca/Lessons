
namespace Template
{
    public abstract class CardValidator
    {
        //this is a template method
        //it defines a template algorithm
        //each derived class should implement it in it's own way
        //it does algorithm realization
        //it calls teo abstract methods which must be implemented by a child class and one non-abstract method
        public bool IsValid(CreditCard card)
        {
            //here we do the same logic as in strategy approach
            //although here isValid() is not abstract
            bool isValid = BeginsWithCorrectNumbers(card.Number);
            if (isValid)
            {
                isValid = HasCorrectLength(card.Number);
            }
            if (isValid)
            {
                isValid = PassedLuhn(card.Number);
            }

            return isValid;
        }

        //these two methods must be overriden
        public abstract bool BeginsWithCorrectNumbers(string cardNumber);
        public abstract bool HasCorrectLength(string cardNumber);
        //this method can't be overriden
        //each concrete card validation algorithm will end with passing card number throughLuhn alg
        public bool PassedLuhn(string cardNumber)
        {
            int sum = 0;
            int nDigits = cardNumber.Length;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {
                //get integer representation of each 'digit' character
                int d = cardNumber[i] - '0';
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

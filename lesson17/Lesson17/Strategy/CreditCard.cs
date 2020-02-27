using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public class CreditCard
    {
        private readonly CardValidationStrategy _validationStrategy;
        public string Number { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }

        public CreditCard(CardValidationStrategy strategy)
        {
            _validationStrategy = strategy;
        }

        public bool IsValid()
        {
            return _validationStrategy.IsValid(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    //this is credit card class
    //it's instances must pass validation process
    public class CreditCard
    {
        //each card has it's validation strategy for being validated
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

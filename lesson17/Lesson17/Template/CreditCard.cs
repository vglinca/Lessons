namespace Template
{
    public class CreditCard
    {
        private readonly CardValidator _validationStrategy;
        public string Number { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }

        public CreditCard(CardValidator strategy)
        {
            _validationStrategy = strategy;
        }

        public bool IsValid()
        {
            return _validationStrategy.IsValid(this);
        }
    }
}

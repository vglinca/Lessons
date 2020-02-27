using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var visaCard = new CreditCard(new VisaValidationStrategy());
            visaCard.Number = "4929607829350331";
            Console.WriteLine($"{nameof(visaCard)} with number {visaCard.Number} " +
                $"is{(visaCard.IsValid() ? " " : " not ")}valid.");

            var visaCard1 = new CreditCard(new VisaValidationStrategy());
            visaCard1.Number = "4929607829350332";
            Console.WriteLine($"{nameof(visaCard1)} with number {visaCard1.Number} " +
                $"is{(visaCard1.IsValid() ? " " : " not ")}valid.");

            var masterCard = new CreditCard(new MasterCardValidationStrategy());
            masterCard.Number = "5311778111804252";
            Console.WriteLine($"{nameof(masterCard)} with number {masterCard.Number} " +
                $"is{(masterCard.IsValid() ? " " : " not ")}valid.");

            var masterCard1 = new CreditCard(new MasterCardValidationStrategy());
            masterCard1.Number = "5311778111804254";
            Console.WriteLine($"{nameof(masterCard1)} with number {masterCard1.Number} " +
                $"is{(masterCard1.IsValid() ? " " : " not ")}valid.");

        }
    }
}

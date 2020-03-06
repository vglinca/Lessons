using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            //valid
            var visaCard = new CreditCard(new VisaValidationStrategy());
            visaCard.Number = "4929607829350331";
            Console.WriteLine($"{nameof(visaCard)} with number {visaCard.Number} " +
                $"is{(visaCard.IsValid() ? " " : " not ")}valid.");
            //invalid (changed the last number)
            var visaCard1 = new CreditCard(new VisaValidationStrategy());
            visaCard1.Number = "4929607829350332";
            Console.WriteLine($"{nameof(visaCard1)} with number {visaCard1.Number} " +
                $"is{(visaCard1.IsValid() ? " " : " not ")}valid.");
            //invalid length
            var visaCard2 = new CreditCard(new VisaValidationStrategy());
            visaCard2.Number = "492960782935033256";
            Console.WriteLine($"{nameof(visaCard2)} with number {visaCard2.Number} " +
                $"is{(visaCard2.IsValid() ? " " : " not ")}valid.");
            //valid
            var masterCard = new CreditCard(new MasterCardValidationStrategy());
            masterCard.Number = "5311778111804252";
            Console.WriteLine($"{nameof(masterCard)} with number {masterCard.Number} " +
                $"is{(masterCard.IsValid() ? " " : " not ")}valid.");
            //invalid (the last number has changed)
            var masterCard1 = new CreditCard(new MasterCardValidationStrategy());
            masterCard1.Number = "5311778111804254";
            Console.WriteLine($"{nameof(masterCard1)} with number {masterCard1.Number} " +
                $"is{(masterCard1.IsValid() ? " " : " not ")}valid.");
        }
    }
}

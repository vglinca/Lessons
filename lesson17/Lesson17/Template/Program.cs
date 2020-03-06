using System;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            //the valid one
            var visaCard = new CreditCard(new VisaCardValidator());
            visaCard.Number = "4929607829350331";
            Console.WriteLine($"{nameof(visaCard)} with number {visaCard.Number} " +
                $"is{(visaCard.IsValid() ? " " : " not ")}valid.");
            //invalid (last number ruins all validation)
            var visaCard1 = new CreditCard(new VisaCardValidator());
            visaCard1.Number = "4929607829350332";
            Console.WriteLine($"{nameof(visaCard1)} with number {visaCard1.Number} " +
                $"is{(visaCard1.IsValid() ? " " : " not ")}valid.");

            //invalid length
            var visaCard2 = new CreditCard(new VisaCardValidator());
            visaCard2.Number = "492960782935033256";
            Console.WriteLine($"{nameof(visaCard2)} with number {visaCard2.Number} " +
                $"is{(visaCard2.IsValid() ? " " : " not ")}valid.");

            var masterCard = new CreditCard(new MasterCardValidator());
            masterCard.Number = "5311778111804252";
            Console.WriteLine($"{nameof(masterCard)} with number {masterCard.Number} " +
                $"is{(masterCard.IsValid() ? " " : " not ")}valid.");

            var masterCard1 = new CreditCard(new MasterCardValidator());
            masterCard1.Number = "5311778111804254";
            Console.WriteLine($"{nameof(masterCard1)} with number {masterCard1.Number} " +
                $"is{(masterCard1.IsValid() ? " " : " not ")}valid.");
        }
    }
}

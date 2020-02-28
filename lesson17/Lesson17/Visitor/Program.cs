using System;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            InsuranceCompany ic = new InsuranceCompany();

            ic.Add(new Bank { Name = "MAIB", InsurancePeriodDays = 2345 });
            ic.Add(new Factory { Name = "Chocolate Factory", Address = "Backer St. 1", InsurancePeriodMonths = 24 });
            ic.Add(new House { Address = "str. Miron Costin 21", Area = 128 });
            ic.Add(new Car { Manufacturer = CarManufacturer.AUDI, CombinedFuelConsumption = 16.7, Weight = 1245 });
            ic.Add(new Car { Manufacturer = CarManufacturer.VOLVO, CombinedFuelConsumption = 18.1, Weight = 2300 });

            IComputingInsuranceVisitor visitor = new ComputingInsuranceVisitor();

            ic.Accept(visitor);
        }
    }
}

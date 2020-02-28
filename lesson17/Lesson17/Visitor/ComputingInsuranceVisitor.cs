using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    //concrete visitor
    public class ComputingInsuranceVisitor : IComputingInsuranceVisitor
    {
        //in each Visit() method we do some random logic to compute insurance cost
        public void Visit(Bank bank)
        {
            double cost = 0.0;
            Console.WriteLine($">>>>>>>>>\nStart computing insurance cost for bank {bank.Name}");
            cost = 200000;
            if(bank.InsurancePeriodDays > 1095)
            {
                cost += (cost * 0.02);
            }
            Console.WriteLine($"<<<<<<<<<<<\nFinished insurance computing for bank {bank.Name}. Total insurance cost: ${cost}");
        }

        public void Visit(Factory factory)
        {
            double cost = 0.0;
            Console.WriteLine($">>>>>>>>>\nStart computing insurance cost for {factory.Name}");
            cost = 50000;
            if(factory.InsurancePeriodMonths < 12)
            {
                cost += (cost * 0.01);
            }
            if(factory.InsurancePeriodMonths > 48)
            {
                cost += (cost * 0.05);
            }
            Console.WriteLine($"<<<<<<<<<<<\nFinished insurance computing for {factory.Name} on address {factory.Address}. Total insurance cost: ${cost}");
        }

        public void Visit(House house)
        {
            double cost = 0.0;
            Console.WriteLine($">>>>>>>>>\nStart computing insurance cost for house with area {house.Area} on address {house.Address}");
            cost = 20000;
            if (house.Area > 100)
            {
                cost += (cost * 0.02);
            }
            Console.WriteLine($"<<<<<<<<<<<\nFinished insurance computing for house with area {house.Area} on address {house.Address}. Insurance cost: ${cost}");
        }

        public void Visit(Car car)
        {
            double cost = 0.0;
            Console.WriteLine($">>>>>>>>>\nStart computing insurance cost for car {nameof(car.Manufacturer)} " +
                $"with combined fuel consumption {car.CombinedFuelConsumption} and weight {car.Weight} kg.");
            cost = 8000;
            if(car.Manufacturer == CarManufacturer.FORD)
            {
                if(car.CombinedFuelConsumption > 15)
                {
                    cost -= (cost * 0.03);
                }
                cost += (cost * 0.01);
            }
            else if(car.Manufacturer == CarManufacturer.BMW || car.Manufacturer == CarManufacturer.AUDI)
            {
                cost += (cost * 0.04);
            }
            else if(car.Manufacturer == CarManufacturer.MERCEDES)
            {
                if(car.Weight > 2500)
                {
                    cost += (cost * 0.1);
                }
                cost += (cost * 0.02);
            } 
            else
            {
                cost += (cost * 0.06);
            }
            Console.WriteLine($"<<<<<<<<<<<\nFinished insurance computing for car {nameof(car.Manufacturer)} " +
                $"with combined fuel consumption {car.CombinedFuelConsumption} and weight {car.Weight}.\ntotal cost ${cost}.");
        }
    }
}

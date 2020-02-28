using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    //concrete element.
    public class Car : IInsurable
    {
        public CarManufacturer Manufacturer { get; set; }
        public double Weight { get; set; }
        public double CombinedFuelConsumption { get; set; }
        public void Accept(IComputingInsuranceVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public enum CarManufacturer
    {
        BMW, MERCEDES, AUDI, TOYOTA, KIA, HYUNDAI, VOLVO, FORD
    }
}

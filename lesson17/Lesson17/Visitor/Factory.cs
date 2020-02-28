using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    //concrete element.
    public class Factory : IInsurable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int InsurancePeriodMonths { get; set; }
        public void Accept(IComputingInsuranceVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    //concrete element.
    public class Bank : IInsurable
    {
        public string Name { get; set; }
        public int InsurancePeriodDays { get; set; }
        public void Accept(IComputingInsuranceVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

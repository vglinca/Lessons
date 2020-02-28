using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    //concrete element.
    public class House : IInsurable
    {
        public string Address { get; set; }
        public double Area { get; set; }
        public void Accept(IComputingInsuranceVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

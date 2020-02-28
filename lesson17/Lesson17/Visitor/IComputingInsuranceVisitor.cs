using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    //visitor interface which defines Visit() method for eash element
    public interface IComputingInsuranceVisitor
    {
        void Visit(Bank bank);
        void Visit(Factory factory);
        void Visit(House house);
        void Visit(Car car);
    }
}

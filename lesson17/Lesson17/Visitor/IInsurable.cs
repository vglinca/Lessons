using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    //this interface reprezents our element
    //it defines method Accept() with ##Visitor as parameter
    public interface IInsurable
    {
        void Accept(IComputingInsuranceVisitor visitor);
    }
}

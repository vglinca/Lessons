using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    //this is the component interface.
    //it defines the interface for objects that can have responsibilities added to them dynamically
    public interface IPizza
    {
        double CalculatePrice();
        string GetDescription();
    }
}

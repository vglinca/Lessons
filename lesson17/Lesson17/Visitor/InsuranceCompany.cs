using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor
{
    //this is the object structure
    //this class contains collection of items to be visited
    //it contains Add(), Remove() methods for collection manipulation
    //Accept() is the main method.
    //We iterate through our collection and call Accept() method for each element
    public class InsuranceCompany
    {
        private List<IInsurable> _items;
        public InsuranceCompany()
        {
            _items = new List<IInsurable>();
        }

        public void Add(IInsurable item)
        {
            _items.Add(item);
        }
        public void Remove(IInsurable item)
        {
            _items.Remove(item);
        }
        public void Accept(IComputingInsuranceVisitor visitor)
        {
            foreach (var item in _items)
            {
                //call Visit() for each item and thus Visit() method will be triggerred
                item.Accept(visitor);
            }
        }
    }
}

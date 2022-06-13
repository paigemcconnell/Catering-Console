using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class BeverageItem : CateringItem 
    {
        public override string Type { get; } = "Beverage";
        public BeverageItem(string name, decimal price) : base()
        {
            this.Name = name;
            this.Price = price;


        }
    }
}


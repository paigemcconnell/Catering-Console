using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class DessertItem : CateringItem
    {
        public override string Type { get; } = "Dessert";
        public DessertItem(string name, decimal price) : base()
        {
            this.Name = name;
            this.Price = price;


        }
    }
}


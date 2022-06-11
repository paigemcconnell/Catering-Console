using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class EntreeItem : CateringItem
    {
        public override string Type { get; } = "Entree";
        public EntreeItem(string name, decimal price) : base()
        {
            this.Name = name;
            this.Price = price;


        }
    }
}


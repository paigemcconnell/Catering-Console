using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
   public class AppetizerItem : CateringItem
    {
        public override string Type { get; } = "Appetizer";
        public AppetizerItem(string name, decimal price) : base()
        {
            this.Name = name;
            this.Price = price;
            
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain all the "work" for catering system management
    /// </summary>
    public class CateringSystem
    {

        public decimal Balance { get; private set; } = 0M;

        private readonly List<CateringItem> items = new List<CateringItem>();

        bool done = false;


        public void RunCateringSystem()
        {

        }

        public void DepositMoney(decimal addMoneyToBalance)
        {
            if (Balance + addMoneyToBalance <= 1000M)
            {
                Balance += addMoneyToBalance;

            }
        }


        public bool WithdrawMoney(decimal withdrawAmount)
        {
            if (Balance - withdrawAmount > 0M)
            {
                Balance -= withdrawAmount;
                return true;

            }
            return false;

        }
        public void Order(int quanity, string code, Dictionary<string, CateringItem> masterListOfItems)
        {
            // need to remove X quanity from dictionary Key code
            bool doesContainKey = masterListOfItems.ContainsKey(code);
           
            if ((doesContainKey) && (masterListOfItems[code].NumberOfItems >= quanity) && (quanity * masterListOfItems[code].Price <= Balance)) // make sure key exists and quantity is present
            {
                masterListOfItems[code].NumberOfItems -= quanity;  // if above remove from dictionary

            }
            // make log of what is moved 
            // charge customer
            // log charge

            // write to log final order
        }
    }
}

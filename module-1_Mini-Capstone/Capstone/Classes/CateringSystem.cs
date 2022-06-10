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
        public string Order(int quanity, string code, Dictionary<string, CateringItem> masterListOfItems)
        {
            // need to remove X quanity from dictionary Key code


            if (!masterListOfItems.ContainsKey(code)) //if the key doesn't exist
            {
                return "Key not found, please try again.";
            }

            else if (masterListOfItems[code].NumberOfItems == 0)
            {
                return "Item SOLD OUT.";
            }

            else if (masterListOfItems[code].NumberOfItems <= quanity) // if the quantity requested is to great
            {
                return "Not enough left to vend.";
            }

            else if ((quanity * (masterListOfItems[code].Price)) > Balance)  // if not enough money
            {
                return "Sorry insuffcient funds.";
            }

            else
            {
                masterListOfItems[code].NumberOfItems -= quanity;  // remove from inventory
                // make a log
                // make log of what is moved 
                Balance -= (quanity * (masterListOfItems[code].Price));
                return "Added to cart.";
            }
            // possibly it depends make a separate method to do the actual vend, use above as a logic check
            // charge customer
            // log charge

            // write to log final order
        }

        public string MakeChange(decimal bill, decimal balance)
        {
            Dictionary<string, int> changeCounter = new Dictionary<string, int>();
            decimal twentyDollarBills = 0; // set change counters to zero
            decimal tenDollarBills = 0;
            decimal fiveDollarBills = 0;
            decimal singleDollarBills = 0;
            decimal quarters = 0;
            decimal dimes = 0;
            decimal nickels = 0;

            decimal changeDue = balance - bill; // change due is intitially set and substracted as we add bills/coins

            while (changeDue > 0m) // while more change needs created
            {
                if (changeDue >= 20m)
                {
                    changeDue -= 20m;
                    twentyDollarBills++;
                }
                else if (changeDue >= 10m)
                {
                    changeDue -= 10m;
                    tenDollarBills++;
                }
                else if (changeDue >= 5m)
                {
                    changeDue -= 5m;
                    fiveDollarBills++;
                }
                else if (changeDue >= 1m)
                {
                    changeDue -= 1m;
                    singleDollarBills++;
                }
                else if (changeDue >= .25m)
                {
                    changeDue -= .25m;
                    quarters++;
                }
                else if (changeDue >= .1m)
                {
                    changeDue -= .1m;
                    dimes++;
                }
                else if (changeDue >= .05m)
                {
                    changeDue -= .05m;
                    nickels++;
                }
            }
            return $"Your change is {twentyDollarBills}-20$ bills, {tenDollarBills}-10$ bills, {fiveDollarBills}-5$ bills, {singleDollarBills}-1$ bills, {quarters}-quarters, {dimes}-dimes, {nickels}-nickels";

        }
    }
}

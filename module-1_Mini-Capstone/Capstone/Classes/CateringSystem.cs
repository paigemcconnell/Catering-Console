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
        public decimal TotalBill { get; private set; } = 0M;

        public void DepositMoney(decimal addMoneyToBalance) // deposits money to account, needs negative protection
        {
            if (Balance + addMoneyToBalance <= 1000M)
            {
                Balance += addMoneyToBalance;
            }
        }

        public void ResetBalanceToZero() // resets balance to zero, gets called when returning to main menu
        {
            Balance = 0m;

        }

        //below protects the order from incorrect items / values / funds returns correct error message or "COMPLETED" if sucessful
        public string Order(int quantity, string code, Dictionary<string, CateringItem> masterListOfItems, List<string> shoppingCartList)
        {

            if (!masterListOfItems.ContainsKey(code)) //if the key doesn't exist
            {
                return "Key not found, please try again.";
            }

            else if (masterListOfItems[code].NumberOfItems == 0) // if the item is sold out 
            {
                return "Item SOLD OUT.";
            }

            else if (masterListOfItems[code].NumberOfItems < quantity) // if the quantity requested is to great
            {
                return "Not enough left to vend.";
            }

            else if ((quantity * (masterListOfItems[code].Price)) > Balance)  // if not enough money
            {
                return "Sorry insuffcient funds.";
            }

            else
            {
                masterListOfItems[code].NumberOfItems -= quantity;  // remove from inventory
                TotalBill += (quantity * (masterListOfItems[code].Price)); // this tracks total bill 
                Balance -= (quantity * (masterListOfItems[code].Price)); // charges to balance total cost of items 
                shoppingCartList.Add($" {quantity} {masterListOfItems[code].Type} {masterListOfItems[code].Name} {masterListOfItems[code].Price} {quantity * masterListOfItems[code].Price}"); // creating a shopping cart list of codes 
                return "COMPLETED";  //this allows us to log the purchased items in the UI 
            }

        }

        public string MakeChange(decimal balance)
        {
            decimal twentyDollarBills = 0; // here and below set change counters to zero
            decimal tenDollarBills = 0;
            decimal fiveDollarBills = 0;
            decimal singleDollarBills = 0;
            decimal quarters = 0;
            decimal dimes = 0;
            decimal nickels = 0;

            decimal changeDue = balance; // change due is intitially set and substracted as we add bills/coins to change counters

            while (changeDue >= 0.05m) // while more change is still needed, values under a nickel are ignored 
            {
                if (changeDue >= 20m)  // counts and removes 20 dollars per loop from total change due
                {
                    changeDue -= 20m;
                    twentyDollarBills++;
                }
                else if (changeDue >= 10m) // counts and removes 10 dollars per loop
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

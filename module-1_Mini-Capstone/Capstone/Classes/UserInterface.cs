using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class provides all user communications, but not much else.
    /// All the "work" of the application should be done elsewhere
    /// </summary>
    public class UserInterface
    {
        private CateringSystem catering = new CateringSystem();//creating catering system...still needs to be done
        private FileAccess fileAccess = new FileAccess();//creating fileAccess system
        public Dictionary<string, CateringItem> masterListOfItems = new Dictionary<string, CateringItem>();//creating blank dictionary 

        public void RunMainMenu()
        {
            bool doneTransaction = false; //will get rid of eventually
            bool doneOrdering = false;
            fileAccess.CateringInventoryRestockFromFile( fileAccess.filePlusPath, masterListOfItems);//fill the dictionary fromCSV
            decimal currentAccountBalance = 0m;
            

            while (!doneOrdering)
            {
                Console.WriteLine("Yello! Welcome to Josh and Paige's Inventory System!");
                Console.WriteLine("(1) Display Catering Items");
                Console.WriteLine("(2) Order");
                Console.WriteLine("(3) Quit");

                string userOptionInput = Console.ReadLine();

                if (userOptionInput == "1")
                {
                    foreach(KeyValuePair<string, CateringItem> kvp in masterListOfItems)
                    {
                        Console.WriteLine($"Code : {kvp.Key} Name : {kvp.Value.Name} Price : {kvp.Value.Price} Quanity : {kvp.Value.NumberOfItems}");
                        //Make this look nicer if we have time 
                    }
                }
                else if (userOptionInput == "2") 
                {
                    while (!doneTransaction)
                    {
                        Console.WriteLine("(1) Add money");
                        Console.WriteLine("(2) Select products");
                        Console.WriteLine("(3) Complete transaction");
                        Console.WriteLine("Current account balance" + currentAccountBalance);
                        string orderUserInput = Console.ReadLine();

                        if (orderUserInput == "1")
                        {
                            Console.WriteLine("How much money would you like to add?");
                            string moneyDeposit = Console.ReadLine();
                            decimal addMoneyToBalance = Decimal.Parse(moneyDeposit);
                            currentAccountBalance += addMoneyToBalance;
                            //need to protect against things they can't parse
                            //move else where, create a class 
                            //accountbalance.Deposit(addMoneyToBalance)
                        }
                        else if (orderUserInput == "2")
                        {
                            Console.WriteLine("What code would you like to purchase?");
                            string codeToPurchaseInput = Console.ReadLine();
                            Console.WriteLine("What quantity do you need?");
                            string quantity = Console.ReadLine();
                            //CateringSystem.Order(quanity, code);
                            

                         }
                        else if (orderUserInput == "3")
                        {
                            //Print list 
                            //make change
                            //return to main menu 
                            doneTransaction = true;

                        }
                        else
                        {
                            Console.WriteLine("Sorry, please select option 1, 2, or 3.");
                        }
                    }
                }
                else if (userOptionInput == "3")
                {
                    Console.WriteLine("Thank you for purchasing, have a great day!");
                    doneOrdering = false;
                }
                else
                {
                    Console.WriteLine("Sorry, please select option 1, 2, or 3.");
                }
                //decimal priceCheck = MasterListOfItems["B1"].Price; use as unit test later 
                //Console.WriteLine(priceCheck.ToString());


                Console.ReadLine();
            }
        }
    }
}

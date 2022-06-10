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
        public CateringSystem catering = new CateringSystem();//creating catering system...still needs to be done
        private FileAccess fileAccess = new FileAccess();//creating fileAccess system
        public Dictionary<string, CateringItem> masterListOfItems = new Dictionary<string, CateringItem>();//creating blank dictionary 
        public LogSystem logSystem = new LogSystem();

        public void RunMainMenu()
        {
            bool doneTransaction = false; 
            bool doneOrdering = false;
            fileAccess.CateringInventoryRestockFromFile( fileAccess.filePlusPath, masterListOfItems);//fill the dictionary fromCSV
            decimal currentAccountBalance = 0m;
            

            while (!doneOrdering) // main menu loop
            {
                doneTransaction = false; // allows to re-enter ordering menu after exiting

                Console.WriteLine("Yello! Welcome to Josh and Paige's Inventory System!");
                Console.WriteLine("(1) Display Catering Items");
                Console.WriteLine("(2) Order");
                Console.WriteLine("(3) Quit");

                string userOptionInput = Console.ReadLine();

                if (userOptionInput == "1") //display catering item 
                {
                    foreach(KeyValuePair<string, CateringItem> kvp in masterListOfItems)
                    {
                        Console.WriteLine($"Code : {kvp.Key} Name : {kvp.Value.Name} Price : {kvp.Value.Price} Quanity : {kvp.Value.NumberOfItems}");
                        //Make this look nicer if we have time also move to another class as a method
                    }
                }
                else if (userOptionInput == "2") //order - takes in sub menu 
                {
                    while (!doneTransaction) // purchase menu loop 
                    {
                        Console.WriteLine("(1) Add money");
                        Console.WriteLine("(2) Select products");
                        Console.WriteLine("(3) Complete transaction");
                        Console.WriteLine("Current account balance: " + catering.Balance);
                        string orderUserInput = Console.ReadLine();

                        if (orderUserInput == "1") // add money
                        {
                            Console.WriteLine("How much money would you like to add?");
                            string moneyDeposit = Console.ReadLine();
                            try
                            {
                            decimal addMoneyToBalance = Decimal.Parse(moneyDeposit);
                                catering.DepositMoney(addMoneyToBalance); //tries to add money
                                logSystem.WriteDepositToFile(catering.Balance, addMoneyToBalance);//writes to log 
                            }
                            catch (FormatException)
                            {

                                Console.WriteLine("Invalid amount of money entered."); //display if they don't type a number that can go into a decimal
                            }
                            
                           
                        }
                        else if (orderUserInput == "2") //select products 
                        {
                            Console.WriteLine("What code would you like to purchase?");
                            string codeToPurchaseInput = Console.ReadLine();
                            Console.WriteLine("What quantity do you need?");
                            string quantity = Console.ReadLine();
                            int numberOfItem = int.Parse(quantity); // need to add protection vs bad parse error
                            //add protection for sold out item , either change order method or something in catering system 
                            catering.Order(numberOfItem, codeToPurchaseInput, masterListOfItems); // trying to order a code , remove from dictionary
                            //write to logfile quantity name and code ordered 
                            

                         }
                        else if (orderUserInput == "3") // complete transaction
                        {
                            //Print list 
                            //make change
                            //return to main menu 
                            doneTransaction = true;
                            //write to logfile give change

                        }
                        else
                        {
                            Console.WriteLine("Sorry, please select option 1, 2, or 3.");
                        }
                    }
                }
                else if (userOptionInput == "3") // quit
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

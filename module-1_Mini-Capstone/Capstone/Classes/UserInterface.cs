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


    {   // below are the fields the UI interacts with
        private CateringSystem catering = new CateringSystem();//creating catering system...still needs to be done
        private FileAccess fileAccess = new FileAccess();//creating fileAccess system
        private Dictionary<string, CateringItem> masterListOfItems = new Dictionary<string, CateringItem>();//creating blank dictionary 
        private LogSystem logSystem = new LogSystem();
        private List<string> shoppingCart = new List<string>();
        private bool shouldRunOuterMenu = true;
        private bool shouldRunOrderMenu = true;

        public void RunMainMenu()
        {

            fileAccess.CateringInventoryRestockFromFile(fileAccess.filePlusPath, masterListOfItems);//fill the dictionary fromCSV
            decimal currentAccountBalance = 0m;


            while (shouldRunOuterMenu) // main menu loop
            {
                shouldRunOrderMenu = true; // allows UI to re-enter ordering menu after exiting
                string userOptionInput = DisplayOuterMenu(); // writes the outer menu choices to console and returns input

                switch (userOptionInput) //display catering item 
                {
                    case "1":  // outer menu choice one prints inventory to screen from dictionary kvp
                        {
                            foreach (KeyValuePair<string, CateringItem> kvp in masterListOfItems) // for each item in catering dictionary
                            {
                                Console.WriteLine($"Code : {kvp.Key} Name : {kvp.Value.Name} Price : {kvp.Value.Price} Quanity : {kvp.Value.NumberOfItems}");  // display each item to screen
                            }
                            break;
                        }

                    case "2":  // purchase menu loop lives inside outer menu 2 (purchase) 
                        {
                            while (shouldRunOrderMenu) // starts the inner purchase menu loop 
                            {
                                string orderUserInput = DisplayOrderMenu();
                                if (orderUserInput == "1") // add money
                                {
                                    Console.WriteLine("How much money would you like to add?");
                                    string moneyDeposit = Console.ReadLine();
                                    try
                                    {
                                        // tries to deposit money if a decimal number was typed otherwise does catch
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
                                    string orderResult = (catering.Order(numberOfItem, codeToPurchaseInput, masterListOfItems, shoppingCart)); // trying to order a code , remove from dictionary
                                    if (orderResult.Contains("COMPLETED"))
                                    {
                                        logSystem.WritePurchaseToFile(numberOfItem, codeToPurchaseInput, masterListOfItems);
                                    }
                                    else Console.WriteLine(orderResult);
                                }

                                else if (orderUserInput == "3") // complete transaction
                                {
                                    shouldRunOrderMenu = false; // this will end the while loop returning to main menu
                                    Console.WriteLine(catering.MakeChange(catering.Balance)); // makes change and returns a string of the change
                                    logSystem.WriteChangeToFile(catering.Balance); // takes remaining balance and records it before we give change below
                                    catering.ResetBalanceToZero();   // adjust balance to zero after change
                                    WriteShoppingCartListToConsole();
                                    Console.WriteLine($"Total Bill : {catering.TotalBill.ToString("C")}");
                                }

                                else // incase menu choices is not 1,2, or 3
                                {
                                    DisplayInncorrectMenuChoice();
                                }
                            }

                            break;
                        }

                    case "3":
                        Console.WriteLine("Thank you for purchasing, have a great day!");
                        shouldRunOuterMenu = false;
                        break;

                    default:    // incase "1" "2" or "3" aren't picked from main menu do this:
                        DisplayInncorrectMenuChoice();
                        break;
                }

            }
        }

        private void WriteShoppingCartListToConsole()
        {
            foreach (string line in shoppingCart) // writes the shopping cart list to console
            {
                Console.WriteLine($"{line}");
            }
        }

        private void DisplayInncorrectMenuChoice()
        {
            Console.WriteLine("Sorry, please select option 1, 2, or 3.");
        }

        private string DisplayOrderMenu()
        {
            Console.WriteLine("(1) Add money");
            Console.WriteLine("(2) Select products");
            Console.WriteLine("(3) Complete transaction");
            Console.WriteLine("Current account balance: " + catering.Balance);
            return Console.ReadLine();
        }

        private string DisplayOuterMenu()
        {
            Console.WriteLine("Yello! Welcome to Josh and Paige's Inventory System!");
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");
            return Console.ReadLine();
        }
    }
}

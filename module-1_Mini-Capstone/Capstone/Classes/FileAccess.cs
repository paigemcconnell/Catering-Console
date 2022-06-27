using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    /// <summary>
    /// This class reads in a | separted CSV file to set initial catering items and prices
    /// </summary>
    public class FileAccess
    {
        private const string DataDirectory = @"C:\Catering";  // location CSV must reside
        private const string CateringFileName = @"cateringsystem.csv";
        public string filePlusPath = Path.Combine(DataDirectory, CateringFileName);  //this combines the Data directory with file name

        public void CateringInventoryRestockFromFile(string DataDirectory, Dictionary<string, CateringItem> masterListOfItems)
        {
            using (StreamReader reader = new StreamReader(filePlusPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();// pulling one line out of CSV
                    string[] fields = line.Split("|");//splitting line base on the pipes into an array of strings
                    decimal priceAsDecimal = Decimal.Parse(fields[3]); //this converts the price string from CSV file to decimal for dictionary

                    // below creates new class of correct type based on ABDE code in first column of CSV and sets the price
                    if (fields[0] == "A") //appetizers
                    {
                        CateringItem newItem = new AppetizerItem(fields[2], priceAsDecimal);
                        masterListOfItems[fields[1]] = newItem;
                    }

                    else if (fields[0] == "B") // beverages
                    {
                        CateringItem newItem = new BeverageItem(fields[2], priceAsDecimal);
                        masterListOfItems[fields[1]] = newItem;
                    }

                    else if (fields[0] == "D") // deserts
                    {
                        CateringItem newItem = new DessertItem(fields[2], priceAsDecimal);
                        masterListOfItems[fields[1]] = newItem;
                    }

                    else if (fields[0] == "E") // entress
                    {
                        CateringItem newItem = new EntreeItem(fields[2], priceAsDecimal);
                        masterListOfItems[fields[1]] = newItem;
                    }
                }
            }
        }

    }
}

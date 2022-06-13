using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain any and all details of access to files
    /// </summary>
    public class FileAccess
    {
        // All external data files for this application should live in this directory.
        // You will likely need to create this directory and copy / paste any needed files.
        private const string DataDirectory = @"C:\Catering";
        
        // These files should be read from / written to in the DataDirectory
<<<<<<< HEAD
        private const string CateringFileName = @"cateringsystem.csv";
        private const string ReportFileName = @"totalsales.txt";

        // only one closs should use stream reader/writer
=======
        private const string CateringFileName = @"cateringsystem.csv"; 
        private const string ReportFileName = @"totalsales.txt"; 
        public string filePlusPath = Path.Combine(DataDirectory, CateringFileName);//this combines the Data directory with file name 

        public void CateringInventoryRestockFromFile(string DataDirectory, Dictionary<string, CateringItem> MasterListOfItems) // need to rename lower case
        {
            using (StreamReader reader = new StreamReader(filePlusPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();// pulling one line out of CSV

                    string[] fields = line.Split("|");//splitting line base on the pipes into an array of strings

                    // make case insensitive ???
                    // replace last else if if else, deal with not all codes return a path
                    decimal priceAsDecimal = Decimal.Parse(fields[3]); //this converts the string from CSV file to decimal for dictionary
                    if (fields[0] == "A")
                    {
                      //  decimal priceAsDecimal = Decimal.Parse(fields[3]);
                        CateringItem newItem = new AppetizerItem(fields[2], priceAsDecimal);
                        MasterListOfItems[fields[1]] = newItem;
                    }
                    else if (fields[0] == "B")
                    {
                        //CateringItem newItem; // as null hint hint 
                        //newItem = new BeverageItem();

                        CateringItem newItem = new BeverageItem(fields[2], priceAsDecimal);
                        MasterListOfItems[fields[1]] = newItem;

                    }
                    else if (fields[0] == "D")
                    {
                        //CateringItem newItem = new DessertItem();

                        CateringItem newItem = new DessertItem(fields[2], priceAsDecimal);
                        MasterListOfItems[fields[1]] = newItem;
                    }
                    else // this takes everything that isn't A,B,D
                    {
                        //CateringItem newItem = new EntreeItem();

                        CateringItem newItem = new EntreeItem(fields[2], priceAsDecimal);
                        MasterListOfItems[fields[1]] = newItem;
                    }








                    // CateringItem newItem = new CateringItem();




                }
            }
        }
>>>>>>> edeeda0a403a788b3c8e0cf004bc270bb859b2e5
    }
}

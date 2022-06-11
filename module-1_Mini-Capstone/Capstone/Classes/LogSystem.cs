using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class LogSystem
    {
        private const string LogDirectory = @"C:\Catering";
        private const string LogFileName = @"Log.txt";
        public string logFile = Path.Combine(LogDirectory, LogFileName);
        private bool shouldAppendToFile = true;
        
        public void WriteDepositToFile(decimal balance, decimal amountToDeposit)
        {
            using (StreamWriter writer = new StreamWriter(logFile, shouldAppendToFile))
            {
                writer.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + (" ADD MONEY: ") + amountToDeposit.ToString("C") + " " + balance.ToString("C"));

            }

        }

        public void WriteChangeToFile(decimal balance)
        {
            using (StreamWriter writer = new StreamWriter(logFile, shouldAppendToFile))
            {
                writer.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + (" GIVE CHANGE: ") + balance.ToString("C") + " " + "$0.00");

            }
        }

        public void WritePurchaseToFile(int quantityPurchased, string code, Dictionary<string, CateringItem> masterListOfItems)
        {
            using (StreamWriter writer = new StreamWriter(logFile, shouldAppendToFile))
            {
                writer.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt" ) + quantityPurchased + " " + masterListOfItems[code].Name + " " + code + " " + masterListOfItems[code].Price + " " + (quantityPurchased * masterListOfItems[code].Price ));

            }
        }
    }
}

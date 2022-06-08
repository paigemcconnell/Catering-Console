using System;
using System.Collections.Generic;
using System.Text;

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
        private const string CateringFileName = @"cateringsystem.csv";
        private const string ReportFileName = @"totalsales.txt";
    }
}

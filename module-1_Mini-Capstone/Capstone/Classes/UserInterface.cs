﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class provides all user communications, but not much else.
    /// All the "work" of the application should be done elsewhere
    /// </summary>
    public class UserInterface

        // only console read/write lines here!!!
    {
        private CateringSystem catering = new CateringSystem();

        public void RunMainMenu()
        {
            bool done = false;

            while (!done)
            {
                Console.WriteLine("Put details of your user interface here");

                Console.ReadLine();
            }
        }
    }
}

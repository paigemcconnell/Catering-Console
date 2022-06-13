﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This represents a single catering item in your system
    /// </summary>
    /// <remarks>
    /// This class MUST be abstract
    /// This class MUST be inherited by at least 2 other classes
    /// Those other classes MUST be used in your program.
    /// </remarks>
    public abstract class CateringItem
    {
<<<<<<< HEAD
        // two things at least should inherit from this, only possible use of inheritance
=======
        // may not need code due to dictionary key having it ?
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int NumberOfItems { get; set; }

        public CateringItem()
        {
            NumberOfItems = 10;
        }

>>>>>>> edeeda0a403a788b3c8e0cf004bc270bb859b2e5
    }
}

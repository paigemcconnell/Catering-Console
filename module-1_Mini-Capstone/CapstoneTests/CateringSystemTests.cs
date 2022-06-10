using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapstoneTests;
using Capstone.Classes;



namespace CapstoneTests
{
    [TestClass]
    public class CateringSystemTests
    {
        [TestMethod]
        public void DepositShouldNotGoOver1000()
        {
            CateringSystem ops = new CateringSystem();

            ops.DepositMoney(1001m); // void method returns nothing

            Assert.AreNotEqual(ops.Balance, 1001M); // checking to it didn't add to balance over 1K

        }
        [TestMethod]
        public void DepositShouldBe5()
        {
            CateringSystem ops = new CateringSystem();

            ops.DepositMoney(5m);

            Assert.AreEqual(ops.Balance, 5M);
        }
    }
}

using NUnit.Framework;
using ConsoleApp1;
using System;

namespace NUnitTest
{
    [TestFixture]
    public class BankAccountTest
    {
        [Test]
        public void BankAccountDepositWithPositiveValue()
        {
            BankAccount bankAccount = new BankAccount(3333);
            Assert.AreEqual(3333, bankAccount.Amount);
        }

        [Test]
        public void CheckNegativeAmountThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(-120));
        }

        [Test]
        public void WithdrawalAmountIsLessThan1000()
        {
            BankAccount bankAccount = new BankAccount(3000);
            bankAccount.Withdraw(800);

            Assert.AreEqual(2160, bankAccount.Amount);
        }
    }
}

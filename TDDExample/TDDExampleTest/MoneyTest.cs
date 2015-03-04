using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDExample;

namespace TDDExampleTest
{
    // Cap. 14
    [TestClass]
    public class MoneyTest
    {
        [TestMethod]
        public void TestMultiplication()
        {
            Money five = Money.dollar(5);
            Assert.AreEqual(Money.dollar(10), five.times(2));
            Assert.AreEqual(Money.dollar(15), five.times(3));
        }

        [TestMethod]
        public void TestFrancMultiplication()
        {
            Money five = Money.franc(5);
            Assert.AreEqual(Money.franc(10), five.times(2));
            Assert.AreEqual(Money.franc(15), five.times(3));
        }

        [TestMethod]
        public void TestEquality()
        {
            Assert.IsTrue(Money.dollar(5).Equals(Money.dollar(5)));
            Assert.IsFalse(Money.dollar(5).Equals(Money.dollar(6)));
            Assert.IsFalse(Money.franc(5).Equals(Money.dollar(5)));
        }

        [TestMethod]
        public void TestCurrency()
        {
            Assert.AreEqual("USD", Money.dollar(1).currency());
            Assert.AreEqual("CHF", Money.franc(1).currency());
        }

        [TestMethod]
        public void TestDifferentClassEquality()
        {
            Assert.IsTrue(new Money(10, "CHF").Equals(Money.franc(10)));
        }

        [TestMethod]
        public void TestSimpleAddition()
        {
            Money five = Money.dollar(5);
            Expression sum = five.plus(five);
            Bank bank = new Bank();
            Money reduced = bank.reduce(sum, "USD");
            Assert.AreEqual(Money.dollar(10), reduced);
        }

        [TestMethod]
        public void TestPlusReturnsSum()
        {
            Money five = Money.dollar(5);
            Expression result = five.plus(five);
            Sum sum = (Sum)result;
            Assert.AreEqual(five, sum.augend);
            Assert.AreEqual(five, sum.addend);
        }

        [TestMethod]
        public void TestReduceSum()
        {
            Expression sum = new Sum(Money.dollar(3), Money.dollar(4));
            Bank bank = new Bank();
            Money result = bank.reduce(sum, "USD");
            Assert.AreEqual(Money.dollar(7), result);
        }

        [TestMethod]
        public void TestReduceMoney()
        {
            Bank bank = new Bank();
            Money result = bank.reduce(Money.dollar(1), "USD");
            Assert.AreEqual(Money.dollar(1), result);
        }

        [TestMethod]
        public void TestIdentityRate()
        {
            Assert.AreEqual(1, new Bank().rate("USD", "USD"));
        }

        [TestMethod]
        public void TestReduceMoneyDifferentCurrency()
        {
            Bank bank = new Bank();
            bank.addRate("CHF", "USD", 2);
            Money result = bank.reduce(Money.franc(2), "USD");
            Assert.AreEqual(Money.dollar(1), result);
        }

        [TestMethod]
        public void TestMixedAddiction()
        {
            Money fiveBucks = Money.dollar(5);
            Money tenFrancs = Money.franc(10);
            Bank bank = new Bank();
            bank.addRate("CHF", "USD", 2);
            Money sum = bank.reduce(fiveBucks.plus(tenFrancs), "USD");
            Assert.AreEqual(Money.dollar(10), sum);
        }

        [TestMethod]
        public void TestSumPlusMoney()
        {
            Money fiveBucks = Money.dollar(5);
            Money tenFrancs = Money.franc(10);
            Bank bank = new Bank();
            bank.addRate("CHF", "USD", 2);
            Expression sum = new Sum(fiveBucks, tenFrancs).plus(fiveBucks);
            Money result = bank.reduce(sum, "USD");
            Assert.AreEqual(Money.dollar(15), result);
        }
    }
}

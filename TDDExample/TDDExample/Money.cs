using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExample
{
    public class Money : Expression
    {
        public int _amount;
        public string _currency;

        public Money(int amount, string currency)
        {
            this._amount = amount;
            this._currency = currency;
        }

        public virtual Expression times(int multiplier)
        {
            return new Money(_amount * multiplier, _currency);
        }

        public string currency()
        {
            return _currency;
        }

        public Expression plus(Expression addend)
        {
            return new Sum(this, addend);
        }

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return _amount == money._amount 
                && this.currency() == money.currency();
        }

        public static Money dollar(int amount)
        {
            return new Dollar(amount, "USD");
        }

        public static Money franc(int amount)
        {
            return new Franc(amount, "CHF");
        }

        public override string ToString()
        {
            return _amount + " " + _currency;
        }

        public Money reduce(Bank bank, string to)
        {
            int rate = bank.rate(_currency, to);
            return new Money(_amount / rate, to);
        }
    }
}

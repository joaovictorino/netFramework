using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDExample
{
    public class Sum : Expression
    {
        public Expression augend;
        public Expression addend;

        public Sum(Expression augend, Expression addend)
        {
            this.augend = augend;
            this.addend = addend;
        }

        public Money reduce(Bank bank, string to)
        {
            int amount = augend.reduce(bank, to)._amount + addend.reduce(bank, to)._amount;
            return new Money(amount, to);
        }

        public Expression plus(Expression addend)
        {
            return new Sum(this, addend);
        }

        public Expression times(int multiplier)
        {
            return new Sum(augend.times(multiplier), addend.times(multiplier));
        }
    }
}

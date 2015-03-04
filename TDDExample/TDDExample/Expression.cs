using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDExample
{
    public interface Expression
    {
        Expression plus(Expression addend);
        Expression times(int multiplier);
        Money reduce(Bank bank, string to);
    }
}

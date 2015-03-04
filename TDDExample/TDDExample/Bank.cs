using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDExample
{
    public class Bank
    {
        Dictionary<Pair, int> rates = new Dictionary<Pair, int>();

        public Money reduce(Expression source, string to)
        {
            return source.reduce(this, to);
        }

        public void addRate(string from, string to, int rate)
        {
            rates.Add(new Pair(from, to), rate);
        }

        public int rate(string from, string to)
        {
            if (from.Equals(to))
                return 1;
            return rates[new Pair(from, to)];
        }
    }
}

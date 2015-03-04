using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDExample
{
    public class Franc : Money
    {
        public Franc(int amount, string currency) : base(amount, currency)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDExample
{
    public class Dollar : Money
    {
        public Dollar(int amount, string currency) : base(amount, currency)
        {
        }
    }
}

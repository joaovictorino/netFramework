using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTest
{
    public class HatesData
    {
        public string Reason { get; set; }

        public HatesData()
        { }

        public HatesData(string reason)
        {
            this.Reason = reason;
        }
    }
}

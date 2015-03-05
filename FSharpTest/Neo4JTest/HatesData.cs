using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neo4JTest
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

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeContracts
{
    [ContractClassFor(typeof(IDenominador))]
    public sealed class IDenominadorContrato : IDenominador
    {
        public int ValorQualquer
        {
            get 
            {
                Contract.Ensures(Contract.Result<int>() > 0);
                return default(int);
            }
        }
    }
}

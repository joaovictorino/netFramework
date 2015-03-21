using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeContracts
{
    [ContractClass(typeof(IDenominadorContrato))]
    public interface IDenominador
    {
        int ValorQualquer { get; }
    }
}

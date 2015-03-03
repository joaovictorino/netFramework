using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeContracts
{
    public class Exemplo
    {
        public void Initialize(string name, int id)
        {
            Contract.Requires(!string.IsNullOrEmpty(name));
            Contract.Requires(id > 0);

            Contract.Ensures(Name == name);
            Contract.Ensures(Id == id);
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}

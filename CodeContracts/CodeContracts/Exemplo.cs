using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeContracts
{
    public class Exemplo : IDenominador
    {
        public int _resultado;
        public int _valorQualquer = 1;

        public void Initialize(string name, int id)
        {
            ValidarString(name);
            Contract.Requires<ArgumentOutOfRangeException>(id > 0);

            Contract.Ensures(Name == name);
            Contract.Ensures(Id == id);
        }

        [ContractAbbreviator]
        public void ValidarString(string name) 
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(name));
        }

        public int Id
        {
            get;
            set;
        }

        public int Valor
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Resultado 
        {
            get 
            {
                Contract.Ensures(Contract.Result<int>() != 0);
                return _resultado;
            }
        }

        [ContractInvariantMethod]
        private void Invariante() 
        {
            Contract.Invariant(Valor > -1);
        }

        public void ReduzirValor()
        {
            Valor = Valor - 2;
        }

        public int ValorQualquer
        {
            get { return _valorQualquer; }
        }

        public int Dividir(int valor1, int valor2)
        {
            Contract.EnsuresOnThrow<DivideByZeroException>(valor2 != 0);
            return valor1 / valor2;        
        }

        public void Lista(List<string> lista) 
        {
            Contract.Requires<IndexOutOfRangeException>(Contract.ForAll(lista, item => item != null));
        }

        public void Saida(out string teste, string valor)
        {
            Contract.Ensures(Contract.ValueAtReturn<string>(out teste) == valor);

            teste = valor;
        }
    }
}

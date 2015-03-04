using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeContracts;

namespace CodeContractTest
{
    [TestClass]
    public class ExemploTest
    {
        [TestMethod]
        public void TestarEnsures()
        {
            Exemplo ex = new Exemplo();
            ex.Name = "teste";
            ex.Id = 1;
            ex.Initialize("teste", 1);
        }
    }
}

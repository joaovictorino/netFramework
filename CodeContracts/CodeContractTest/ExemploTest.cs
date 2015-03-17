using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeContracts;
using System.Diagnostics.Contracts;
using System.Collections.Generic;

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestarRequiresFalhaNull()
        {
            Exemplo ex = new Exemplo();
            ex.Name = "teste";
            ex.Id = 1;
            ex.Initialize(null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestarRequiresFalhaOutOfRange()
        {
            Exemplo ex = new Exemplo();
            ex.Name = "teste";
            ex.Id = 1;
            ex.Initialize("teste", 0);
        }

        [TestMethod]
        public void TestarPropriedadeMaiorQueZero()
        {
            Exemplo ex = new Exemplo();
            ex._resultado = 1;
            Assert.IsTrue(ex.Resultado == 1);
        }

        [TestMethod]
        public void TestarInvarianteMaiorQueZero()
        {
            Exemplo ex = new Exemplo();
            ex.Valor = 2;
            ex.ReduzirValor();
        }

        [TestMethod]
        public void TestarContratoInterfaceMaiorQueZero()
        {
            Exemplo ex = new Exemplo();
            ex._valorQualquer = 1;
            int valor = ex.ValorQualquer;
        }

        [TestMethod]
        public void TestarNaoPermitirDivisaoPorZero()
        {
            Exemplo ex = new Exemplo();
            ex.Dividir(5, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestarElementosNaoNulos()
        {
            List<string> lista = new List<string>() { "teste", "", "teste2", null };
            Exemplo ex = new Exemplo();
            ex.Lista(lista);
        }

        [TestMethod]
        public void TestarParametroOut()
        {
            string valor = "";
            Exemplo ex = new Exemplo();
            ex.Saida(out valor, "saida");
        }
    }
}

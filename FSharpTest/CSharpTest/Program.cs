using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSharpLibrary;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 classe = new Class1();
            int result = classe.addLambda(5, 5);
            Console.WriteLine(classe.X);
            Console.WriteLine(result);
            System.Console.ReadLine();
        }
    }
}

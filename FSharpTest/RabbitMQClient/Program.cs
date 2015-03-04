using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculadoraClient cliente = new CalculadoraClient("AMQPCalculatorService");
            cliente.Send("funfou");
            cliente.Send("funfou 2");
            //Console.WriteLine(cliente.Add(5, 6));
        }
    }
}

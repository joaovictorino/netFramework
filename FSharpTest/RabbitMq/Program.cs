using CSharpLibrary;
using RabbitMQ.Client;
using RabbitMQ.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace RabbitMQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Calculadora));
            //ServiceHost host = new ServiceHost(typeof(Calculadora), new Uri("soap.amqp:///"));
            //host.AddServiceEndpoint(
            //                typeof(ICalculadora),
            //                new RabbitMQBinding("192.168.56.101",
            //                                    5672,
            //                                    "joao",
            //                                    "joao",
            //                                    "/",
            //                                    8192,
            //                                    Protocols.AMQP_0_9_1),
            //                                    "Calculadora");
            host.Open();
        }
    }
}
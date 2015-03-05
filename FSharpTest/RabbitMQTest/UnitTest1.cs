using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMQ.Client;
using System.Collections.Generic;
using RabbitMQ.Client.Events;
using System.Text;
using RabbitMQ.Client.MessagePatterns;

namespace RabbitMQTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = "192.168.56.101";
            connectionFactory.Port = 5672;
            connectionFactory.UserName = "joao";
            connectionFactory.Password = "joao";
            connectionFactory.VirtualHost = "/";

            using (IConnection connection =
                        connectionFactory.CreateConnection())
            {
                using (IModel model = connection.CreateModel())
                {
                    //criar fila
                    model.ExchangeDeclare("MyExchange", ExchangeType.Fanout, true);
                    model.QueueDeclare("MyQueue", true, false, false, new Dictionary<string, object>());
                    model.QueueBind("MyQueue", "MyExchange", "", new Dictionary<string, object>());
                    string message = "Hello!!";

                    //colocar mensagem
                    IBasicProperties basicProperties = model.CreateBasicProperties();
                    model.BasicPublish("MyExchange", "", false, false,
                        basicProperties, Encoding.UTF8.GetBytes(message));

                    //puxar mensagem
                    var subscription = new Subscription(model, "MyQueue", false);
                    while (true)
                    {
                        BasicDeliverEventArgs basicDeliveryEventArgs =
                            subscription.Next();
                        string messageContent =
                            Encoding.UTF8.GetString(basicDeliveryEventArgs.Body);
                        Console.WriteLine(messageContent);
                        subscription.Ack(basicDeliveryEventArgs);
                    }
                }
            }
        }
    }
}

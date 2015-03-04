using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSharpLibrary;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;
using MongoDB.Bson;
using MongoDB.Driver;
using CorrugatedIron;
using CorrugatedIron.Models;
using CorrugatedIron.Models.Search;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Neo4jClient;
using Neo4jClient.Cypher;
using CSharpLibrary;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Class1 classe = new Class1();
            //int result = classe.addLambda(5, 5);
            //Console.WriteLine(classe.X);
            //Console.WriteLine(result);
            //System.Console.ReadLine();

            #region RabbitMQ
            /*var connectionFactory = new ConnectionFactory();
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
            }*/
            #endregion

            #region riak
            /*var cluster = RiakCluster.FromConfig("riakConfig");
            var client = cluster.CreateClient();

            var p = new Person()
            {
                EmailAddress = "oj@buffered.io",
                FirstName = "OJ",
                LastName = "Reeves"
            };

            //var o = new RiakObject("contributors", p.EmailAddress, p);

            //client.Put(o);

            //var search = new RiakFluentSearch("contributors", "firstname").Search(Token.StartsWith("OJ")).Build();
            //RiakResult<IEnumerable<string>> resultado = (RiakResult<IEnumerable<string>>)client.ListBuckets();

            var resultado = client.Get("contributors", "oj@buffered.io");

            if (resultado.IsSuccess)
            {
               var person = resultado.Value.GetObject<Person>();
            }*/

            /*string URI = "https://localhost/TestePost/About";

            using (WebClient wc = new WebClient())
            {
                NameValueCollection values = new NameValueCollection();
                values.Add("teste","teste1");
                byte[] data = wc.UploadValues(URI, "POST", values);
                string resultado = System.Text.Encoding.UTF8.GetString(data);
            }*/

            //Uri address = new Uri("https://localhost/TestePost/About");

            //ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

            //using (WebClient webClient = new WebClient())
            //{
            //    //var stream = webClient.OpenRead(address);
            //    //using (StreamReader sr = new StreamReader(stream))
            //    //{
            //    //    var page = sr.ReadToEnd();
            //    //}

            //    NameValueCollection values = new NameValueCollection();
            //    values.Add("teste", "teste1");
            //    byte[] data = webClient.UploadValues(address, "POST", values);
            //    string resultado = System.Text.Encoding.UTF8.GetString(data);
            //}
            #endregion

            #region neo4j
            // Init
            //var client = new GraphClient(new Uri("http://192.168.56.101:7474/db/data"));
            //client.Connect();

            //// Create entities
            //var refA = client.Create(new Person() { Name = "Person A" });
            //var refB = client.Create(new Person() { Name = "Person B" });
            //var refC = client.Create(new Person() { Name = "Person C" });
            //var refD = client.Create(new Person() { Name = "Person D" });

            //// Create relationships
            //client.CreateRelationship(refA, new KnowsRelationship(refB));
            //client.CreateRelationship(refB, new KnowsRelationship(refC));
            //client.CreateRelationship(refB, new HatesRelationship(refD, new HatesData("Crazy guy")));
            //client.CreateRelationship(refC, new HatesRelationship(refD, new HatesData("Don't know why...")));
            //client.CreateRelationship(refD, new KnowsRelationship(refA));

            //var query = new Neo4jClient.Cypher.CypherQuery(
            //                "start n=node(8) match n<-[r:HATES]-e return e.Name as Name;",
            //                new Dictionary<string, object>(),
            //                CypherResultMode.Projection);

            //var result = client.ExecuteGetCypherResults<Person>(query);

            //var query = client
            //            .Cypher
            //            .Match("(n { Name:'Person A' })-[r:KNOWS]->e")
            //            .Return(e => new { e.As<Person>().Name });

            //foreach (var p in query.Results) 
            //{
            //    Console.WriteLine(p.Name);
            //}

            //Console.Read();
            #endregion

            Calculadora calc = new Calculadora();
            calc.Send("teste mongodb");
            Console.ReadKey();

        }

        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (error == System.Net.Security.SslPolicyErrors.None)
            {
                return true;
            }

            Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
                cert.Subject,
                error.ToString());

            return true;
        }
    }
}

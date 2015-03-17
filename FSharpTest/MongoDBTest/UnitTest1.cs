using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;

namespace MongoDBTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        public void Send(string teste)
        {
            //Console.WriteLine(teste);

            var connectionString = "mongodb://192.168.56.101";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("test");
            var collection = database.GetCollection<Entity>("entities");
            collection.RemoveAll();
            var entity = new Entity
            {
                Name = teste
            };
            collection.Insert(entity);
            MongoCursor<Entity> lista = collection.FindAll();
            foreach (Entity entidade in lista)
            {
                Console.WriteLine(entidade.Name);
            }
            var id = entity.Id;
        }
    }
}

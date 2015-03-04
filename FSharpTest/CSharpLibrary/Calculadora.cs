using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpLibrary
{
    public sealed class Calculadora : ICalculadora
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Subtract(int x, int y)
        {
            return x - y;
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
            var entity = new Entity { Name = teste };
            collection.Insert(entity);
            MongoCursor<Entity> lista = collection.FindAll();
            foreach (Entity entidade in lista) 
            {
                Console.WriteLine(entidade.Name);
            }
            var id = entity.Id;
        }
    }

    public class Entity
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }
    }
}
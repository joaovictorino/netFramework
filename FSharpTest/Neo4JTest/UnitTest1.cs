using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neo4jClient;
using System.Collections.Generic;
using Neo4jClient.Cypher;

namespace Neo4JTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Init
            var client = new GraphClient(new Uri("http://192.168.56.101:7474/db/data"));
            client.Connect();

            // Create entities
            var refA = client.Create(new Person() { Name = "Person A" });
            var refB = client.Create(new Person() { Name = "Person B" });
            var refC = client.Create(new Person() { Name = "Person C" });
            var refD = client.Create(new Person() { Name = "Person D" });

            // Create relationships
            client.CreateRelationship(refA, new KnowsRelationship(refB));
            client.CreateRelationship(refB, new KnowsRelationship(refC));
            client.CreateRelationship(refB, new HatesRelationship(refD, new HatesData("Crazy guy")));
            client.CreateRelationship(refC, new HatesRelationship(refD, new HatesData("Don't know why...")));
            client.CreateRelationship(refD, new KnowsRelationship(refA));

            var query = new Neo4jClient.Cypher.CypherQuery(
                            "start n=node(8) match n<-[r:HATES]-e return e.Name as Name;",
                            new Dictionary<string, object>(),
                            CypherResultMode.Projection);

            //var result = client.ExecuteGetCypherResults<Person>(query);

            var query2 = client
                        .Cypher
                        .Match("(n { Name:'Person A' })-[r:KNOWS]->e")
                        .Return(e => new { e.As<Person>().Name });

            foreach (var p in query2.Results) 
            {
                Console.WriteLine(p.Name);
            }

            Console.Read();
        }
    }
}

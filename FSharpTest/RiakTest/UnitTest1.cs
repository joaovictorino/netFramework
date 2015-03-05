using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorrugatedIron;
using CorrugatedIron.Models;
using CorrugatedIron.Models.Search;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace RiakTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            #region riak
            var cluster = RiakCluster.FromConfig("riakConfig");
            var client = cluster.CreateClient();

            var p = new Person()
            {
                EmailAddress = "oj@buffered.io",
                FirstName = "OJ",
                LastName = "Reeves"
            };

            var o = new RiakObject("contributors", p.EmailAddress, p);

            client.Put(o);

            var search = new RiakFluentSearch("contributors", "firstname").Search(Token.StartsWith("OJ")).Build();
            RiakResult<IEnumerable<string>> resultado = (RiakResult<IEnumerable<string>>)client.ListBuckets();

            var resultado2 = client.Get("contributors", "oj@buffered.io");

            if (resultado2.IsSuccess)
            {
               var person = resultado2.Value.GetObject<Person>();
            }

            string URI = "https://localhost/TestePost/About";

            using (WebClient wc = new WebClient())
            {
                NameValueCollection values = new NameValueCollection();
                values.Add("teste","teste1");
                byte[] data = wc.UploadValues(URI, "POST", values);
                string resultado3 = System.Text.Encoding.UTF8.GetString(data);
            }

            Uri address = new Uri("https://localhost/TestePost/About");

            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

            using (WebClient webClient = new WebClient())
            {
                //var stream = webClient.OpenRead(address);
                //using (StreamReader sr = new StreamReader(stream))
                //{
                //    var page = sr.ReadToEnd();
                //}

                NameValueCollection values = new NameValueCollection();
                values.Add("teste", "teste1");
                byte[] data = webClient.UploadValues(address, "POST", values);
                string resultado4 = System.Text.Encoding.UTF8.GetString(data);
            }
            #endregion
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

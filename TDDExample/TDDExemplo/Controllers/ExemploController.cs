using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TDDExemplo.Controllers
{
    public class ExemploController : ApiController
    {
        // GET: api/Exemplo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Exemplo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Exemplo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Exemplo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Exemplo/5
        public void Delete(int id)
        {
        }
    }
}

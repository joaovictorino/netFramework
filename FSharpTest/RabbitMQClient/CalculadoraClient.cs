using RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQClient
{
    class CalculadoraClient : ClientBase<ICalculadora>, ICalculadora
    {
        public CalculadoraClient(string configurationName)
            : base(configurationName) { }

        public int Add(int x, int y)
        {
            return this.Channel.Add(x, y);
        }

        public int Subtract(int x, int y)
        {
            return this.Channel.Subtract(x, y);
        }

        public void Send(string teste)
        {
            this.Channel.Send(teste);
        }
    }
}

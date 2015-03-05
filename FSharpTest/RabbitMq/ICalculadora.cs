using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace RabbitMQ
{
    [ServiceContract]
    public interface ICalculadora
    {
        [OperationContract]
        int Add(int x, int y);
        [OperationContract]
        int Subtract(int x, int y);

        [OperationContract(IsOneWay = true)]
        void Send(string teste);
    }

}
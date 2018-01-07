using Biblioteek.Types;
using System;

namespace Biblioteek.Exceptions
{
    public class MissingService : Exception
    {
        public MissingService(ServiceName serviceName)
            : base()
        {
            ServiceName = serviceName;
            Message = $"Service of type [{ServiceName.Name}] could not be found";
        }

        public override string Message { get; }

        public ServiceName ServiceName { get; }
    }
}
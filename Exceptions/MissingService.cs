using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteek.Types;

namespace Biblioteek.Exceptions
{
    public class MissingService : Exception
    {
        public MissingService(ServiceName serviceName)
            :base()
        {
            ServiceName = serviceName;
            Message = $"Service of type [{ServiceName.Name}] could not be found";
        }

        public override string Message { get; }

        public ServiceName ServiceName { get; }
    }
}

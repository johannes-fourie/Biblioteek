using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteek.Types
{
    public class ServiceName
    {
        public ServiceName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("ServiceName.Name", "Service name cannot be null, empty or white space");

            Name = name;
        }

        public string Name { get; }

        public static ServiceName New(string name)
        {
            return new ServiceName(name);
        }
    }

    public static class ServiceNameExtentions
    {
        public static ServiceName ServiceName(this string serviceName)
        {
            return new Types.ServiceName(serviceName);
        }

        public static ServiceName ServiceName(this Type serviceType)
        {
            return new Types.ServiceName(serviceType.FullName);
        }
    }
}

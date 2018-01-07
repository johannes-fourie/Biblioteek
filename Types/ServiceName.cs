using System;

namespace Biblioteek.Types
{
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
}
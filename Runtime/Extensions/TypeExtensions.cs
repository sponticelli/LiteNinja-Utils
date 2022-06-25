using System;
using System.Linq;

namespace LiteNinja.Utils.Extensions
{
    public static class TypeExtensions
    {
        public static bool ImplementsInterface(this Type self, Type interfaceType)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            if (interfaceType == null)
                throw new ArgumentNullException(nameof(interfaceType));

            var interfaces = self.GetInterfaces();
            if (interfaceType.IsGenericTypeDefinition)
            {
                return interfaces.Any(item =>
                    item.IsConstructedGenericType && item.GetGenericTypeDefinition() == interfaceType);
            }

            return interfaces.Any(item => item == interfaceType);
        }
    }
}
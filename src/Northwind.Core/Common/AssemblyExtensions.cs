using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Northwind.Core.Common
{
    public static class AssemblyExtensions
    {
        public static List<Item> GetAllTypesImplementingInterface(this Assembly assembly, Type theInterface)
        {
            var result = new List<Item>();

            var types = assembly.GetExportedTypes();
            foreach (var type in types)
            {
                result.AddRange(type.GetAllTypesImplementingInterface(theInterface));
            }

            return result;
        }

        private static IEnumerable<Item> GetAllTypesImplementingInterface(this Type type, Type theInterface)
        {
            return
                type.GetInterfaces()
                    .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == theInterface)
                    .Select(x => new Item
                        {
                            ConcreteType = type,
                            Interface = x,
                            GenericArgument = x.GetGenericArguments()[0]
                        })
                    .ToList();
        }

        public class Item
        {
            public Type ConcreteType { get; set; }

            public Type Interface { get; set; }

            public Type GenericArgument { get; set; }
        }
    }
}
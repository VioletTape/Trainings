using System;
using System.Linq;
using Infrastructure.QueryBuilders;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using VioletTape.Omnibus;

namespace Application.StructureMapScanners {
    internal class AutoRegistryQueryBuilderScanner : IRegistrationConvention {
        public void Process(Type type, Registry registry) {
            if (type.IsGenericType) return;

            var interfaces = type.GetInterfaces();

            if (interfaces.Any()) {
                var directInterface = interfaces.FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition().Name == typeof (IQueryBuilder<,>).Name);
                if (directInterface.IsNotNull())
                    registry.AddType(directInterface, type);
            }
        }
    }
}
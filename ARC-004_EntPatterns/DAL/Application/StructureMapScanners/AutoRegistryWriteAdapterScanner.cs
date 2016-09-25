using System;
using System.Linq;
using Infrastructure.Adapters.Base;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using VioletTape.Omnibus;

namespace Application.StructureMapScanners {
    internal class AutoRegistryWriteAdapterScanner : IRegistrationConvention {
        public void Process(Type type, Registry registry) {
            if (type.IsGenericType) return;

            var interfaces = type.GetInterfaces();

            if (interfaces.Any()) {
                var directInterface = interfaces.FirstOrDefault(i => i.Name == typeof (IWriteAdapter).Name);

                if (directInterface.IsNotNull())
                    registry.AddType(typeof (IWriteAdapter), type);
            }
        }
    }
}
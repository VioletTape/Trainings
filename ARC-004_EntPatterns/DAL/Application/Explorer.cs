using Application.StructureMapScanners;
using Domain;
using Infrastructure;
using StructureMap;

namespace Application {
    public class Explorer {
        public void RegisterAll() {
            RegisterAdapters();
            RegisterFacade();
        }

        public void RegisterAdapters() {
            var adapterScanner = new AutoRegistryAdapterScanner();
            ObjectFactory.Configure(x => x.Scan(s => {
                                                    s.Assembly("Infrastructure");
                                                    s.With(adapterScanner);
                                                }));

            var writeAdapterScanner = new AutoRegistryWriteAdapterScanner();
            ObjectFactory.Configure(x => x.Scan(s => {
                                                    s.Assembly("Infrastructure");
                                                    s.With(writeAdapterScanner);
                                                }));

            var queryBuilderScanner = new AutoRegistryQueryBuilderScanner();
             ObjectFactory.Configure(x => x.Scan(s => {
                                                    s.Assembly("Infrastructure");
                                                    s.With(queryBuilderScanner);
                                                }));
        }

        public void RegisterQueryBuilders() {}

        public void RegisterFacade() {
            ObjectFactory.Configure(x => x.For<IInfrastructureFacade>().Use<InfrastructureFacade>());
        }
    }
}
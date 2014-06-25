using System;
using System.Collections.Generic;
using Installation_v2.InstallationLogic.Interfaces;

namespace Tests.Fakes {
    public class ServiceLocatorFake : IServiceLocator {
        private readonly Dictionary<Type, IService> services = new Dictionary<Type, IService>();


        public ServiceLocatorFake() {
            Register<IRequirementService>(new RequirementServiceFake());
            Register<IInstallEnvironment>(new InstallEnvironmentFake());
            Register<IFileService>(new FileServiceFake());
            Register<IInstallService>(new InstallServiceFake());
            Register<ISqlUpdateService>(new SqlUpdateServiceFake());
            Register<IRegistryService>(new RegistryServiceFake());
            Register<IRequirementManager>(new RequirementManagerFake());
            Register<ILogService>(new LogServiceFake());

            foreach (var pair in services) {
                pair.Value.InitService(this);
            }
        }

        private void Register<T>(IService service) {
            if (services.ContainsKey(typeof (T))) return;
            services[typeof (T)] = service;
        }

        public T Get<T>() {
            return (T) services[typeof (T)];
        }
    }
}
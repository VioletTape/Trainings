using System;
using System.Collections.Generic;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.InstallationLogic.Services;

namespace Installation_v2.InstallationLogic {
    public class ServiceLocator : IServiceLocator {
        private readonly Dictionary<Type, IService> services = new Dictionary<Type, IService>();


        public ServiceLocator() {
            Register<IRequirementService>(new RequirementService());
            Register<IInstallEnvironment>(new InstallEnvironment());
            Register<IFileService>(new FileService());
            Register<IRegistryService>(new RegistryService());
            Register<IInstallService>(new InstallService());
            Register<ISqlUpdateService>(new SqlUpdateService());
            Register<IRequirementManager>(new RequirementManager());
            Register<ILogService>(new LogService());

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
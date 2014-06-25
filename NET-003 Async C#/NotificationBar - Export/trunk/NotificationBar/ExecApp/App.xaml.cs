using System.Windows;
using Domain;
using NotificationBarLib.Core;
using StructureMap;

namespace ExecApp {
    public partial class App : Application {
        public App() {
            ObjectFactory.Configure(x => {
                                        x.For<INotificationManager>().Singleton().Use<NotificationManager>();
                                        x.For<IImportantService>().Use<ImportantService>();
                                    });
        }
    }
}
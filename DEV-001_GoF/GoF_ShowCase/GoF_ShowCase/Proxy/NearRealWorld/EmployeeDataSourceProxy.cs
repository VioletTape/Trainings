using System;
using System.Collections.Concurrent;

namespace GoF_ShowCase.Proxy.NearRealWorld {
    public class EmployeeDataSourceProxy : IEmployeeDataSource {
        private static readonly Lazy<EmployeeDataSourceProxy> instance =
            new Lazy<EmployeeDataSourceProxy>(() => new EmployeeDataSourceProxy());

        public static EmployeeDataSourceProxy Instance {
            get { return instance.Value; }
        }

        private EmployeeDataSourceProxy() {
            Console.WriteLine("EmployeeDataSourceProxy ctor...");
        }


        private readonly IEmployeeDataSource dataSource = new EmployeeDataSource();

        // появляется кэш в прокси
        private static readonly ConcurrentDictionary<int, EmployeeInfo> cache
            = new ConcurrentDictionary<int, EmployeeInfo>();

        public EmployeeInfo GetEmployeeInfo(int id) {
            return cache.GetOrAdd(id, dataSource.GetEmployeeInfo);
        }

        public void SetEmployeeInfo(EmployeeInfo employieInfo) {
            dataSource.SetEmployeeInfo(employieInfo);

            cache.AddOrUpdate(employieInfo.Id,
                              employieInfo, (key, value) => employieInfo);
        }
    }
}
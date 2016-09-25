using System;
using System.Collections.Concurrent;
using System.Threading;

namespace GoF_ShowCase.Proxy.NearRealWorld {
    public class EmployeeDataSource : IEmployeeDataSource {
        private static readonly ConcurrentDictionary<int, EmployeeInfo> database
            = new ConcurrentDictionary<int, EmployeeInfo>();

        public EmployeeDataSource() {
            Console.WriteLine("EmployeeDataSource ctor ... ");
        }

        public EmployeeInfo GetEmployeeInfo(int id) {
            Console.WriteLine("Loading {0} from DB... ", id);
            Thread.Sleep(1000);

            return database.GetOrAdd(id, CreateNewEmployee);
        }

        public void SetEmployeeInfo(EmployeeInfo employeeInfo) {
            Console.WriteLine("Saving ({0}, {1}) to DB... ",
                              employeeInfo.Id, employeeInfo.FullName);

            database.AddOrUpdate(employeeInfo.Id,
                                  employeeInfo, (key, value) => employeeInfo);
        }

        private EmployeeInfo CreateNewEmployee(int id) {
            return new EmployeeInfo {
                Id = id,
                FullName = "[NoName]"
            };
        }
    }
}
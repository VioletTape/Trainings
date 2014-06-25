using System;

namespace GoF_ShowCase.Proxy.NearRealWorld {
    public class Example {
        public void ShowEmployeeInfo(int id, IEmployeeDataSource dataSource) {
            var employeeInfo = dataSource.GetEmployeeInfo(id);
            Console.WriteLine("Employee id = {0}", employeeInfo.Id);
            Console.WriteLine("Employee name = {0}\n", employeeInfo.FullName);
        }

        public static void SetEmployeeName(int id, string fullName, IEmployeeDataSource dataSource) {
            var employeeInfo = dataSource.GetEmployeeInfo(id);
            employeeInfo.FullName = fullName;
            dataSource.SetEmployeeInfo(employeeInfo);
        }

        public void Main() {
            var dataSource = DataSourceFactory.CreateEmployeeDataSource();

            ShowEmployeeInfo(11, dataSource);
            ShowEmployeeInfo(12, dataSource);

            SetEmployeeName(11, "Employee 1 name", dataSource);
            SetEmployeeName(12, "Employee 2 name", dataSource);

            ShowEmployeeInfo(11, dataSource);
            ShowEmployeeInfo(12, dataSource);

            Console.WriteLine("\nDone ...");
            Console.ReadKey(true);
        }
    }
}
namespace GoF_ShowCase.Proxy.NearRealWorld {
    public interface IEmployeeDataSource {
        EmployeeInfo GetEmployeeInfo(int id);

        void SetEmployeeInfo(EmployeeInfo employeeInfo);
    }
}
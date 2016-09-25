namespace GoF_ShowCase.Proxy.NearRealWorld {
    public static class DataSourceFactory {
        public static IEmployeeDataSource CreateEmployeeDataSource() {
            return new EmployeeDataSource();
        }
    }

//    public static class DataSourceFactory {
//        public static IEmployeeDataSource CreateEmployeeDataSource() {
//            return EmployeeDataSourceProxy.Instance;
//        }
//    }
}
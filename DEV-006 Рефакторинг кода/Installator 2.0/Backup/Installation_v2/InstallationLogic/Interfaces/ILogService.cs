namespace Installation_v2.InstallationLogic.Interfaces {
    public interface ILogService : IService {
        void CreateLogFile(string fileName);
        void WriteToLog(string messageLine);
        void PrintDelimeter();
        void CloseFile();
    }
}
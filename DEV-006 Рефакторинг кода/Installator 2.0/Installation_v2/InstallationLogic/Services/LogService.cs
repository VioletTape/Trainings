using System;
using System.IO;
using Installation_v2.InstallationLogic.Interfaces;

namespace Installation_v2.InstallationLogic.Services {
    public class LogService : BaseService, ILogService {
        private IFileService fileService;
        private StreamWriter file;

        public new void InitService(IServiceLocator serviceLocator) {
            fileService = serviceLocator.Get<IFileService>();
        }

        public void CreateLogFile(string fileName) {
            file = fileService.CreateLogFile(fileName);
        }

        public void WriteToLog(string messageLine) {
            file.WriteLine(messageLine);
            file.Flush();
        }

        public void PrintDelimeter() {
            WriteToLog("");
            WriteToLog("****************************************************************************************");
            WriteToLog("");
        }

        public void CloseFile() {
            file.Close();
        }
    }
}
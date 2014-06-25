using System.IO;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.InstallationLogic.Services;

namespace Tests.Fakes {
    public class FileServiceFake : BaseService, IFileService {
        public void InitService(ServiceLocator serviceLocator) {}


        public Result CreateDirectory(string path, InstallFileAccess fileAccess) {
            return new Result();
        }

        public Result ExtractCabResult { get; set; }

        public Result ExtractCab(string sourcePath, string cabName, string destination) {
            return ExtractCabResult ?? new Result {OperationResult = OperationResult.Succed};
        }

        public string RequirementSourcePath(Requirement requirement) {
            return "";
        }

        public string InstallPath(InstallReq installReq) {
            return "";
        }

        public bool FileExists(string path) {
            return true;
        }

        public bool FileExists(string path, string fileName) {
            return true;
        }

        public Result CopyFile(string source, string destination, string file, InstallFileAccess fileAccess) {
            return new Result();
        }

        public Result RewriteFile(string source, string destination, string file, InstallFileAccess fileAccess) {
            return new Result();
        }

        public Result DeleteFile(string path, string file) {
            return new Result();
        }

        public Result DeleteDirectory(string path) {
            return new Result();
        }

        public StreamWriter CreateLogFile(string path) {
            return new StreamWriter("");
        }
    }
}
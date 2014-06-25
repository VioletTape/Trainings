using System;
using System.IO;
using System.Security.AccessControl;
using CabLib;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;

namespace Installation_v2.InstallationLogic.Services {
    public class FileService : BaseService, IFileService {
        private IInstallEnvironment environment;
        private readonly Extract extractManager;
        private ILogService log;


        public FileService() {
            extractManager = new Extract();
        }

        public new void InitService(IServiceLocator serviceLocator) {
            environment = serviceLocator.Get<IInstallEnvironment>();
            log = serviceLocator.Get<ILogService>();
        }

        public string InstallPath(InstallReq installReq) {
            return
                installReq.Destination == null
                    ? environment.InstallPath
                    : Path.Combine(environment.InstallPath, installReq.Destination);
        }


        public bool FileExists(string path) {
            return File.Exists(path);
        }

        public bool FileExists(string path, string fileName) {
            path = Path.Combine(path, fileName);
            return File.Exists(path);
        }


        public Result CopyFile(string source, string destination, string file, InstallFileAccess fileAccess) {
            var result = new Result {OperationResult = OperationResult.Succed};

            source = Path.Combine(source, file);
            destination = Path.Combine(destination, file);

            if (File.Exists(destination)) {
                log.WriteToLog(string.Format("Copy >> {0}... Exist", destination));
                return result;
            }

            if (!File.Exists(source)) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = new Exception("Не могу найти файл " + source);
                log.WriteToLog(string.Format("Copy >> {0}... Failed", destination));
                log.WriteToLog(result.ErrorText);
                return result;
            }

            try {
                File.Copy(source, destination);
                SetFileSecurity(destination, fileAccess);
                log.WriteToLog(string.Format("Copy >> {0}... OK", destination));
            }
            catch (Exception e) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = e;
                log.WriteToLog(string.Format("Copy >> {0}... Failed", destination));
                log.WriteToLog(result.ErrorText);
            }

            return result;
        }

        public Result RewriteFile(string source, string destination, string file, InstallFileAccess fileAccess) {
            var result = new Result {OperationResult = OperationResult.Succed};

            source = Path.Combine(source, file);
            destination = Path.Combine(destination, file);

            if (!File.Exists(source)) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = new Exception("Не могу найти файл " + source);
                log.WriteToLog(string.Format("Rewrite >> {0}... Failed", destination));
                return result;
            }

            try {
                File.Delete(destination);
                File.Copy(source, destination, true);
                SetFileSecurity(destination, fileAccess);
                log.WriteToLog(string.Format("Rewrite >> {0}... OK", destination));
            }
            catch (Exception e) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = e;
                log.WriteToLog(string.Format("Rewrite >> {0}... Failed", destination));
                log.WriteToLog(result.ErrorText);
            }

            return result;
        }

        public Result DeleteFile(string path, string file) {
            var result = new Result {OperationResult = OperationResult.Succed};

            path = Path.Combine(path, file);

            if (!File.Exists(path)) {
                log.WriteToLog(string.Format("Delete >> {0}... OK Deleted already", path));
                return result;
            }

            try {
                File.Delete(path);
                log.WriteToLog(string.Format("Delete >> {0}... OK", path));
            }
            catch (Exception e) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = e;
                log.WriteToLog(string.Format("Delete >> {0}... Failed", path));
                log.WriteToLog(result.ErrorText);
            }

            return result;
        }

        public Result DeleteDirectory(string path) {
            var result = new Result {OperationResult = OperationResult.Succed};

            if (!Directory.Exists(path)) {
                log.WriteToLog(string.Format("Delete >> {0}... OK Deleted already", path));
                return result;
            }

//            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
//            for (var i = 0; i < files.Length; i++) {
//                File.Delete(files[i]);
//            }
            try {
                Directory.Delete(path, true);
                log.WriteToLog(string.Format("Delete >> {0}... OK", path));
            }
            catch (Exception e) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = e;
                log.WriteToLog(string.Format("Delete >> {0}... Failed", path));
                log.WriteToLog(result.ErrorText);
            }

            return result;
        }

        public StreamWriter CreateLogFile(string path) {
            var variable = Environment.GetEnvironmentVariable("Temp");
            var combine = Path.Combine(variable, path);
            return File.CreateText(combine);
        }


        public Result CreateDirectory(string path, InstallFileAccess fileAccess) {
            var result = new Result {OperationResult = OperationResult.Succed};

            if (Directory.Exists(path)) {
                log.WriteToLog(string.Format("CreDir >> {0}... OK Already Exists", path));
                return result;
            }
            try {
                Directory.CreateDirectory(path);
                SetFolderSecurity(path, fileAccess);
                log.WriteToLog(string.Format("CreDir >> {0}... OK", path));
            }
            catch (Exception e) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = e;
                log.WriteToLog(string.Format("CreDir >> {0}... Failed", path));
                log.WriteToLog(result.ErrorText);
            }

            return result;
        }

        public Result ExtractCab(string sourcePath, string cabName, string destination) {
            var result = new Result {OperationResult = OperationResult.Succed};

            var source = Path.Combine(sourcePath, cabName);
            try {
                extractManager.ExtractFile(source, destination);
                log.WriteToLog(string.Format("CabExtract >> {0}... OK", source));
            }
            catch (Exception e) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = e;
                log.WriteToLog(string.Format("CabExtract >> {0}... Failed", source));
                log.WriteToLog(result.ErrorText);
            }

            return result;
        }

        public string RequirementSourcePath(Requirement requirement) {
            var path = string.Format("{0}{1}\\{2}",
                                     environment.ExtractPath,
                                     requirement.SystemType == SystemType.Any
                                         ? GetSpecialPath(SystemType.Any)
                                         : GetSpecialPath(requirement.SystemType),
                                     requirement.SystemFile
                );
            return path;
        }

        private static string GetSpecialPath(SystemType systemType) {
            switch (systemType) {
                case SystemType.x64:
                    return "\\x64";
                case SystemType.x86:
                    return "\\x86";
            }
            return "";
        }


        private void SetFileSecurity(string file, InstallFileAccess fileAccess) {
            if (fileAccess == InstallFileAccess.Programm) return;
            try {
                var security = new FileSecurity(file, AccessControlSections.All);
                security.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
                File.SetAccessControl(file, security);
                log.WriteToLog(string.Format("FileSec >> {0} {1}... OK", file, fileAccess));
            }
            catch (Exception e) {
                log.WriteToLog(string.Format("FileSec >> {0} {1}... Failed", file, fileAccess));
                log.WriteToLog(e.Message);
            }
        }

        private void SetFolderSecurity(string path, InstallFileAccess fileAccess) {
            var info = new DirectoryInfo(path);
            if (fileAccess == InstallFileAccess.Programm) return;

            try {
                var security = new DirectorySecurity(path, AccessControlSections.All);
                security.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl,
                                                                InheritanceFlags.ObjectInherit |
                                                                InheritanceFlags.ContainerInherit,
                                                                PropagationFlags.InheritOnly, AccessControlType.Allow));
                info.SetAccessControl(security);
                log.WriteToLog(string.Format("FolderSec >> {0} {1}... OK", path, fileAccess));
            }
            catch (Exception e) {
                log.WriteToLog(string.Format("FolderSec >> {0} {1}... Failed", path, fileAccess));
                log.WriteToLog(e.Message);
            }
        }
    }
}
using System;
using System.Diagnostics;
using System.IO;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using IWshRuntimeLibrary;

namespace Installation_v2.InstallationLogic.Services {
    public class InstallService : BaseService, IInstallService {
        private IFileService fileService;
        private IInstallEnvironment environment;
        private IRegistryService registryService;
        private ISqlUpdateService sqlService;
        private ILogService log;


        public new void InitService(IServiceLocator serviceLocator) {
            fileService = serviceLocator.Get<IFileService>();
            registryService = serviceLocator.Get<IRegistryService>();
            environment = serviceLocator.Get<IInstallEnvironment>();
            sqlService = serviceLocator.Get<ISqlUpdateService>();
            log = serviceLocator.Get<ILogService>();
        }


        public Result InstallMain(InstallReq installReq) {
            var result = new Result {OperationResult = OperationResult.Succed};

            switch (installReq.InstallReqType) {
                case InstallReqType.File:
                    return InstallMainFile(installReq);
                case InstallReqType.Registry:
                    return InstallMainRegistry(installReq);
                case InstallReqType.Script:
                    return InstallMainScript(installReq);
                case InstallReqType.Directory:
                    return InstallMainDirectory(installReq);
            }
            return result;
        }

        private Result InstallMainScript(InstallReq req) {
            var result = sqlService.ConnectCE(environment.InstallPath, req.Destination);

            if (result.OperationResult == OperationResult.Failed) {
                log.WriteToLog(result.ErrorText);
                return result;
            }

            TotalActionNumberInStep = req.Keys.Count;
            ActionNumberInStep = 1;

            log.WriteToLog(string.Format("Install {0}...", req.Title));

            for (var i = 0; i < req.Keys.Count; i++, ActionNumberInStep++) {
                result = sqlService.Execute(req.Keys[i]);
                StepReport(ServiceStateReport);
                if (result.OperationResult == OperationResult.Failed) {
                    log.WriteToLog(result.ErrorText);
                    return result;
                }
                log.WriteToLog(string.Format("Script {0}... OK", i));
            }
            log.WriteToLog(string.Format("Install {0}... OK", req.Title));

            return result;
        }

        private Result InstallMainRegistry(InstallReq req) {
            var result = new Result {OperationResult = OperationResult.Succed};

            TotalActionNumberInStep = req.Keys.Count;
            ActionNumberInStep = 1;

            switch (req.FileAction) {
                case FileAction.CreateIfNotExists:
                    for (var i = 0; i < req.Keys.Count; i++, ActionNumberInStep++) {
                        result = registryService.CreateKeyValues(req.Destination, req.Keys[i]);
                        StepReport(ServiceStateReport);
                        if (result.OperationResult == OperationResult.Failed)
                            return result;
                    }
                    break;
                case FileAction.Rewrite:
                    for (var i = 0; i < req.Keys.Count; i++, ActionNumberInStep++) {
                        result = registryService.RewriteKeyValues(req.Destination, req.Keys[i]);
                        StepReport(ServiceStateReport);
                        if (result.OperationResult == OperationResult.Failed)
                            return result;
                    }
                    break;
                case FileAction.Delete:
                    for (var i = 0; i < req.Keys.Count; i++, ActionNumberInStep++) {
                        result = registryService.DeleteKeyValues(req.Destination);
                        StepReport(ServiceStateReport);
                        if (result.OperationResult == OperationResult.Failed)
                            return result;
                    }
                    break;
            }

            return result;
        }

        private Result InstallMainFile(InstallReq req) {
            var result = new Result {OperationResult = OperationResult.Succed};

            var destination = fileService.InstallPath(req);

            fileService.CreateDirectory(destination, InstallFileAccess.All);

            TotalActionNumberInStep = req.Keys.Count;
            ActionNumberInStep = 1;

            switch (req.FileAction) {
                case FileAction.CreateIfNotExists:
                    for (var i = 0; i < req.Keys.Count; i++, ActionNumberInStep++) {
                        result = fileService.CopyFile(environment.ExtractPath, destination, req.Keys[i],
                                                      InstallFileAccess.All);
                        StepReport(ServiceStateReport);
                        if (result.OperationResult == OperationResult.Failed)
                            return result;
                    }
                    break;
                case FileAction.Rewrite:
                    for (var i = 0; i < req.Keys.Count; i++, ActionNumberInStep++) {
                        result = fileService.RewriteFile(environment.ExtractPath, destination, req.Keys[i],
                                                         InstallFileAccess.All);
                        StepReport(ServiceStateReport);
                        if (result.OperationResult == OperationResult.Failed)
                            return result;
                    }
                    break;
                case FileAction.Delete:
                    for (var i = 0; i < req.Keys.Count; i++, ActionNumberInStep++) {
                        result = fileService.DeleteFile(destination, req.Keys[i]);
                        StepReport(ServiceStateReport);
                        if (result.OperationResult == OperationResult.Failed)
                            return result;
                    }
                    break;
            }

            return result;
        }

        private Result InstallMainDirectory(InstallReq req) {
            var result = new Result {OperationResult = OperationResult.Succed};

            for (var i = 0; i < req.Keys.Count; i++, ActionNumberInStep++) {
                result = fileService.DeleteDirectory(req.Keys[i]);
                StepReport(ServiceStateReport);
                if (result.OperationResult == OperationResult.Failed)
                    return result;
            }


            return result;
        }


        public Result InstallRequirement(Requirement requirement) {
            var result = new Result {OperationResult = OperationResult.Succed};

            switch (requirement.RequirementType) {
                case RequirementType.Application:
                    return ExecuteApplicationRequirement(requirement);

                case RequirementType.CabFile:
                    return ExecuteCabFileRequirement(requirement);

                case RequirementType.Framework:
                    return ExecuteStandAloneExeRequirement(requirement);

                case RequirementType.SqlApplication:
                    return ExecuteStandAloneExeRequirement(requirement);

                case RequirementType.SqlScript:
                    return ExecuteSqlScriptRequirement(requirement);

                case RequirementType.System:
                    return ExecuteSystemRequirement(requirement);

                case RequirementType.UpdateFamily:
                    return ExecuteStandAloneExeRequirement(requirement);
            }
            return result;
        }

        private Result ExecuteStandAloneExeRequirement(Requirement requirement) {
            var result = new Result {OperationResult = OperationResult.Succed};
            StepReport(ServiceStateReport);

            var path = fileService.RequirementSourcePath(requirement);

            if (!fileService.FileExists(path)) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = new Exception(string.Format("{0} не удалось найти файл установки. Path:{1}", requirement.Title, path));
                return result;
            }

            try {
                var backgroundProcess = new Process {
                                                        EnableRaisingEvents = true,
                                                        StartInfo = new ProcessStartInfo(path, "/quiet /norestart"),
                                                    };

                backgroundProcess.Start();
                backgroundProcess.WaitForExit();
            }
            catch (Exception e) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = e;
            }

            return result;
        }

        private Result ExecuteSystemRequirement(Requirement requirement) {
            var result = new Result {OperationResult = OperationResult.Succed};
            StepReport(ServiceStateReport);
            return result;
        }

        private Result ExecuteSqlScriptRequirement(Requirement requirement) {
            var result = new Result {OperationResult = OperationResult.Succed};
            StepReport(ServiceStateReport);
            return result;
        }

        private Result ExecuteCabFileRequirement(Requirement requirement) {
            var result = new Result {OperationResult = OperationResult.Succed};

            StepReport(ServiceStateReport);

            if (!fileService.FileExists(environment.CurrentPath, requirement.SystemFile)) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = new Exception(string.Format("{0} файл не найден. Path:{1}", requirement.SystemFile, environment.CurrentPath));
                return result;
            }

            try {
                fileService.ExtractCab(environment.CurrentPath, requirement.SystemFile, environment.ExtractPath);
            }
            catch (Exception e) {
                result.OperationResult = OperationResult.Failed;
                result.Exception =
                    new Exception(string.Format("{0} не удалось распаковать. {1}", requirement.SystemFile, e.Message));
                return result;
            }

            return result;
        }

        private Result ExecuteApplicationRequirement(Requirement requirement) {
            var result = new Result { OperationResult = OperationResult.Succed };
            StepReport(ServiceStateReport);

            var path = fileService.RequirementSourcePath(requirement);

            if (!fileService.FileExists(path))
            {
                result.OperationResult = OperationResult.Failed;
                result.Exception = new Exception(string.Format("{0} не удалось найти файл установки. Path:{1}", requirement.Title, path));
                return result;
            }

            try
            {
                var backgroundProcess = new Process
                {
                    EnableRaisingEvents = true,
                    StartInfo = new ProcessStartInfo(path, "/q"),
                };

                backgroundProcess.Start();
                backgroundProcess.WaitForExit();
                log.WriteToLog(string.Format("{0} \r\n---- Exit Code:{1}", path, backgroundProcess.ExitCode));  
            }
            catch (Exception e)
            {
                result.OperationResult = OperationResult.Failed;
                result.Exception = e;
            }

            return result;
        }


        public Result RepairMain(InstallReq installReq) {
            installReq.FileAction = FileAction.CreateIfNotExists;

            return InstallMain(installReq);
        }


        public Result DeleteMain(InstallReq installReq) {
            installReq.FileAction = FileAction.Delete;
            return InstallMain(installReq);
        }


        public void CreateShortcutOnDesktop() {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var obj = new WshShellClass();
            var link = (WshShortcut) obj.CreateShortcut(Path.Combine(desktopPath, environment.ShortcutName));
            link.TargetPath = Path.Combine(environment.InstallPath, environment.ExecutableName);
            link.Description = environment.ApplicationName;
            link.Save();
        }

        public void CreateShortcutOnProgram() {
            var programsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs),
                                            environment.ExecutableName);
            if (!Directory.Exists(programsPath)) {
                Directory.CreateDirectory(programsPath);
            }
            var obj = new WshShellClass();
            var link = (WshShortcut) obj.CreateShortcut(Path.Combine(programsPath, environment.ShortcutName));
            link.TargetPath = Path.Combine(environment.InstallPath, environment.ExecutableName);
            link.Description = environment.ApplicationName;
            link.Save();
        }
    }
}
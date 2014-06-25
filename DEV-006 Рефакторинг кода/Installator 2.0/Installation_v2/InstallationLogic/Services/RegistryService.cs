using System;
using System.Collections.Generic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Microsoft.Win32;

namespace Installation_v2.InstallationLogic.Services {
    public class RegistryService : BaseService, IRegistryService {
        private IInstallEnvironment environment;
        private ILogService log;

        public new void InitService(IServiceLocator serviceLocator) {
            environment = serviceLocator.Get<IInstallEnvironment>();
            log = serviceLocator.Get<ILogService>();
        }

        public bool PathExists(string path) {
            var key = Registry.LocalMachine.OpenSubKey(path);

            return key != null;
        }

        public string GetKeyValue(string path, string key) {
            if (!PathExists(path)) return string.Empty;

            var entry = Registry.LocalMachine.OpenSubKey(path);
            return entry.GetValue(key) == null
                       ? ""
                       : entry.GetValue(key).ToString();
        }

        public List<string> GetKeys(string path) {
            var result = new List<string>();
            if (!PathExists(path)) return result;

            var key = Registry.LocalMachine.OpenSubKey(path);
            result.AddRange(key.GetSubKeyNames());
            key.Close();
            return result;
        }

        public Result CreateKeyValues(string key, string value) {
            var result = new Result {OperationResult = OperationResult.Succed};

            try {
                var path = Registry.LocalMachine.OpenSubKey(ApplicationRegPath(), true) ??
                           Registry.LocalMachine.CreateSubKey(ApplicationRegPath());

                if (path == null) {
                    result.OperationResult = OperationResult.Failed;
                    result.Exception = new Exception("Не удалось создать/получить доступ к путь/ключи в реестре");
                    log.WriteToLog(result.ErrorText);
                    return result;
                }

                if (path.GetValue(key) == null) {
                    result.OperationResult = OperationResult.Failed;
                    result.Exception = new Exception("Не удалось переписать существующий ключ/значение " + key);
                    log.WriteToLog(result.ErrorText);
                    return result;
                }

                path.SetValue(key, value);
                log.WriteToLog(string.Format("Reg >> {0}:{1}... Created", key, value));

                path.Close();
            }
            catch (Exception e) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = e;
                log.WriteToLog(result.ErrorText);
            }

            return result;
        }

        public Result RewriteKeyValues(string key, string value) {
            var result = new Result {OperationResult = OperationResult.Succed};

            try {
                var path = Registry.LocalMachine.OpenSubKey(ApplicationRegPath(), true) ??
                           Registry.LocalMachine.CreateSubKey(ApplicationRegPath());

                if (path == null) {
                    result.OperationResult = OperationResult.Failed;
                    result.Exception = new Exception("Не удалось создать/получить доступ к путь/ключи в реестре");
                    log.WriteToLog(result.ErrorText);
                    return result;
                }

                path.SetValue(key, value);
                log.WriteToLog(string.Format("Reg >> {0}:{1}... Rewrited", key, value));

                path.Close();
            }
            catch (Exception e) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = e;
                log.WriteToLog(result.ErrorText);
            }

            return result;
        }

        public Result DeleteKeyValues(string key) {
            var result = new Result {OperationResult = OperationResult.Succed};

            try {
                var path = Registry.LocalMachine.OpenSubKey(ApplicationRegPath(), true);
                if (path == null) {
                    log.WriteToLog(string.Format("Reg >> {0}... Was Deleted before", path));

                    return result;
                }

                path.DeleteValue(key);
                log.WriteToLog(string.Format("Reg >> {0}... Deleted", key));

                path.Close();
            }
            catch (Exception e) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = e;
                log.WriteToLog(result.ErrorText);
            }

            return result;
        }

        public Result DeletePath(string key) {
            var result = new Result {OperationResult = OperationResult.Succed};

            try {
                var path = Registry.LocalMachine.OpenSubKey(ApplicationRegPath(), true);
                if (path == null) {
                    log.WriteToLog(string.Format("Reg >> {0}... Was Deleted before", path));

                    return result;
                }

                path.DeleteSubKeyTree(key);
                log.WriteToLog(string.Format("Reg >> {0}... Path Deleted", key));
            }
            catch (Exception e) {
                result.OperationResult = OperationResult.Failed;
                result.Exception = e;
                log.WriteToLog(result.ErrorText);
            }

            return result;
        }


        private string ApplicationRegPath() {
            return string.Format("software\\{0}\\{1}", environment.ReleaseCompany, environment.ApplicationName);
        }
    }
}
using System.Collections.Generic;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.InstallationLogic.Services;

namespace Tests.Fakes {
    public class SqlUpdateServiceFake : BaseService, ISqlUpdateService {
        public void InitService(ServiceLocator serviceLocator) {}

        public Result ConnectCE(string path, string sqlCeFile) {
            var result = new Result {OperationResult = OperationResult.Succed};
            return result;
        }

        public Result Execute(string s) {
            var result = new Result {OperationResult = OperationResult.Succed};
            return result;
        }
    }

    public class RegistryServiceFake : BaseService, IRegistryService {
        public bool PathExists(string path) {
            return true;
        }

        public string GetKeyValueSetup { set; get; }
        public string GetKeyValue(string path, string key) {
            return GetKeyValueSetup;
        }

        public List<string> GetKeysSetup { set; get; }
        public List<string> GetKeys(string path) {
            return GetKeysSetup ?? new List<string>();
        }

        public Result CreateKeyValuesSetup { get; set; }
        public Result CreateKeyValues(string path, string value) {
            return CreateKeyValuesSetup ?? new Result{OperationResult = OperationResult.Succed};
        }

        public Result DeleteKeyValuesSetup { get; set; }
        public Result DeleteKeyValues(string key) {
            return DeleteKeyValuesSetup ?? new Result{OperationResult = OperationResult.Succed};
        }

        public Result RewriteKeyValuesSetup { get; set; }
        public Result RewriteKeyValues(string key, string value) {
            return RewriteKeyValuesSetup ?? new Result{OperationResult = OperationResult.Succed};
        }

        public Result DeletePathSetup { get; set; }
        public Result DeletePath(string key) {
            return DeletePathSetup ?? new Result{OperationResult = OperationResult.Succed};
        }
    }
}
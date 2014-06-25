using System;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;

namespace Installation_v2.InstallationLogic.Services {
    public class SqlUpdateService : BaseService, ISqlUpdateService {
        private IInstallEnvironment environment;
        private SqlCeConnection connection;
        private ILogService log;


        public new void InitService(IServiceLocator serviceLocator) {
            environment = serviceLocator.Get<IInstallEnvironment>();
            log = serviceLocator.Get<ILogService>();
        }

        public Result ConnectCE(string path, string sqlCeFile) {
            var result = new Result {OperationResult = OperationResult.Succed};

            path = Path.Combine(environment.ExtractPath, path);
            path = Path.Combine(path, sqlCeFile);
            path = string.Format("DataSource={0}", path);

            try {
                log.WriteToLog("ConnectionString: " + path);
                connection = new SqlCeConnection(path);
                connection.Open();
                connection.Close();
                log.WriteToLog("Connection... OK");
            }
            catch (Exception e) {
                log.WriteToLog("Connection... Failed");
                result.Exception = e;
                result.OperationResult = OperationResult.Failed;
                log.WriteToLog(result.ErrorText);
            }

            return result;
        }

        public Result Execute(string s) {
            var result = new Result {OperationResult = OperationResult.Succed};

            if (UpdateNotAbleToInstall()) {
                log.WriteToLog("Unable to install SQL updates");

                return result;
            }

            if (connection == null) {
                result.Exception = new NullReferenceException("Не удалось инициализировать соединение к БД");
                result.OperationResult = OperationResult.Failed;
                log.WriteToLog(result.ErrorText);
                return result;
            }

            try {
                connection.Open();
                new SqlCeCommand(s, connection).ExecuteNonQuery();
                connection.Close();
                log.WriteToLog("Executing >> " + s);
                
            }
            catch (Exception e) {
                result.Exception = e;
                result.OperationResult = OperationResult.Failed;
                log.WriteToLog(result.ErrorText);
            }
            finally {
                if (connection.State != ConnectionState.Closed) {
                    connection.Close();
                }
            }

            return result;
        }

        private bool UpdateNotAbleToInstall() {
            var v1 = string.CompareOrdinal(environment.MinimumVersionToUpdate,
                                           environment.ApplicationPreinstalledVersion);

            var v2 = string.CompareOrdinal(environment.ApplicationVersion,
                                           environment.ApplicationPreinstalledVersion);

            return !(v1 <= 0 && v2 > 0);
        }
    }
}
using Installation_v2.InstallationLogic.Enums;

namespace Installation_v2.InstallationLogic.Interfaces {
    public interface ISqlUpdateService : IService {
        Result ConnectCE(string path, string sqlCeFile);
        Result Execute(string s);
    }
}
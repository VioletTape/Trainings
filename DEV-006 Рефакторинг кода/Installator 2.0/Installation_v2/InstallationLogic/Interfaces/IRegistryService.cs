using System.Collections.Generic;
using Installation_v2.InstallationLogic.Enums;

namespace Installation_v2.InstallationLogic.Interfaces {
    public interface IRegistryService : IService {
        bool PathExists(string path);
        string GetKeyValue(string path, string key);
        List<string> GetKeys(string path);
        Result CreateKeyValues(string path, string value);
        Result DeleteKeyValues(string key);
        Result RewriteKeyValues(string key, string value);
        Result DeletePath(string key);
    }
}
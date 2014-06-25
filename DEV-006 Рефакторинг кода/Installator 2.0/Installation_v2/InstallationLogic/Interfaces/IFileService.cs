using System.IO;
using Installation_v2.InstallationLogic.Enums;

namespace Installation_v2.InstallationLogic.Interfaces {
    internal interface IFileService : IService {
        Result CreateDirectory(string path, InstallFileAccess fileAccess);
        Result ExtractCab(string sourcePath, string cabName, string destination);

        string RequirementSourcePath(Requirement requirement);
        string InstallPath(InstallReq installReq);

        bool FileExists(string path);
        bool FileExists(string path, string fileName);
        Result CopyFile(string source, string destination, string file, InstallFileAccess fileAccess);
        Result RewriteFile(string source, string destination, string file, InstallFileAccess fileAccess);
        Result DeleteFile(string path, string file);
        Result DeleteDirectory(string path);

        StreamWriter CreateLogFile(string path);
    }
}
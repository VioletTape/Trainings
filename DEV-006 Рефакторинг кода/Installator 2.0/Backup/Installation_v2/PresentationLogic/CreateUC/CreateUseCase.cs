using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using CabLib;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.PresentationLogic.CreateUC.DataState;
using Installation_v2.Properties;

namespace Installation_v2.PresentationLogic.CreateUC {
    public class CreateUseCase : UseCaseBase {
        private CreateViewState state;
        private string pathToCode;
        private string pathToResources;
        private string executableName;
        public CreateUseCase(InstallState installState) : base(installState) {}

        public override void DoConfigure() {
            state = new CreateViewState {
                                            CurrentMinVersion = InstallEnvironment.MinimumVersionToUpdate,
                                            CurrentVersion = InstallEnvironment.ApplicationVersion,
                                            MinVersion = InstallEnvironment.MinimumVersionToUpdate,
                                            Version = InstallEnvironment.ApplicationVersion,
                                            CreateCore = CreateCore,
                                            PathToCE = Settings.Default.pathToCE,
                                            PathToCsc = Settings.Default.pathToCsc,
                                            PathToEnvBat = Settings.Default.pathToVsvars,
                                            PathToPlaceNewInstaller = Settings.Default.pathToResult,
                                            PathToAppl = Settings.Default.pathToAppl
                                        };
            BaseViewState = state;

            executableName = InstallEnvironment.ExecutableName;
            pathToCode = InstallEnvironment.ExtractPath + @"\extras\Mainfiles";
            pathToResources = InstallEnvironment.ExtractPath + @"\extras\Resources";
        }

        private void CreateCore(object obj) {
            var fileService = InstallState.ServiceLocator.Get<IFileService>();
            fileService.ExtractCab(InstallEnvironment.CurrentPath, "extras.wbr", InstallEnvironment.ExtractPath + @"\extras");

            UpdateSettings();
            CreateSqlFile();

            var process = new Process();
            var info = process.StartInfo;
            info.RedirectStandardError = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;

            info.FileName = state.PathToEnvBat;
            process.Start();

            Thread.Sleep(100);

            info = process.StartInfo;
            info.FileName = state.PathToCsc;
            info.Arguments = Args();
            process.Start();
            var error = process.StandardError;
            var output = process.StandardOutput;

            var textError = File.CreateText(Path.Combine(state.PathToPlaceNewInstaller, "error.txt"));
            textError.Write(error.ReadToEnd());
            textError.Flush();
            textError.Close();

            var text = File.CreateText(Path.Combine(state.PathToPlaceNewInstaller, "output.txt"));
            text.Write(output.ReadToEnd());
            text.Flush();
            text.Close();

            CopyCabsAndDlls();
            CreateCoreCab();

            Settings.Default.pathToCE = state.PathToCE;
            Settings.Default.pathToCsc = state.PathToCsc;
            Settings.Default.pathToVsvars = state.PathToEnvBat;
            Settings.Default.pathToResult = state.PathToPlaceNewInstaller;
            Settings.Default.pathToAppl = state.PathToAppl;

            Directory.Delete(InstallEnvironment.ExtractPath, true);
            var combine = Path.Combine(state.PathToPlaceNewInstaller, executableName);
            var extension = Path.GetFileNameWithoutExtension(combine);
            File.Delete(combine.Replace(".exe", ".pdb"));
        }

        private void CreateCoreCab() {
            var files = new List<string>(Directory.GetFiles(state.PathToAppl, "*.exe"));
            files.AddRange(Directory.GetFiles(state.PathToAppl, "*.dll"));
            files.AddRange(Directory.GetFiles(state.PathToAppl, "*.sdf"));

            files.RemoveAll(f => f.Contains("vshost"));

            var core = Path.Combine(InstallEnvironment.ExtractPath, "CoreCopy");
            Directory.CreateDirectory(core);

            files.ForEach(f => {
                              var name = Path.GetFileName(f);
                              File.Copy(f, Path.Combine(core, name));
                          });

            var compress = new Compress();
            compress.CompressFolder(
                core, 
                Path.Combine(state.PathToPlaceNewInstaller, "core.wbr"),
                "*.*", true, true, 0);
        }

        private void UpdateSettings() {
            var path = Path.Combine(InstallEnvironment.ExtractPath, "extras");
            path = Path.Combine(path, @"Mainfiles\Settings.Designer.cs");
            var fileStream = File.OpenText(path);
            var settings = fileStream.ReadToEnd();
            fileStream.Close();
            var split = settings.Split(new[] {"(\""}, StringSplitOptions.RemoveEmptyEntries);

            var version = split[3].Substring(0, split[3].IndexOf("\""));
            var minVersion = split[9].Substring(0, split[9].IndexOf("\""));

            settings = settings.Replace(version, state.Version);
            settings = settings.Replace(minVersion, state.MinVersion);

            File.WriteAllText(path, settings);
        }

        private void CopyCabsAndDlls() {
            var compress = new Compress();
            compress.CompressFolder(
                Path.Combine(InstallEnvironment.ExtractPath, "extras"),
                Path.Combine(state.PathToPlaceNewInstaller, "extras.wbr"),
                "*.*", true, true, 0);

            File.Copy(Path.Combine(InstallEnvironment.CurrentPath, "requirments.wbr"), Path.Combine(state.PathToPlaceNewInstaller, "requirments.wbr"), true);
            File.Copy(Path.Combine(InstallEnvironment.CurrentPath, "CabLib.dll"), Path.Combine(state.PathToPlaceNewInstaller, "CabLib.dll"), true);
            File.Copy(Path.Combine(InstallEnvironment.CurrentPath, "Interop.IWshRuntimeLibrary.dll"), Path.Combine(state.PathToPlaceNewInstaller, "Interop.IWshRuntimeLibrary.dll"), true);
        }

        private void CreateSqlFile() {
            File.WriteAllText(Path.Combine(pathToCode, "scripts.txt"), state.Scripts);
        }

        private string Args() {
            var builder = new StringBuilder();
            builder.Append(@"" + " ");
            builder.Append(@"/noconfig " + " ");
            builder.Append(@"/nowarn:1701,1702 " + " ");
            builder.Append(@"/platform:x86 " + " ");

            builder.AppendFormat(@"""/reference:{0}\CabLib.dll"" ", InstallEnvironment.CurrentPath);
            builder.AppendFormat(@"""/reference:{0}\Interop.IWshRuntimeLibrary.dll"" ", InstallEnvironment.CurrentPath);
            builder.Append(@"""/reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Data.dll"" " + " ");
            builder.AppendFormat("/reference:\"{0}\" ", state.PathToCE);
            builder.Append(@"/reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Deployment.dll " + " ");
            builder.Append(@"/reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.dll " + " ");
            builder.Append(@"/reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Drawing.dll " + " ");
            builder.Append(@"/reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Windows.Forms.dll " + " ");
            builder.Append(@"/reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Xml.dll " + " ");
            builder.Append(@"/debug+ " + " ");
            builder.Append(@"/filealign:512 " + " ");

            builder.AppendFormat(@"/out:""{0}""  ", Path.Combine(state.PathToPlaceNewInstaller, executableName));

            builder.AppendFormat(@"""/resource:{0}\Installation_v2.FormInstall.resources""  ", pathToResources);
            builder.AppendFormat(@"""/resource:{0}\Installation_v2.PresentationLogic.CreateUC.Views.CreateView.resources""  ", pathToResources);
            builder.AppendFormat(@"""/resource:{0}\Installation_v2.PresentationLogic.End.Views.EndView.resources""  ", pathToResources);
            builder.AppendFormat(@"""/resource:{0}\Installation_v2.PresentationLogic.InstallSelectionUC.Views.InstallSelectionView.resources""  ", pathToResources);
            builder.AppendFormat(@"""/resource:{0}\Installation_v2.PresentationLogic.InstallUC.Views.InstallView.resources""  ", pathToResources);
            builder.AppendFormat(@"""/resource:{0}\Installation_v2.PresentationLogic.LicenseUC.Views.LicenseView.resources""  ", pathToResources);
            builder.AppendFormat(@"""/resource:{0}\Installation_v2.PresentationLogic.RemoveTempUC.Views.RemoveTempView.resources""  ", pathToResources);
            builder.AppendFormat(@"""/resource:{0}\Installation_v2.PresentationLogic.RequirementsCheckupUC.Views.RequirementsCheckupView.resources""  ", pathToResources);
            builder.AppendFormat(@"""/resource:{0}\Installation_v2.PresentationLogic.RequirementsInstallUC.Views.RequirementsInstallView.resources""  ", pathToResources);
            builder.AppendFormat(@"""/resource:{0}\Installation_v2.Properties.Resources.resources""  ", pathToResources);
            builder.AppendFormat(@"""/resource:{0}\Installation_v2.PresentationLogic.WelcomeUC.Views.WelcomeView.resources""  ", pathToResources);
            builder.AppendFormat(@"""/resource:{0}\scripts.txt,Installation_v2.scripts.txt""  ", pathToCode);
            builder.AppendFormat(@"""/target:winexe""  " + " ");

            var files = Directory.GetFiles(pathToCode, "*.cs", SearchOption.AllDirectories);
            for (var i = 0; i < files.Length; i++) {
                builder.AppendFormat("\"{0}\" ", files[i]);
            }

            return builder.ToString();
        }
    }
}
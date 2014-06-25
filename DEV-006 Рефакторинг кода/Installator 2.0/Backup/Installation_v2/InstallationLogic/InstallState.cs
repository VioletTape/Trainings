using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;

namespace Installation_v2.InstallationLogic {
    public class InstallState {
        private List<Requirement> requirements = new List<Requirement>();
        private List<InstallReq> installs = new List<InstallReq>();

        public List<Requirement> Requirements {
            get {
                return requirements.FindAll(i =>
                                            (i.SystemType == InstallEnvironment.SystemType || i.SystemType == SystemType.Any) &&
                                            (i.SystemVersion == InstallEnvironment.SystemVersion || i.SystemVersion == SystemVersion.Any));
            }
        }

        public List<InstallReq> InstallReq {
            get { return installs; }
        }


        public InstallationType InstallationType { get; set; }
        public IServiceLocator ServiceLocator { get; private set; }
        public IInstallEnvironment InstallEnvironment { get; private set; }
        public ILogService LogService { get; private set; }


        public InstallState(IServiceLocator serviceLocator) {
            FillRequirementList();

            ServiceLocator = serviceLocator;
            InstallEnvironment = serviceLocator.Get<IInstallEnvironment>();
            LogService = serviceLocator.Get<ILogService>();

            FillInstallList();
        }

        private void FillRequirementList() {
            requirements = new List<Requirement> {
                                                     new Requirement {
                                                                         Sequence = 10,
                                                                         Title = "Распаковка файлов предустановки",
                                                                         RequirementState = RequirementState.NotInstalled,
                                                                         RequirementType = RequirementType.CabFile,
                                                                         SystemVersion = SystemVersion.Any,
                                                                         SystemType = SystemType.Any,
                                                                         SystemName = "",
                                                                         SystemFile = "requirments.wbr"
                                                                     },
                                                     new Requirement {
                                                                         Sequence = 11,
                                                                         Title = "Распаковка файлов программы",
                                                                         RequirementState = RequirementState.NotInstalled,
                                                                         RequirementType = RequirementType.CabFile,
                                                                         SystemVersion = SystemVersion.Any,
                                                                         SystemType = SystemType.Any,
                                                                         SystemName = "",
                                                                         SystemFile = "core.wbr"
                                                                     },
                                                     new Requirement {
                                                                         Sequence = 20,
                                                                         Title = "Windows Installer 3.1 или выше",
                                                                         RequirementState = RequirementState.Unknow,
                                                                         RequirementType = RequirementType.UpdateFamily,
                                                                         SystemVersion = SystemVersion.XP,
                                                                         SystemType = SystemType.x86,
                                                                         SystemName = "KB893803",
                                                                         SystemFile = "KB893803.exe"
                                                                     },
                                                     new Requirement {
                                                                         Sequence = 30,
                                                                         Title = ".Net Framework 3.5 или выше",
                                                                         RequirementState = RequirementState.Unknow,
                                                                         RequirementType = RequirementType.Framework,
                                                                         SystemVersion = SystemVersion.Any,
                                                                         SystemType = SystemType.Any,
                                                                         SystemName = "3.5",
                                                                         SystemFile = "dotNetFramework\\dotNetFx35setup.exe"
                                                                     },
                                                     new Requirement {
                                                                         Sequence = 35,
                                                                         Title = "Просмотрщик отчетов",
                                                                         RequirementState = RequirementState.NotInstalled,
                                                                         RequirementType = RequirementType.Application,
                                                                         SystemVersion = SystemVersion.Any,
                                                                         SystemType = SystemType.Any,
                                                                         SystemName = "",
                                                                         SystemFile = "reportViewer\\install.exe"
                                                                     },
                                                     new Requirement {
                                                                         Sequence = 40,
                                                                         Title = "Sql Server Compact Edition 3.5 или выше",
                                                                         RequirementState = RequirementState.Unknow,
                                                                         RequirementType = RequirementType.SqlApplication,
                                                                         SystemVersion = SystemVersion.Any,
                                                                         SystemType = SystemType.Any,
                                                                         SystemName = "SSCE",
                                                                         SystemFile = "SSCERuntime-enu-x86.msi",
                                                                         //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft SQL Server Compact Edition
                                                                         RegPath = @"SOFTWARE\Microsoft\Microsoft SQL Server Compact Edition",
                                                                     },
                                                     new Requirement {
                                                                         Sequence = 50,
                                                                         Title = "Sql Server Compact Edition 3.5 (x64 патч) или выше",
                                                                         RequirementState = RequirementState.Unknow,
                                                                         RequirementType = RequirementType.SqlApplication,
                                                                         SystemVersion = SystemVersion.Any,
                                                                         SystemType = SystemType.x64,
                                                                         SystemName = "SSCE",
                                                                         SystemFile = "SSCERuntime-enu-x64.msi",
                                                                         RegPath = @"SOFTWARE\Microsoft\Microsoft SQL Server Compact Edition",
                                                                     }
                                                 };
        }

        private void FillInstallList() {
            var sql_scripts = new List<string> {};

            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("Installation_v2.scripts.txt");
            var reader = new StreamReader(stream);
            while (!reader.EndOfStream) {
                sql_scripts.Add(reader.ReadLine());
            }

            installs = new List<InstallReq> {
                                                new InstallReq {
                                                                   Title = "Копирование основных файлов",
                                                                   InstallState = RequirementState.Pending,
                                                                   InstallReqType = InstallReqType.File,
                                                                   FileAction = FileAction.Rewrite,
                                                                   Keys = new List<string> {
                                                                                               "ApplicationGrande.dll", // 1
                                                                                               "BaseClassHelpers.dll",  // 2
                                                                                               "DataBaseLinqs.dll",     // 3
                                                                                               "Grande.Domain.dll",     // 4
                                                                                               "Grande.exe",            // 5
                                                                                               "Grande.Infrastructure.dll",
                                                                                               "Grande.Presentation.dll",
                                                                                               "TaskDialog.dll",
                                                                                               "WindowsControls.dll"    // 9
                                                                                           }
                                                               },
//                                                new InstallReq {
//                                                                   Title = "Копирование вспомогательных файлов файлов",
//                                                                   InstallState = RequirementState.Pending,
//                                                                   InstallReqType = InstallReqType.File,
//                                                                   FileAction = FileAction.CreateIfNotExists,
//                                                                   Keys = new List<string> {
//                                                                                               "Infragistics2.Excel.v8.3.dll",
//                                                                                               "Infragistics2.Shared.v8.3.dll",
//                                                                                               "Infragistics2.Win.Misc.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinCalcManager.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinDataSource.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinEditors.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinExplorerBar.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinGauge.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinGrid.ExcelExport.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinGrid.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinInkProvider.Ink17.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinListView.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinMaskedEdit.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinSchedule.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinStatusBar.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinTabControl.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinToolbars.v8.3.dll",
//                                                                                               "Infragistics2.Win.UltraWinTree.v8.3.dll",
//                                                                                               "Infragistics2.Win.v8.3.dll",
//                                                                                               "PostSharp.Laos.dll",
//                                                                                               "PostSharp.Public.dll",
//                                                                                               "Microsoft.ReportViewer.Common.dll",
//                                                                                               "Microsoft.ReportViewer.WinForms.dll",
//                                                                                               "System.Data.DataSetExtensions.dll",
//                                                                                               "System.Deployment.dll",
//                                                                                               "System.Design.dll",
//                                                                                               "System.Drawing.dll",
//                                                                                               "System.Runtime.Serialization.Formatters.Soap.dll", //37
//                                                                                           }
//                                                               },
//                                                new InstallReq {
//                                                                   Title = "Создание базы данных",
//                                                                   InstallState = RequirementState.Pending,
//                                                                   InstallReqType = InstallReqType.File,
//                                                                   FileAction = FileAction.Rewrite, //CreateIfNotExists
//                                                                   Keys = new List<string> {
//                                                                                               "grandeCe.sdf",
//                                                                                           }
//                                                               },
//                                                new InstallReq {
//                                                                   Title = "Обновление базы данных",
//                                                                   InstallState = RequirementState.Pending,
//                                                                   InstallReqType = InstallReqType.Script,
//                                                                   FileAction = FileAction.Rewrite,
//                                                                   Destination = "grandeCe.sdf",
//                                                                   Keys = sql_scripts
//                                                               },
                                                new InstallReq {
                                                                   Title = "Создание ключей реестра",
                                                                   InstallState = RequirementState.Pending,
                                                                   InstallReqType = InstallReqType.Registry,
                                                                   FileAction = FileAction.Rewrite,
                                                                   Destination = "Version",
                                                                   Keys = new List<string> {
                                                                                               InstallEnvironment.ApplicationVersion,
                                                                                           }
                                                               },
                                                new InstallReq {
                                                                   Title = "Запись ключей реестра",
                                                                   InstallState = RequirementState.Pending,
                                                                   InstallReqType = InstallReqType.Registry,
                                                                   FileAction = FileAction.Rewrite,
                                                                   Destination = "Path",
                                                                   Keys = new List<string> {
                                                                                               InstallEnvironment.InstallPath,
                                                                                           }
                                                               }
                                            };
        }
    }
}
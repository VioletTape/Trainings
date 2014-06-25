using System.Text;
using CabLib;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.WelcomeUC.DataState;

namespace Installation_v2.PresentationLogic.WelcomeUC {
    public class WelcomeUseCase : UseCaseBase {
        public WelcomeUseCase(InstallState installState) : base(installState) {
        }

        public WelcomeViewState state { get; private set; }

        public override void DoConfigure() {
            state = new WelcomeViewState {
                                             StepCaption = "Приветствие",
                                             StepInstructions = GenerateStepInstruction(),
                                             PrevStepVisible = false,
                                             NextUseCase = UseCaseNames.License,
                                             TrackName = TrackName.InfoGathering,
                                             CancelStepAction = i => { }
                                         };
            
            if (!MinimumVersionAplicable()) {
                InstallState.LogService.WriteToLog("Minimum Version Aplicable - false");
                InstallState.LogService.WriteToLog("Exit initiated");
                state.NextStepVisible = false;
                state.FinishStepCaption = "Закрыть";
            }

            InstallState.InstallationType = SameVersionToInstall()
                                                ? InstallationType.Repair
                                                : InstallationType.Install;

            InstallState.LogService.WriteToLog("InstallationType " + InstallState.InstallationType);
            BaseViewState = state;
            var compress = new Compress();

//            if (!string.IsNullOrEmpty(ProgramMode.RowParams)) {
//                compress.CompressFolder(
//                    @"Z:\_RedistributablePackages",
//                    @"C:\Projects\readyToInstall\requirments.wbr",
//                    "*.*", true, true, 0);
//                compress.CompressFolder(
//                    @"D:\Project\_Ready\Debug",
//                    @"D:\Project\_Ready\Output\core.wbr",
//                    "*.*", true, true, 0);
//                compress.CompressFolder(
//                    @"c:\Projects\_Ready\Debug",
//                    @"c:\Projects\_Ready\Output\core.wbr",
//                    "*.*", true, true, 0);
//            }

//            var extract = new Extract();
//            extract.ExtractFile(@"D:\Project\Installation_v2 Source\extras.cab", @"D:\Project\GSF");
        }

        private string GenerateStepInstruction() {
            var builder = new StringBuilder();
            builder.Append("Вас приветствует программа установки ");
            builder.AppendLine(InstallEnvironment.ApplicationName + ".");

            if (GotPreviousInstallations() && !SameVersionToInstall()) {
                if (!MinimumVersionAplicable()) {
                    builder.AppendLine();
                    builder.Append(string.Format("Нельзя установить обновление на версию {0}. Обновите до {1}.",
                                                 InstallEnvironment.ApplicationPreinstalledVersion,
                                                 InstallEnvironment.MinimumVersionToUpdate));
                    return builder.ToString();
                }


                builder.AppendLine();
                builder.Append(string.Format("Данная программа версии {0} уже была установлена",
                                             InstallEnvironment.ApplicationPreinstalledVersion));

                if (AbleToInstall()) {
                    builder.AppendLine(",");
                    builder.AppendLine("в процессе установки она будет обновлена до версии " +
                                       InstallEnvironment.ApplicationVersion);
                }
                else {
                    builder.AppendLine(",");
                    builder.AppendLine("продолжение установки не рекомендуется.");
                }
            }
            else {
                builder.AppendLine();
                builder.AppendLine("Будет установлена программа версии " + InstallEnvironment.ApplicationVersion);
            }

            return builder.ToString();
        }

        private bool SameVersionToInstall() {
            var ordinal = string.CompareOrdinal(InstallEnvironment.ApplicationVersion,
                                                InstallEnvironment.ApplicationPreinstalledVersion);
            return ordinal == 0;
        }

        private bool AbleToInstall() {
            var ordinal = string.CompareOrdinal(InstallEnvironment.ApplicationVersion,
                                                InstallEnvironment.ApplicationPreinstalledVersion);
            return ordinal >= 0;
        }

        private bool GotPreviousInstallations() {
            return !string.IsNullOrEmpty(InstallEnvironment.ApplicationPreinstalledVersion);
        }

        private bool MinimumVersionAplicable() {
            if (!GotPreviousInstallations()) return true;
            if (!InstallEnvironment.LightUpdate) return true;

            var ordinal = string.CompareOrdinal(InstallEnvironment.MinimumVersionToUpdate,
                                                InstallEnvironment.ApplicationPreinstalledVersion);
            return ordinal <= 0;
        }
    }
}
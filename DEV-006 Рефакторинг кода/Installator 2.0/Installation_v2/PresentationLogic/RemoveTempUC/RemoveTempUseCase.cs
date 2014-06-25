using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.InstallationLogic.Interfaces;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.RemoveTempUC.DataState;
using Installation_v2.PresentationLogic.RequirementsCheckupUC.DataState;

namespace Installation_v2.PresentationLogic.RemoveTempUC {
    public class RemoveTempUseCase : UseCaseBase {
        private readonly Timer timer = new Timer();
        private IInstallService installService;
        private RemoveTempViewState state;
        private List<InstallReq> requirements;
        private List<Result> results;

        public RemoveTempUseCase(InstallState installState) : base(installState) {}

        public override void DoConfigure() {
            installService = InstallState.ServiceLocator.Get<IInstallService>();
            installService.StepReport += StepReport;

            state = new RemoveTempViewState {
                                                NextUseCase = UseCaseNames.End,
                                                PrevUseCase = UseCaseNames.Install,
                                                TrackName = TrackName.Install,
                                                PrevStepVisible = false,
                                                NextStepVisible = false,
                                                StepCaption = "Завершение установки",
                                                StepInstructions = "Удаление временных файлов",
                                            };

            requirements = CreateRequirements();
            SetupRequirements(requirements);

            var n = Environment.GetEnvironmentVariable("Temp");
            var combine = Path.Combine(n, "dc.cache");
            if(File.Exists(combine)) {
                File.Delete(combine);
            }


            BaseViewState = state;

            timer.Interval = 1000;
            timer.Tick += Tick;
            timer.Start();
        }

        private void StepReport(string obj) {}

        private List<InstallReq> CreateRequirements() {
            var list = new List<InstallReq> {
                                                new InstallReq {
                                                                   Title = "Удаление временных файлов",
                                                                   InstallState = RequirementState.Pending,
                                                                   InstallReqType = InstallReqType.Directory,
                                                                   FileAction = FileAction.Delete,
                                                                   Destination = InstallState.InstallEnvironment.ExtractPath,
                                                                   Keys = new List<string> {
                                                                                               InstallState.InstallEnvironment.ExtractPath
                                                                                           }
                                                               }
                                            };


            if (InstallState.InstallationType == InstallationType.Cancel ||
                InstallState.InstallationType == InstallationType.Delete) {
                list.Add(new InstallReq {
                                            Title = "Удаление установленных файлов",
                                            InstallState = RequirementState.Pending,
                                            InstallReqType = InstallReqType.Directory,
                                            FileAction = FileAction.Delete,
                                            Destination = InstallState.InstallEnvironment.InstallPath,
                                            Keys = new List<string> {
                                                                        InstallState.InstallEnvironment.InstallPath,
                                                                    }
                                        });

                InstallState.InstallReq.FindAll(i => i.InstallReqType == InstallReqType.Registry)
                    .ForEach(i => {
                                 i.Title = "Удаление ключей реестра";
                                 i.FileAction = FileAction.Delete;
                                 i.InstallState = RequirementState.Pending;
                                 list.Add(i);
                             });
            }
            results = new List<Result>(list.Count);
            return list;
        }

        internal void Tick(object sender, EventArgs e) {
            var find = requirements.Find(i => i.InstallState == RequirementState.Pending);
            if (find == null) {
                timer.Stop();
                state.ForceStep(UseCaseNames.End);
                return;
            }

            InstallState.LogService.WriteToLog("");
            InstallState.LogService.WriteToLog("Remove: " + find.Title);


            find.InstallState = RequirementState.Processing;
            SetupRequirements(requirements);
            state.SendChange(true);

            var result = installService.DeleteMain(find);

            find.InstallState = result.OperationResult == OperationResult.Succed
                                    ? RequirementState.Installed
                                    : RequirementState.NotInstalled;

            InstallState.LogService.WriteToLog("Removed: " + result.OperationResult);
            results.Add(result);
            SetupRequirements(requirements);
            state.SendChange(true);
        }

        private void SetupRequirements(List<InstallReq> requirements) {
            var all = requirements.ConvertAll(i => new RequirementsViewState {
                                                                                 Caption = i.Title,
                                                                                 Status = ImageSetter.GetImage(i.InstallState),
                                                                                 Error = "",
                                                                                 ErrorFullText = ""
                                                                             });
             for (var i = 0; i < results.Count; i++) {
                all[i].Error = results[i].OperationResult == OperationResult.Succed
                                                           ? "Ok"
                                                           : "Ошибка";
                all[i].ErrorFullText = results[i].ErrorText;
            }
            state.Requirements = all;
        }
    }
}
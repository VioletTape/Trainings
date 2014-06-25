using System;
using Installation_v2.PresentationLogic.Enums;

namespace Installation_v2.PresentationLogic {
    public class BaseViewState {
        public string StepCaption { get; set; }
        public string StepInstructions { get; set; }

        public bool PrevStepVisible { get; set; }
        public bool NextStepVisible { get; set; }

        public string FinishStepCaption { get; set; }
        public string NextStepCaption { get; set; }

        public Action<bool> NextStepAction { get; set; }
        public Action<bool> PrevStepAction { get; set; }
        public Action<bool> CancelStepAction { get; set; }

        public UseCaseNames NextUseCase{ get; set; }
        public UseCaseNames PrevUseCase{ get; set; }

        public TrackName TrackName{ get; set;}

        public Action<bool> AcceptChange{ get; set; }
        public Action<bool> SendChange{ get; set; }
        public Action<bool> StopAllActions{ get; set; }
        public Action<UseCaseNames> ForceStep{ get; set; }

        public BaseViewState() {
            PrevStepVisible = true;
            NextStepVisible = true;

            FinishStepCaption = "Отмена";
            NextStepCaption = "Далее >>";

            NextStepAction = i => { };
            PrevStepAction = i => { };

            ForceStep = i => { };
            StopAllActions = i => { };
        }
    }
}
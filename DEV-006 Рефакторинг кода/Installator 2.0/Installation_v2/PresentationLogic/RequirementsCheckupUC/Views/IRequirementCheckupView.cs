using Installation_v2.PresentationLogic.RequirementsCheckupUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.RequirementsCheckupUC.Views {
    public interface IRequirementCheckupView : IBaseView {
        new RequirementCheckupViewState State { get; set; }
    }
}
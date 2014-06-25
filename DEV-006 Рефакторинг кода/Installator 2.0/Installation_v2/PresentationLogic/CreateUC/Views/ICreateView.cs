using Installation_v2.PresentationLogic.CreateUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.CreateUC.Views {
    public interface ICreateView : IBaseView {
        new CreateViewState State { get; set; }
    }
}
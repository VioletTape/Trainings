using Installation_v2.PresentationLogic.End.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.End.Views {
    public interface IEndView : IBaseView {
        new EndViewState State { get; set; }
    }
}
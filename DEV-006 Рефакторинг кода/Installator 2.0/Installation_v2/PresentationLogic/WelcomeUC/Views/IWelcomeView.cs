using Installation_v2.PresentationLogic.WelcomeUC.DataState;

namespace Installation_v2.PresentationLogic.WelcomeUC.Views {
    public interface IWelcomeView : IBaseView {
        new WelcomeViewState State { get; set; }
    }

    public interface IBaseView {
        BaseViewState State{ get; set;}
    }
}
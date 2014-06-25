using Installation_v2.PresentationLogic.RemoveTempUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.RemoveTempUC.Views {
    public interface IRemoveTempView : IBaseView{
        new RemoveTempViewState State { get; set; }
    }
}
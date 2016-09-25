using PostSharp.Toolkit.Domain;
using StructureMap;

namespace Presentation.Models {
    [NotifyPropertyChanged]
    public class BaseModel : IViewModel {
        protected IViewManager ViewManager;

        public string Title { get; set; }

        public BaseModel() {
           
        }

        public virtual void InitModel() {
             ViewManager = ObjectFactory.GetInstance<IViewManager>();
        }
    }

    public interface IViewModel : IView {
        void InitModel();
    }

    public interface IView {}

     public interface IViewManager {
         void Show<T>();
     }
}
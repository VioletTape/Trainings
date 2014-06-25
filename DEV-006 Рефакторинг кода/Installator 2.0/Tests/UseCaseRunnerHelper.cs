using System.Reflection;
using Installation_v2.PresentationLogic;
using Installation_v2.PresentationLogic.Enums;
using Tests.Fakes;

namespace Tests {
    internal class UseCaseRunnerHelper {
        private FieldInfo currentUseCase;
        private UseCaseRunner runner;
        private FieldInfo currentName;

        public ServiceLocatorFake ServiceLocator { get; private set; }
        public UseCaseBase CurrentUseCase { get; private set; }

        public UseCaseNames CurrentUseCaseName {
            get { return (UseCaseNames) currentName.GetValue(runner); }
        }

        public BaseViewState BaseViewState {
            get { return CurrentUseCase.BaseViewState; }
        }

        public UseCaseRunnerHelper() {
            ServiceLocator = new ServiceLocatorFake();
        }

        public UseCaseBase RunNext() {
            if (runner == null) {
                runner = new UseCaseRunner(ServiceLocator) {
                                                               OnStepView = (i => { }),
                                                               OnStep = (i => { })
                                                           };

                var type = runner.GetType();
                currentUseCase = type.GetField("currentUseCase", BindingFlags.Instance | BindingFlags.NonPublic);
                currentName = type.GetField("currentName", BindingFlags.Instance | BindingFlags.NonPublic);


                runner.RunNext(true);
                CurrentUseCase = ((UseCaseBase) currentUseCase.GetValue(runner));
                return CurrentUseCase;
            }

            runner.RunNext(true);
            CurrentUseCase = ((UseCaseBase) currentUseCase.GetValue(runner));
            return CurrentUseCase;
        }

        public void Run(UseCaseNames useCaseName) {
            RunNext();
            CurrentUseCase.BaseViewState.NextUseCase = useCaseName;
            RunNext();
        }
    }
}
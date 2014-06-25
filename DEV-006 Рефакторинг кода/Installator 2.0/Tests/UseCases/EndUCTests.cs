using Installation_v2.InstallationLogic;
using Installation_v2.PresentationLogic;
using Installation_v2.PresentationLogic.End;
using Installation_v2.PresentationLogic.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fakes;

namespace Tests.UseCases {
    [TestClass]
    public class EndUCTests {
         private InstallState installState;

        [TestInitialize]
        public void TestInitialize() {
            installState = new InstallState(new ServiceLocatorFake());
        }

        [TestMethod]
        public void ShouldInitEndUseCase() {
             var useCase = new EndUseCase(installState);
            useCase.Run();

            var state = useCase.BaseViewState;

            Assert.AreEqual("Завершение установки", state.StepCaption);
            Assert.AreEqual("Спасибо, что выбрали нас", state.StepInstructions);

            Assert.IsFalse( state.NextStepVisible);
            Assert.IsFalse(state.PrevStepVisible);

            Assert.AreEqual(TrackName.Finish, state.TrackName);
            Assert.AreEqual("Закончить", state.FinishStepCaption);

            Assert.IsNotNull(state.CancelStepAction);
        }
    }
}
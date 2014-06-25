using System;
using Installation_v2.InstallationLogic;
using Installation_v2.InstallationLogic.Enums;
using Installation_v2.PresentationLogic;
using Installation_v2.PresentationLogic.Enums;
using Installation_v2.PresentationLogic.RemoveTempUC;
using Installation_v2.PresentationLogic.RemoveTempUC.DataState;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fakes;

namespace Tests.UseCases {
    [TestClass]
    public class RemoveTempUCTests {
        private InstallState installState;

        [TestInitialize]
        public void TestInitialize() {
            installState = new InstallState(new ServiceLocatorFake());
        }

        [TestMethod]
        public void ShouldInitRemoveTempUC() {
            var useCase = new RemoveTempUseCase(installState);
            useCase.Run();

            var state = ((RemoveTempViewState) useCase.BaseViewState);

            Assert.AreEqual("Завершение установки", state.StepCaption);
            Assert.AreEqual("Удаление временных файлов", state.StepInstructions);

            Assert.AreEqual(UseCaseNames.End, state.NextUseCase);
            Assert.AreEqual(UseCaseNames.Install, state.PrevUseCase);

            Assert.IsFalse(state.PrevStepVisible);
            Assert.IsFalse(state.NextStepVisible);

            Assert.AreEqual(TrackName.Install, state.TrackName);

            Assert.IsNull(state.CancelStepAction);
        }

        [TestMethod]
        public void ItemListToDeleteWhenInstall() {
            var useCase = new RemoveTempUseCase(installState);
            useCase.Run();

            var state = ((RemoveTempViewState) useCase.BaseViewState);

            Assert.AreEqual(1, state.Requirements.Count);
            Assert.AreEqual("Удаление временных файлов", state.Requirements[0].Caption);
        }

        [TestMethod]
        public void ItemListToDeleteWhenDelete() {
            installState.InstallationType = InstallationType.Delete;
            var useCase = new RemoveTempUseCase(installState);
            useCase.Run();

            var state = ((RemoveTempViewState) useCase.BaseViewState);

            Assert.AreEqual(4, state.Requirements.Count);
            Assert.AreEqual("Удаление временных файлов", state.Requirements[0].Caption);
            Assert.AreEqual("Удаление установленных файлов", state.Requirements[1].Caption);
            Assert.AreEqual("Удаление ключей реестра", state.Requirements[2].Caption);
            Assert.AreEqual("Удаление ключей реестра", state.Requirements[3].Caption);
        }

        [TestMethod]
        public void ItemListToDeleteWhenCancel() {
            installState.InstallationType = InstallationType.Cancel;
            var useCase = new RemoveTempUseCase(installState);
            useCase.Run();

            var state = ((RemoveTempViewState) useCase.BaseViewState);

            Assert.AreEqual(4, state.Requirements.Count);
            Assert.AreEqual("Удаление временных файлов", state.Requirements[0].Caption);
            Assert.AreEqual("Удаление установленных файлов", state.Requirements[1].Caption);
            Assert.AreEqual("Удаление ключей реестра", state.Requirements[2].Caption);
            Assert.AreEqual("Удаление ключей реестра", state.Requirements[3].Caption);
        }

        [TestMethod]
        public void MoveOnEndUCAfterRemovingTempFiles() {
            var helper = new UseCaseRunnerHelper();
            helper.Run(UseCaseNames.RemoveTemp);

            Assert.AreEqual(UseCaseNames.RemoveTemp, helper.CurrentUseCaseName);

            var useCase = ((RemoveTempUseCase) helper.CurrentUseCase);
            
            useCase.Tick(new object(), new EventArgs());
            useCase.Tick(new object(), new EventArgs());

            Assert.AreEqual(UseCaseNames.End, helper.CurrentUseCaseName);
        }
    }
}
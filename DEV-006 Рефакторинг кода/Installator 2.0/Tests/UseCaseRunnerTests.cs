using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Installation_v2.PresentationLogic;
using Installation_v2.PresentationLogic.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fakes;

namespace Tests {
    [TestClass]
    public class UseCaseRunnerTests {
        private InstallStateFake installState;

        [TestInitialize]
        public void TestInitialize() {
            installState = new InstallStateFake();
        }

        [TestMethod]
        public void ShouldRunFirstUseCaseFromCollection() {
            var runner = new UseCaseRunner(new ServiceLocatorFake()) {
                                               OnStepView = (i => { }), 
                                               OnStep = (i => { })
                                           };

            var type = runner.GetType();
            var currentUseCase = type.GetField("currentUseCase", BindingFlags.Instance | BindingFlags.NonPublic);
            var currentName = type.GetField("currentName", BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.IsNull(currentUseCase.GetValue(runner));

            runner.RunNext(true);

            Assert.IsNotNull(currentUseCase.GetValue(runner));
            Assert.AreEqual(UseCaseNames.Welcome, currentName.GetValue(runner));
        }

//        [TestMethod]
//        public void name() {
//            var files = new List<string>(Directory.GetFiles(@"D:\Project\Grande\Grande\bin\Debug"));
//           
//            var text = File.CreateText(@"C:\Users\Andrey\Documents\text.txt");
//            files.ForEach(i => 
//                              text.WriteLine(string.Format("\"{0}\",",  Path.GetFileName(i)))            
////                Console.WriteLine(string.Format("\"{0}\",", i))
//                          );
//            text.Flush();
//            text.Close();
//
//        }

    }
}
using System;
using System.Fakes;
using ClassLibrary1;
using ClassLibrary1.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            using (ShimsContext.Create()) {
                ShimDateTime.NowGet = () => new DateTime(2010, 01, 01);
                Assert.AreEqual(DateTime.Now, new DateTime(2010, 01, 01));
            }
        }

        [TestMethod]
        public void TestMethod2() {
            using (ShimsContext.Create()) {
                ShimClass1.GetAnswer = () => 5;
                Assert.AreEqual(Class1.GetAnswer(), 5);
            }

            Assert.AreEqual(Class1.GetAnswer(), 42);
        }
    }
}
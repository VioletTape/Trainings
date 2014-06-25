using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Commons;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace MEFTests {
    [TestFixture]
    public class SomeTests {
        [Test]
        public void Test0() {
            var myClass = new MyClass();
            myClass.Init();

            foreach (var service in myClass.Services) {
                service.Value.Do(1);
            }
        }

        [Test]
        public void Test1() {
            var mock = new Mock<IService>();
            mock.Setup(i => i.Name).Returns("Fake");

            var container = new CompositionContainer(CompositionOptions.DisableSilentRejection | CompositionOptions.IsThreadSafe);
            container.ComposeExportedValue(mock.Object);

            var classUnderTest = new MyClass();
            var batch = new CompositionBatch();
            batch.AddPart(classUnderTest);
            container.Compose(batch);

            classUnderTest.Init(container);

            Assert.AreEqual("Fake", classUnderTest.Services[0].Value.Name);

            classUnderTest.Services[0].Value.Name
                .Should()
                .Be("Fake");
        }
    }
}
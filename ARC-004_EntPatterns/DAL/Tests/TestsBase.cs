using Application;
using NUnit.Framework;

namespace Tests {
    [TestFixture]
    public class TestsBase {
          [TestFixtureSetUp]
        public void Init() {
            new Explorer().RegisterAll();
        }
    }
}
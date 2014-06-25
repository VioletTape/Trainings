using FluentAssertions;
using NUnit.Framework;

namespace CalculusDepends {
    [TestFixture]
    public class CalculatorTests {
        private Calculator calc;

        [TestFixtureSetUp]
        public void Setup() {
            calc = new Calculator();
        }

        [Test]
        public void CanSumUpNumbers() {
            calc.Sum(2, 4)
                .Should().Be(6);
        }

        [Test]
        public void CanSubWithZero() {
            calc.Sub(3, 0)
                .Should().Be(3);
        }

        [Test]
        public void CanStoreInMemory()
        {
            calc.SetMemory(calc.Sum(3, 0));
            calc.GetMemory()
                .Should().Be(3);
        }

        [Test]
        public void CanSumUpWithZero()
        {
            calc.Sum(3, 0)
                .Should().Be(3);
        }

        [Test]
        public void CanWipeMemory()
        {
            calc.SetMemory(-3);
            calc.ClearMemory();

            calc.GetMemory()
                .Should().Be(0);
        }
    }
}
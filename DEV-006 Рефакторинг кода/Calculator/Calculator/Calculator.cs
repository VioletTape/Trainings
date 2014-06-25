using System;
using FluentAssertions;
using NUnit.Framework;

namespace Calculator {
    public class Calculator {
        public int Sum(int x, int y) {
            checked {
                return x + y;
            }
        }
    }

    [TestFixture]
    public class SumTests {
        private Calculator calc = new Calculator();

        [Test]
        public void PositivesSimple() {
            calc.Sum(1, 1)
                .Should()
                .Be(2);
        }

        [Test]
        public void NegativeSimple() {
            calc.Sum(-1, -1)
                .Should()
                .Be(-2);
        }

        [Test]
        public void PositiveWithZero() {
            calc.Sum(1, 0)
                .Should()
                .Be(1);
        }

        [Test]
        public void NegativeWithZero() {
            calc.Sum(-1, 0)
                .Should()
                .Be(-1);
        }

        [Test]
        public void NegativeWithPositive() {
            calc.Sum(-2, 3)
                .Should()
                .Be(1);
        }

        [Test]
        [ExpectedException(typeof (OverflowException))]
        public void PositivesInfToInf() {
            calc.Sum(int.MaxValue, 1);
        }

        [Test]
        public void PositivesInfWithMinusOne() {
            calc.Sum(int.MaxValue, -1)
                .Should()
                .Be(int.MaxValue - 1);
        }

        [Test]
        [ExpectedException(typeof (OverflowException))]
        public void NegativesInfToInf() {
            calc.Sum(int.MinValue, -1);
        }

        [Test]
        public void NegativesInfWithOne() {
            calc.Sum(int.MinValue, 1)
                .Should()
                .Be(int.MinValue + 1);
        }

        [Test]
        public void OrderOf_X_and_Y_have_no_influence() {
            calc.Sum(-2, 3)
                .Should()
                .Be(calc.Sum(3, -2));
        }
    }
}
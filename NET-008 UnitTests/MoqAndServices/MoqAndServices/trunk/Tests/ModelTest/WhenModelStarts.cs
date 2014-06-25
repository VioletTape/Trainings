using System.Text;
using Application.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.ModelTest {
    [TestFixture]
    public class WhenModelStarts : ModelTestBase {
        [Test]
        public void ItShouldShowMainMenu() {
            // Arrange
            var actual = new StringBuilder();
            var expected = new StringBuilder();

            expected.AppendLine("Welcome");
            expected.AppendLine("");
            expected.AppendLine("Select option:");
            expected.AppendLine("--------------------------------------------------");
            expected.AppendLine("1. Get Customers");
            expected.AppendLine("2. Get Orders");
            expected.AppendLine("3. Get Items");
            expected.AppendLine("");

            // Act
            var model = new Model {
                          Print = i => actual.AppendLine(i)
                      };
            model.InitModel();

            // Assert
            actual.ToString().Should().Be(expected.ToString());
        }
    }
}
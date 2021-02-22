using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class BattleSettingsModelTests
    {
        [Test]
        public void BattleSettingsModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BattleSettingsModel();

            // Reset

            // Assert
            Assert.AreEqual("Simple Next", result.BattleModeEnum.ToMessage());
        }
    }
}

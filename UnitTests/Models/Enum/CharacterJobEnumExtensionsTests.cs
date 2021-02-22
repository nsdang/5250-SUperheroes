using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class CharacterJobEnumExtensionsTests
    {
        [Test]
        public void CharacterJobEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Player", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Fighter_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Fighter.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Player", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Cleric_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Cleric.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Player", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Flying_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Flying.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Flying", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Psychic_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Psychic.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Psychic", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Physical_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Physical.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Physical", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Light_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Light.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Light", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Dark_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Dark.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Dark", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Carpenter_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Carpenter.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Carpenter", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Accountant_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Accountant.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Accountant", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Vet_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Vet.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Vet", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_McDonaldsEmployee_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.McDonaldsEmployee.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("McDonaldsEmployee", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Boss_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Boss.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Boss", result);
        }
    }
}

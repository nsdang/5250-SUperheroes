using System.Linq;

using NUnit.Framework;

using Game.Models;

namespace UnitTests.Helpers
{
    [TestFixture]
    class CharacterJobEnumHelperTests
    {
        
        [Test]
        public void CharacterJobEnumHelper_GetListHeroJob_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnumHelper.GetListHeroJob;

            // Assert
            Assert.AreEqual(5,result.Count());

            // Assert
        }


        [Test]
        public void CharacterJobEnumHelper_GetListMonsterJob_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnumHelper.GetListMonsterJob;

            // Assert
            Assert.AreEqual(5, result.Count());

            // Assert
        }


        [Test]
        public void CharacterJobEnumHelper_ConvertStringToEnum_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnumHelper.ConvertStringToEnum("Flying");

            // Assert
            Assert.AreEqual(CharacterJobEnum.Flying, result);

            // Assert
        }
    }
}
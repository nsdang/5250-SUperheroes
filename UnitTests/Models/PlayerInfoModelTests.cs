using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class PlayerInfoModelTests
    {
        [Test]
        public void PlayerInfoModel_Constructor_Default_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel();

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            
            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Monster_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_Fighter_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.Fighter};

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_Cleric_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.Cleric};

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_Unknown_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.Unknown };

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_IsAbilityAvailable_Available_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });

            // Act
            var result = data.IsAbilityAvailable(AbilityEnum.Heal);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void PlayerInfoModel_IsAbilityAvailable_Available_Zero_Should_Fail()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.Heal] = 0;

            // Act
            var result = data.IsAbilityAvailable(AbilityEnum.Heal);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void PlayerInfoModel_SelectHealingAbility_Cleric_Heal_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.Heal] = 1;

            data.CurrentHealth = 1;
            data.MaxHealth = 100;

            // Act
            var result = data.SelectHealingAbility();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Heal, result);
        }

        [Test]
        public void PlayerInfoModel_SelectHealingAbility_Cleric_Heal_Not_Needed_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.Heal] = 1;

            data.CurrentHealth = 100;
            data.MaxHealth = 100;

            // Act
            var result = data.SelectHealingAbility();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }

        [Test]
        public void PlayerInfoModel_SelectHealingAbility_Cleric_Heal_Not_Available_Should_Return_Unknown()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.Heal] = 0;
            data.AbilityTracker[AbilityEnum.Bandage] = 0;

            data.CurrentHealth = 1;
            data.MaxHealth = 100;

            // Act
            var result = data.SelectHealingAbility();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }

        [Test]
        public void PlayerInfoModel_SelectHealingAbility_Fighter_Bandage_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Fighter });
            data.AbilityTracker[AbilityEnum.Bandage] = 1;

            data.CurrentHealth = 1;
            data.MaxHealth = 100;

            // Act
            var result = data.SelectHealingAbility();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Bandage, result);
        }

        [Test]
        public void PlayerInfoModel_SelectAbilityToUse_Fighter_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Fighter });
            data.AbilityTracker[AbilityEnum.Nimble] = 1;

            // Act
            var result = data.SelectAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Nimble, result);
        }

        [Test]
        public void PlayerInfoModel_SelectAbilityToUse_Cleric_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.Quick] = 1;

            // Act
            var result = data.SelectAbilityToUse();

            // Reset

            // Assert
        }

        [Test]
        public void PlayerInfoModel_SelectAbilityToUse_Monster_Should_Return_False()
        {
            // Arrange
            var data = new PlayerInfoModel(new MonsterModel());

            // Act
            var result = data.SelectAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }

        [Test]
        public void PlayerInfoModel_SelectAbilityToUse_Cleric_Heal_Should_Skip()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.Quick] = 0;
            data.AbilityTracker[AbilityEnum.Barrier] = 0;
            data.AbilityTracker[AbilityEnum.Curse] = 0;

            // Act
            var result = data.SelectAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }

        [Test]
        public void PlayerInfoModel_UseAbility_Invalid_Ability_Should_Not_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new MonsterModel());

            // Act
            var result = data.UseAbility(AbilityEnum.Unknown);

            // Reset

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void PlayerInfoModel_UseAbility_Unknown_Ability_Should_Not_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new MonsterModel());
            data.AbilityTracker.Add(AbilityEnumHelper.ConvertStringToEnum("Unknown"), 0);

            // Act
            var result = data.UseAbility(AbilityEnum.Unknown);

            // Reset

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void PlayerInfoModel_UseAbility_None_Ability_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new MonsterModel());
            data.AbilityTracker.Add(AbilityEnumHelper.ConvertStringToEnum("None"), 1);

            // Act
            var result = data.UseAbility(AbilityEnum.None);

            // Reset

            // Assert
            Assert.True(result);
        }

        [Test]
        public void PlayerInfoModel_UseAbility_Heal_Ability_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel{ Job = CharacterJobEnum.Cleric });

            // Act
            var result = data.UseAbility(AbilityEnum.Heal);

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void PlayerInfoModel_UseAbility_Quick_Ability_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });

            // Act
            var result = data.UseAbility(AbilityEnum.Quick);

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void PlayerInfoModel_UseAbility_Barrier_Ability_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });

            // Act
            var result = data.UseAbility(AbilityEnum.Barrier);

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void PlayerInfoModel_UseAbility_Curse_Ability_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });

            // Act
            var result = data.UseAbility(AbilityEnum.Curse);

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void PlayerInfoModel_UseAbility_Bandage_Ability_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new MonsterModel());

            // Act
            var result = data.UseAbility(AbilityEnum.Bandage);

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void PlayerInfoModel_UseAbility_Nimble_Ability_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel{ Job = CharacterJobEnum.Fighter });

            // Act
            var result = data.UseAbility(AbilityEnum.Nimble);

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

    }
}
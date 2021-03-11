using NUnit.Framework;

using Game;
using Game.Models;
using System.Threading.Tasks;
using Game.ViewModels;
using Game.Views;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;

namespace Scenario
{
    [TestFixture]
    public class HackathonScenarioTests
    {
        #region TestSetup
        readonly BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;
        BattlePage page;
        App app;

        [SetUp]
        public void Setup()
        {
            // Choose which engine to run
            EngineViewModel.SetBattleEngineToGame();

            // Put seed data into the system for all tests
            EngineViewModel.Engine.Round.ClearLists();

            //Start the Engine in AutoBattle Mode
            EngineViewModel.Engine.StartBattle(false);

            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            // Initialize Battle Page
            page = new BattlePage();

            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Default;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = false;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss = false;
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Scenario0
        [Test]
        public void HakathonScenario_Scenario_0_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      #
            *      
            * Description: 
            *      <Describe the scenario>
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      <List Files Changed>
            *      <List Classes Changed>
            *      <List Methods Changed>
            * 
            * Test Algrorithm:
            *      <Step by step how to validate this change>
            * 
            * Test Conditions:
            *      <List the different test conditions to make>
            * 
            * Validation:
            *      <List how to validate this change>
            *  
            */

            // Arrange

            // Act

            // Assert


            // Act
            var result = EngineViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Scenario0

        #region Scenario1
        [Test]
        public async Task HackathonScenario_Scenario_1_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      1
            *      
            * Description: 
            *      Make a Character called Mike, who dies in the first round
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      No Code changes requied 
            * 
            * Test Algrorithm:
            *      Create Character named Mike
            *      Set speed to -1 so he is really slow
            *      Set Max health to 1 so he is weak
            *      Set Current Health to 1 so he is weak
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify Mike is not in the Player List
            *      Verify Round Count is 1
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1, // Will go last...
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            //Act
            var result = await EngineViewModel.AutoBattleEngine.RunAutoBattle();

            //Reset
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(null, EngineViewModel.Engine.EngineSettings.PlayerList.Find(m => m.Name.Equals("Mike")));
            Assert.AreEqual(1, EngineViewModel.Engine.EngineSettings.BattleScore.RoundCount);
        }
        #endregion Scenario1

        #region Scenario2
        [Test]
        public async Task HackathonScenario_Scenario_2_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      2
            *      
            * Description: 
            *     Our Monster, Bob always missees when atacking
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      Override CalculateAttackStatus method from TurnEngine.cs
            * 
            * Test Algrorithm:
            *      Create Character named CharacterPlayerChicken
            *      Find Monster named "Bob"
            *      Call modified CalculateAttackStatus from TurnEngine.cs
            *      Set Current Health to 1 so he is weak
            *      
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Correct enum is retured from CalculateAttackStatus method
            */

            //Arrange

            // Set Character Conditions     
            var CharacterPlayerChicken = new PlayerInfoModel(
                new CharacterModel
                {
                    Speed = 1,
                    Level = 1,
                    CurrentHealth = 1,
                    ExperienceTotal = 1,
                    ExperienceRemaining = 1,
                    Name = "Chicken",
                });

            // Set Monster Conditions
            MonsterModel SillyGoose = Game.GameRules.DefaultData.LoadData(new MonsterModel()).Find(m => m.Name.Equals("Bob"));

            //Act
            var result = EngineViewModel.Engine.Round.Turn.CalculateAttackStatus(new PlayerInfoModel(SillyGoose), CharacterPlayerChicken);

            //Reset

            //Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }
        #endregion Scenario2
        #region Scenario34
        [Test]
        public async Task HackathonScenario_Scenario_34_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      34
            *      
            * Description: 
            *     Take 5 ...
            *     Allow characters to choose to do nothing for their turn, they just sit back and take in all that is happening around them. Resting restores 2 health per rest.
            * 
            * Changes Required (Classes, Methods etc.)  
            *       Added RestButton_Clicked() function to handle Rest button click 
            *       Added NextRestExample() contaning the main logic for the rest action
            * 
            * Test Algrorithm:
            *      Create Character named CharacterPlayer with current health 3 and max health 10
            *      Add the created character into PlayerList
            *      Call NextRestExample() from BattlePage.xaml.cs
            *      
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify the new current health retured from NextRestExample() method is greater than the old value
            *      2 value
            */

            //Arrange

            // Set Character Conditions     
            var CharacterPlayer = new PlayerInfoModel(
                new CharacterModel
                {
                    Speed = 1,
                    Level = 1,
                    CurrentHealth = 3,
                    MaxHealth = 10,
                    ExperienceTotal = 1,
                    ExperienceRemaining = 1,
                    Name = "Lazy",
                });
            EngineViewModel.Engine.EngineSettings.PlayerList.Clear();
            EngineViewModel.Engine.EngineSettings.PlayerList.Add(CharacterPlayer);


            //Act
            page.NextRestExample();
            var result = EngineViewModel.Engine.EngineSettings.CurrentAttacker.CurrentHealth;

            //Reset

            //Assert
            Assert.AreEqual(5, result);
        }
        #endregion Scenario34


        #region Scenario14

        [Test]
        public async Task HackathonScenario_Scenario_14_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      14
            *      
            * Description: 
            *     There is a switch that enables fighting one big boss
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      Added a condition on the AddMonstersToRound() and make a boolean variable on EngineettingsModel
            * 
            * Test Algrorithm:
            *      Create a button that activates boss round in pickCharacters
            *      If clicked, it will change the boolean IsBossEnabled to true
            *      
            *      
            *      
            * 
            * Test Conditions:
            *      Clear the list of momsters
            *      Force the dice to have a value of 6
            *      Set the isBossEnabled boolean to true
            *      Call the AddMonstersToRound() 
            *      Check if only one monster is returned
            * 
            * Validation:
            *      Verify Correct enum is retured from CalculateAttackStatus method
            */

            // Arrange
            BattleEngineViewModel.Instance.Engine.Round.ClearLists();
            Game.Helpers.DiceHelper.ForceRollsToNotRandom = true;
            Game.Helpers.DiceHelper.EnableForcedRolls();
            int result = Game.Helpers.DiceHelper.SetForcedRollValue(6);
            BattleEngineViewModel.Instance.Engine.EngineSettings.isBossEnabled = true;

            // Act
            int count = BattleEngineViewModel.Instance.Engine.Round.AddMonstersToRound();

            // Reset

            // Assert
            Assert.AreEqual(1, count);

            #endregion Scenario14
        }
    }
}
﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using Game.ViewModels;
using Game.Models;

namespace UnitTests.Views
{
    [TestFixture]
    public class PickItemsPageTests
    {
        App app;
        PickItemsPage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            // For now, set the engine to the Koenig Engine, change when ready 
            BattleEngineViewModel.Instance.SetBattleEngineToKoenig();

            page = new PickItemsPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void PickItemsPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PickItemsPage_CloseButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.CloseButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_CloseButton_Clicked_NotNull_Default_Should_Pass()
        {
            // Arrange
            PlayerInfoModel pm = new PlayerInfoModel(new CharacterModel());

            ItemModel item = Game.GameRules.DefaultData.LoadData(new ItemModel()).FirstOrDefault();

            page.selectedCharacter = pm;
            page.selectedItem = item;

            // Act
            page.CloseButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_CreatePlayerDisplayBox_Null_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.CreatePlayerDisplayBox(null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_Constructor_DropList_NotNull_Default_Should_Pass()
        {
            // Arrange
            ItemModel item = Game.GameRules.DefaultData.LoadData(new ItemModel()).FirstOrDefault();

            // Act
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(item);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void PickItemsPage_GetItemToDisplay_Null_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page.GetItemToDisplay(null);

            // Reset

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void PickItemsPage_GetItemToDisplay_Empty_Id_Should_Pass()
        {
            // Arrange
            ItemModel item = new ItemModel();
            item.Id = "";

            // Act
            var result = page.GetItemToDisplay(item);

            // Reset

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void PickItemsPage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.Head);
            var StackItem = page.GetItemToDisplay(item);
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_CreatePlayerDisplayBox_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            PlayerInfoModel pm = new PlayerInfoModel(new CharacterModel());
            var StackItem = page.CreatePlayerDisplayBox(pm);
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_DrawCharacterList_Valid_Should_Pass()
        {
            // Arrange

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.CharacterModelDeathList.Add(new PlayerInfoModel(new CharacterModel()));

            // Draw the Monsters
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.MonsterModelDeathList.Add(new PlayerInfoModel(new CharacterModel()));

            // Do it two times
            page.DrawCharacterList();

            // Act
            page.DrawCharacterList();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_DrawDropList_Valid_Should_Pass()
        {
            // Arrange

            // Draw the Items
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(new ItemModel());
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Add(new ItemModel());

            // Draw two times
            page.DrawDropList();

            // Act 
            page.DrawDropList();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        [Test]
        public void PickItemsPage_GetItemToDisplay_Click_Button_Valid_Items_Should_Pass()
        {
            // Arrange
            var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.Head);
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Add(item);
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Add(item);
            FlexLayout l = (FlexLayout) page.FindByName("ItemListSelectedFrame");
            l.Children.Add(new Label());
            var StackItem = page.GetItemToDisplay(item);
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();
            

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_DrawDropList_Valid_Not_Null_Should_Pass()
        {
            // Arrange
            CharacterModel cm = Game.GameRules.DefaultData.LoadData(new CharacterModel()).FirstOrDefault();
            PlayerInfoModel pm = new PlayerInfoModel(cm);
            pm.Alive = false;
            // Draw the Items
            BattleEngineViewModel.Instance.Engine.Round.Turn.DropItems(pm);

            // Draw two times
            page.DrawDropList();

            // Act 
            page.DrawDropList();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void PickItemsPage_DrawUniqueDropList_Valid_Not_Null_Should_Pass()
        {
            // Arrange
            MonsterModel mm = Game.GameRules.DefaultData.LoadData(new MonsterModel()).Find(n => n.Name.Equals("Anais"));
            PlayerInfoModel pm = new PlayerInfoModel(mm);
            pm.Alive = false;
            // Draw the Items
            BattleEngineViewModel.Instance.Engine.Round.Turn.DropItems(pm);

            // Draw two times
            page.DrawUniqueDropList();

            // Act 
            page.DrawUniqueDropList();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void PickItemsPage_DrawCharacterList_Valid_Not_Null_Should_Pass()
        {
            // Arrange
            CharacterModel cm = Game.GameRules.DefaultData.LoadData(new CharacterModel()).FirstOrDefault();
            PlayerInfoModel pm = new PlayerInfoModel(cm);
            page.selectedItem = new ItemModel();
      
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(pm);

            // Act 
            page.DrawCharacterList();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_CreatePlayerDisplayBox_Click_Button_selectedItem_Valid_Should_Pass()
        {
            // Arrange
            PlayerInfoModel pm = new PlayerInfoModel(new CharacterModel());
            var StackItem = page.CreatePlayerDisplayBox(pm);
            var dataImage = StackItem.Children[0];
            page.selectedItem = new ItemModel();

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_GetItemToDisplay_Click_Button_Valid_selectedCharacter_Items_Should_Pass()
        {
            // Arrange
            var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.Head);
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Add(item);
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Add(item);
            FlexLayout l = (FlexLayout)page.FindByName("ItemListSelectedFrame");
            l.Children.Add(new Label());
            var StackItem = page.GetItemToDisplay(item);
            var dataImage = StackItem.Children[0];
            page.selectedCharacter = new PlayerInfoModel(new CharacterModel());

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();


            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}
﻿using NUnit.Framework;

using Game;
using Game.Views;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Game.ViewModels;
using System.Threading.Tasks;

namespace UnitTests.Views
{
    [TestFixture]
    public class CharacterIndexPageTests : CharacterIndexPage
    {
        App app;
        CharacterIndexPage page;

        public CharacterIndexPageTests() : base(true) { }
        
        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new CharacterIndexPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        
        [Test]
        public void CharacterIndexPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CharacterIndexPage_AddCharacter_Clicked_Default_Should_Pass()
        {
            // Arrange

           // Act
            page.AddCharacter_Clicked(null, null);

            // Reset

           // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterIndexPage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        
        /*
        [Test]
        public void CharacterIndexPage_OnCharacterSelected_Clicked_Default_Should_Pass()
        {
            // Arrange

            var selectedCharacter = new CharacterModel();

            var selectedCharacterChangedEventArgs = new SelectedItemChangedEventArgs(selectedCharacter, 0);

            // Act
            page.OnItemSelected(null, selectedCharacterChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterIndexPage_OnCharacterSelected_Clicked_Invalid_Null_Should_Fail()
        {
            // Arrange

            var selectedCharacterChangedEventArgs = new SelectedItemChangedEventArgs(null, 0);

            // Act
            page.OnItemSelected(null, selectedCharacterChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        
        */
        [Test]
        public void CharacterIndexPage_OnAppearing_Valid_Should_Pass()
        {
            // Arrange
            CharacterIndexViewModel ViewModel = CharacterIndexViewModel.Instance;

            // Act
            OnAppearing();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterIndexPage_OnAppearing_Valid_Empty_Should_Pass()
        {
            // Arrange

            CharacterIndexViewModel ViewModel = CharacterIndexViewModel.Instance;
            ViewModel.Dataset.Clear();

            // Act
            OnAppearing();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        /*
        [Test]
        public void CharacterIndexPage_AddItemClicked_Valid_Should_Pass()
        {
            // Arrange
            // Act
            page.AddItem_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        */

        //[Test]
        //public void CharacterIndexPage_OnImageClicked_Clicked_Default_Should_Pass()
        //{
        //    // Arrange

        //    var selectedCharacter = new CharacterModel();

        //    var selectedCharacterChangedEventArgs = new SelectedItemChangedEventArgs(selectedCharacter, 0);

        //    // Act
        //    page.OnImageClicked(null, selectedCharacterChangedEventArgs);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}


        //[Test]
        //public void CharacterIndexPage_OnImageClicked_Clicked_Null_Should_Return_Null()
        //{
        //    // Arrange
        //    var selectedCharacter = new CharacterModel();

        //    // Act
        //    page.OnImageClicked(null, null);

        //    //Reset

        // Assert
        //    Assert.IsTrue(true);
        //}


        //    // Assert
        //    Assert.IsTrue(true);
        //}

        /*
        [Test]
        public void CharacterIndexPage_OnImageDeleted_Clicked_Null_Should_Return_Null()
        {
            // Arrange
            var selectedCharacter = new CharacterModel();

            // Act
            page.OnImageDeleted(null, null);

            //Reset

            // Assert
            Assert.IsTrue(true);
        }
        */

        [Test]
        public void CharacterIndexPage_OnImageClicked_Clicked_Null_Should_Return_Null()
        {
            // Arrange
 
            ImageButton img = new ImageButton();
            // Act
            page.OnImageClicked(img, null);

            //Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterIndexPage_OnImageClicked_Clicked_Not_Null_Should_Pass()
        {
            // Arrange

            ImageButton img = new ImageButton();
            CharacterModel cm = new CharacterModel();
            img.BindingContext = cm;

            // Act
            page.OnImageClicked(img, null);

            //Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterIndexPage_OnImageDeleted_Clicked_Null_Should_Return_Null()
        {
            // Arrange

            ImageButton img = new ImageButton();
            // Act
            page.OnImageDeleted(img, null);

            //Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterIndexPage_OnImageDeleted_Clicked_Not_Null_Should_Pass()
        {
            // Arrange

            ImageButton img = new ImageButton();
            CharacterModel cm = new CharacterModel();
            img.BindingContext = cm;

            // Act
            page.OnImageDeleted(img, null);

            //Reset

            // Assert
            Assert.IsTrue(true);
        }
    }
}
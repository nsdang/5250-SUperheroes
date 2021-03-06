﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Models;
using Game.ViewModels;
using Game.Views;

namespace UnitTests.ViewModels
{
    [TestFixture]
    public class GenericViewModelTests
    {
        [Test]
        public void GenericViewModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new GenericViewModel<ItemModel>();
            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GenericViewModel_Constructor_Valid_Data_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            data.Name = "test";

            // Act
            var result = new GenericViewModel<ItemModel>(data);
            // Reset

            // Assert
            Assert.AreEqual("test", result.Data.Name);
        }

        [Test]
        public void GenericViewModel_Constructor_Valid_Data__Null_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            data.Name = null;

            // Act
            var result = new GenericViewModel<ItemModel>(data);
            // Reset

            // Assert
            Assert.AreEqual(null, result.Data.Name);
        }

        [Test]
        public void GenericViewModel_Set_Get_HandItemList_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            List<string> list = new List<string>();

            // Act
            var result = new GenericViewModel<ItemModel>(data);
            result.HandItemList = list;
            // Reset

            // Assert
            Assert.AreEqual(list, result.HandItemList);
        }

        [Test]
        public void GenericViewModel_Set_Get_FingerItemList_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            List<string> list = new List<string>();

            // Act
            var result = new GenericViewModel<ItemModel>(data);
            result.FingerItemList = list;
            // Reset

            // Assert
            Assert.AreEqual(list, result.FingerItemList);
        }

        [Test]
        public void GenericViewModel_Set_Get_HeadItemList_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            List<string> list = new List<string>();

            // Act
            var result = new GenericViewModel<ItemModel>(data);
            result.HeadItemList = list;
            // Reset

            // Assert
            Assert.AreEqual(list, result.HeadItemList);
        }
    }
}

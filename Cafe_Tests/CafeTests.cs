using System;
using System.Collections.Generic;
using Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Tests
{
    [TestClass]
    public class CafeTests
    {
        [TestMethod]
        public void CreateMenuItem_ShouldReturnCorrectBoolean()
        {
            CafeObject menuItem = new CafeObject();
            CafeRepository menuDirectory = new CafeRepository();
            bool createResult = menuDirectory.AddNewMenuItem(menuItem);
            Assert.IsTrue(createResult);
        }
        [TestMethod]
        public void ShowAllMenuItems_ShouldReturnCorrectBoolean()
        {
            CafeObject menuItem = new CafeObject();
            CafeRepository menuDirectory = new CafeRepository();
            menuDirectory.AddNewMenuItem(menuItem);
            List<CafeObject> menuItems = menuDirectory.ShowAllMenuItems();
            bool menuHasItems = menuItems.Contains(menuItem);
            Assert.IsTrue(menuHasItems);
        }
        private CafeRepository _cafeRepository;
        private CafeObject _cafeObject;
        [TestInitialize]
        public void Arrange()
        {
            _cafeRepository = new CafeRepository();
            _cafeObject = new CafeObject("macaroni", "cheese and pasta", 1, 5);
            _cafeRepository.AddNewMenuItem(_cafeObject);
        }
        [TestMethod]
        public void GetMenuItemByOrderNumber_ShouldReturnCorrectMenuItem()
        {
            CafeObject menuItem = _cafeRepository.GetMenuItemByOrderNumber(1);
            Assert.AreEqual(_cafeObject, menuItem);
        }
        [TestMethod]
        public void DeleteMenuItem_ShouldReturnCorrectBoolean()
        {
            CafeObject deleteObject = _cafeRepository.GetMenuItemByOrderNumber(1);
            bool deleteResult = _cafeRepository.DeleteMenuItem(deleteObject);
            Assert.IsTrue(deleteResult);
        }
    }
}

﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Controllers;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class IndicatesSelectedCategory
    {
        [TestMethod]
        public void Indicates_Selected_Category()
        {
            // Arrange 
            // - create the mock repository 
                Mock<IProductRepository> mock = new Mock<IProductRepository>();
                mock.Setup(m => m.Products).Returns(new Product[] { 
            new Product {ProductID = 1, Name = "P1", Category = "Apples"}, 
            new Product {ProductID = 4, Name = "P2", Category = "Oranges"}, 
            }.AsQueryable());
            // Arrange - create the controller  
            NavController target = new NavController(mock.Object);
            // Arrange - define the category to selected 
            string categoryToSelect = "Apples";
            // Action 
            string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;
            // Assert 
            Assert.AreEqual(categoryToSelect, result);
        }
    }
}

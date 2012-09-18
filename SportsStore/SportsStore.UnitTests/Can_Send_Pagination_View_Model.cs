﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.Controllers;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
using Moq;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class CanSendPaginationViewModel
    {
       [TestMethod] 
       public void Can_Send_Pagination_View_Model() { 
            // Arrange 
            // - create the mock repository 
            Mock<IProductRepository> mock = new Mock<IProductRepository>(); 
            mock.Setup(m => m.Products).Returns(new Product[] { 
                new Product {ProductID = 1, Name = "P1"}, 
                new Product {ProductID = 2, Name = "P2"}, 
                new Product {ProductID = 3, Name = "P3"}, 
                new Product {ProductID = 4, Name = "P4"}, 
                new Product {ProductID = 5, Name = "P5"} 
            }.AsQueryable()); 
            // Arrange - create a controller and make the page size 3 items 
            ProductController controller = new ProductController(mock.Object); 
            controller.PageSize = 3; 
            // Action 
            ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model; 
            // Assert 
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        } 
    }
}

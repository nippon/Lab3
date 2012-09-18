﻿using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 4; // We will change this later 
        private IProductRepository repository;
        public ProductController(IProductRepository repoParam)
        {
            repository = repoParam;
        }
        public ViewResult List(int page = 1)
        {
            return View(repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize));
        }
    }
} 

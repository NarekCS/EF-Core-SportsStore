using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        private ICategoryRepository catRepository;
        public HomeController(IRepository repo, ICategoryRepository catRepo)
        {
            repository = repo;
            catRepository = catRepo;
        }

        public IActionResult Index()
        {
           // System.Console.Clear();
            return View(repository.Products);
        }
      
        //[HttpPost]
        //public IActionResult AddProduct(Product product)
        //{
        //    repository.AddProduct(product);
        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult UpdateProduct(long key)
        {
            ViewBag.Categories = catRepository.Categories;
            return View(key == 0 ? new Product() : repository.GetProduct(key));
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (product.Id == 0)
                repository.AddProduct(product);
            else
                repository.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            repository.Delete(product);
            return RedirectToAction(nameof(Index));
        }

        //public IActionResult UpdateAll()
        //{
        //    ViewBag.UpdateAll = true;
        //    return View(nameof(Index), repository.Products);
        //}
        //[HttpPost]
        //public IActionResult UpdateAll(Product[] products)
        //{
        //    repository.UpdateAll(products);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}

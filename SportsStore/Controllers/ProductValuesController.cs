using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductValuesController : Controller
    {
        private IWebServiceRepository repository;
        public ProductValuesController(IWebServiceRepository repo) => repository = repo;

        [HttpGet("{id}")]
        public object GetProduct(long id)
        {
            return repository.GetProduct(id) ?? NotFound();
        }

        [HttpGet]
        public object Products(int skip, int take)
        {
            return repository.GetProducts(skip, take);
        }

        [HttpPost]
        public long StoreProduct(Product product)
        {
            return repository.StoreProduct(product);
        }

        [HttpPut]
        public void UpdateProduct(Product product)
        {
            repository.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(long id)
        {
            repository.DeleteProduct(id);
        }
    }
}

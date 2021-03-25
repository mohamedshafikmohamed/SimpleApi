using api2.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepos Iproductrepo;
     //   [HttpGet("{id}")]
        public ProductController(ProductRepos _Iproductrepo)
        {
            Iproductrepo = _Iproductrepo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<product>> GetProducts()
        {
           return Ok(Iproductrepo.GetProducts());
        }
        [HttpGet("{Id}")]
        public ActionResult<product> GetProduct(int id)
        {
           return Ok(Iproductrepo.GetProduct(id));
        }
        [HttpGet]
        [Route("GetProductByName/{name}")]
        public ActionResult<product> GetProductByName(string name)
        {
           return Ok(Iproductrepo.GetProductsByName(name));
        } 
        [HttpPut]
        public ActionResult<product> update(product p)
        {
            Iproductrepo.update(p);
           return Ok();
        } 
        [HttpPost]
        public ActionResult<product> Create(product p)
        {
            Iproductrepo.create(p);
           return Ok();
        } 
        [HttpDelete("{Id}")]
        public ActionResult<product> Delete(int id)
        {
            Iproductrepo.Delete(id);
           return Ok();
        }
    }
}

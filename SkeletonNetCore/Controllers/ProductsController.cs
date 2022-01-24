using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkeletonNetCore.Config;
using SkeletonNetCore.DAO.Impl;
using SkeletonNetCore.Services;
using SkeletonNetCore.Services.Impl;
using SkeletonNetCore.Services.Models;

namespace SkeletonNetCore.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductSvc productSvc;

        public ProductsController(ApiDbContext apiDbContext){

            productSvc = new ProductSvcImpl(new ProductDaoImpl(apiDbContext));

        }
        // GET api/values
        [HttpGet]
        public async Task<List<Product>> Get()
        {
             return await productSvc.getProducts();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {

            return Ok(await this.productSvc.saveProduct(product));

        }
    }
}

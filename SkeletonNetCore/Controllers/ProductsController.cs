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
        private readonly ISvc<Product> productSvc;

        public ProductsController(ApiDbContext apiDbContext)
        {
            productSvc = new ProductSvcImpl(new ProductDaoImpl(apiDbContext));
        }
        
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await productSvc.getAll();
        }
        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            return Ok(await this.productSvc.save(product));
        }
    }
}

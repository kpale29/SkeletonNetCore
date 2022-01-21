using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkeletonNetCore.Config;
using SkeletonNetCore.DAO.Impl;
using SkeletonNetCore.Models;
using SkeletonNetCore.Services;
using SkeletonNetCore.Services.Impl;
using SkeletonNetCore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkeletonNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ProductSvc productSvc;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApiDbContext apiDbContext)
        {
            _logger = logger;
            this.productSvc = new ProductSvcImpl(new ProductDaoImpl(apiDbContext));

        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await this.productSvc.getProducts();
        }



        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
  
            return Ok(await this.productSvc.saveProduct(product));
            
        }
    }
}

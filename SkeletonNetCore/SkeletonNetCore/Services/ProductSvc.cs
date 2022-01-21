using SkeletonNetCore.Models;
using SkeletonNetCore.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkeletonNetCore.Services
{
    public interface ProductSvc
    {
        public Task<int> saveProduct(Product product);

        public  Task<List<Product>> getProducts();    }
}

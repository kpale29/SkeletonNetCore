using System.Collections.Generic;
using System.Threading.Tasks;
using SkeletonNetCore.Services.Models;

namespace SkeletonNetCore.Services
{
    public interface ProductSvc
    {
        public Task<int> saveProduct(Product product);
        public Task<List<Product>> getProducts();    
    }
}
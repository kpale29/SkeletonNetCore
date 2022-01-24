using System.Collections.Generic;
using System.Threading.Tasks;
using SkeletonNetCore.Models;

namespace SkeletonNetCore.DAO
{
    public interface ProductDao {
         public Task<int> Save(ProductDto product);

        public Task<List<ProductDto>>  GetAll();
    }
}
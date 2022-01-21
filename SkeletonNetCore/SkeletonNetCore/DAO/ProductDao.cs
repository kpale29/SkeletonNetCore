using SkeletonNetCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkeletonNetCore.DAO.Impl
{
    public interface ProductDao {
        public Task<int> Save(ProductDTO product);

        public Task<List<ProductDTO>>  GetAll();
    }
}

using Microsoft.EntityFrameworkCore;
using SkeletonNetCore.Config;
using SkeletonNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkeletonNetCore.DAO.Impl
{
    public class ProductDaoImpl : ProductDao
    {
        ApiDbContext apiDbContext;
        public ProductDaoImpl(ApiDbContext apiDbContext)
        {
            this.apiDbContext = apiDbContext;
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            return await this.apiDbContext.ProductDto.ToListAsync();
            
        }

        public async Task<int> Save(ProductDTO user)
        {
            apiDbContext.Add(user);
            return await apiDbContext.SaveChangesAsync();
        }

       
    }
}

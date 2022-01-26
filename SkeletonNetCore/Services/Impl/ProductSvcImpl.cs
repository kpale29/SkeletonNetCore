using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkeletonNetCore.DAO;
using SkeletonNetCore.Models;
using SkeletonNetCore.Services.Models;

namespace SkeletonNetCore.Services.Impl
{
    public class ProductSvcImpl : ISvc<Product>
    {
        public IDao<ProductDto> product;
        public ProductSvcImpl(IDao<ProductDto> product)
        {
            this.product = product;
        }

        public async Task<List<Product>> getAll()
        {
            IEnumerable<ProductDto> products = await this.product.GetAll();
            return products.Select(product => new Product
            {
                id = product.id,
                description = product.description,
                img = product.img,
                name = product.name,
                review = product.review
            }).ToList();
        }

        public async Task<int> save(Product product)
        {
            ProductDto newProduct = new ProductDto();
            newProduct.name = product.name;
            newProduct.description = product.description;
            newProduct.img = product.img;
            newProduct.review = product.review;
            return await this.product.Save(newProduct);
        }
    }
}
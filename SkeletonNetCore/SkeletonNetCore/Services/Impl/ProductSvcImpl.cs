using SkeletonNetCore.DAO.Impl;
using SkeletonNetCore.Models;
using SkeletonNetCore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkeletonNetCore.Services.Impl
{
    public class ProductSvcImpl : ProductSvc
    {
        public ProductDao product;
        public ProductSvcImpl(ProductDao product)
        {
            this.product = product;
        }

        public async Task<List<Product>> getProducts()
        {
            IEnumerable<ProductDTO> products = await this.product.GetAll();
            return products.Select(product => new Product
            {
                id = product.id,
                description = product.description,
                img = product.img,
                name = product.name, 
                review  = product.review
               
            }).ToList();

        }

        public async Task<int> saveProduct(Product product)
        {
            ProductDTO newProduct = new ProductDTO();
            newProduct.name = product.name;
            newProduct.description = product.description;
            newProduct.img = product.img;
            newProduct.review = product.review;
            return await this.product.Save(newProduct);
        }
    }
}

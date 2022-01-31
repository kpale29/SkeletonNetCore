using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using SkeletonNetCore.Controllers;
using SkeletonNetCore.DAO;
using SkeletonNetCore.Models;
using SkeletonNetCore.Services.Impl;
using SkeletonNetCore.Services.Models;
using System.Text.Json;
using Xunit;

namespace SkeletonNetCore.Tests.ApiTests
{
    public class ProductTests
    {
        private List<ProductDto> dummyProductsDto = new List<ProductDto>()
            {
                new ProductDto() {id = 2, name = "Carlos", description = "This is a new desc", img = "/path/to/img", review = 3},
                new ProductDto() {id = 3, name = "Andree", description = "This is a new desc", img = "/path/to/img", review = 3},
                new ProductDto() {id = 4, name = "Kirk", description = "This is a new desc", img = "/path/to/img", review = 3},
                new ProductDto() {id = 1, name = "Pavel", description = "This is a new desc", img = "/path/to/img", review = 3},
                new ProductDto() {id = 5, name = "Kevin1", description = "This is a new desc", img = "/path/to/img", review = 3},
                new ProductDto() {id = 6, name = "Kevin2", description = "This is a new desc", img = "/path/to/img", review = 3},
                new ProductDto() {id = 7, name = "Javier", description = "This is a new desc", img = "/path/to/img", review = 3}
            };

        private ProductDto dummyProductDto = new ProductDto() { name = "Messi", description = "This is a new desc", img = "/path/to/img", review = 5 };
        private Product dummyProduct = new Product() { name = "Messi", description = "This is a new desc", img = "/path/to/img", review = 5 };

        public ProductTests()
        {
        }

        [Fact]
        public async Task Get_ShouldReturnAListOfProducts()
        {
            // Arrange
            var querySearch = "";
            var iDaoProductDto = new Mock<IDao<ProductDto>>();
            iDaoProductDto.Setup(prod => prod.GetAll()).ReturnsAsync(dummyProductsDto);
            var iSvcProduct = new ProductSvcImpl(iDaoProductDto.Object);
            var controller = new ProductsController(iSvcProduct);

            // Act
            var products = await controller.Get(querySearch);

            // Assert
            Assert.IsType<List<Product>>(products);
        }

        [Fact]
        public async Task Get_ShouldReturnAListOfProductsFiltered()
        {
            // Arrange
            var querySearch = "Pavel";
            var iDaoProductDto = new Mock<IDao<ProductDto>>();
            iDaoProductDto.Setup(prod => prod.GetAll()).ReturnsAsync(dummyProductsDto);
            var iSvcProduct = new ProductSvcImpl(iDaoProductDto.Object);
            var controller = new ProductsController(iSvcProduct);

            // Act
            var products = await controller.Get(querySearch);
            var expected = JsonSerializer.Serialize(products[0]);
            var actual = JsonSerializer.Serialize(new ProductDto() { id = 1, name = "Pavel", description = "This is a new desc", img = "/path/to/img", review = 3 });

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task Post_ShouldInsertASingleProduct()
        {
            //var builder = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            //var Configuration = builder.Build();
            //var dbContext = new DbContextOptionsBuilder<ApiDbContext>().UseNpgsql(Configuration.GetConnectionString("ConnectionStrings"));
            //var apiDbContext = new ApiDbContext(dbContext.Options);
            //var controller = new Controllers.ProductsController();
            //Product product = new Product();
            //product.name = "Pavel";
            //product.description = "This a new product";
            //product.img = "/path/to/image";
            //product.review = 5;
            //var postResult = await controller.Post(product);
            //Assert.Equal(1, postResult);

            // Arrange
            var iDaoProductDto = new Mock<IDao<ProductDto>>();
            iDaoProductDto.Setup(prod => prod.Save(It.Is<ProductDto>(d => d.name == dummyProductDto.name && d.description == dummyProductDto.description && d.img == dummyProductDto.img && d.review == dummyProductDto.review))).ReturnsAsync(1);
            var iSvcProduct = new ProductSvcImpl(iDaoProductDto.Object);
            var controller = new ProductsController(iSvcProduct);

            // Act
            var actual = await controller.Post(dummyProduct);
            var expected = 1;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}

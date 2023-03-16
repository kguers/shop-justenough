using AutoMapper;
using JustEnough.Controllers;
using JustEnough.Dto;
using JustEnough.Interfaces;
using JustEnough.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace JustEnough.Tests
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductRepository> _productRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _productRepoMock = new Mock<IProductRepository>();
            _mapperMock = new Mock<IMapper>();
            _controller = new ProductController(_productRepoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Title = "Product 1", Price = 10 },
                new Product { Id = 2, Title = "Product 2", Price = 20 }
            };
            var productDtos = new List<ProductDto>
            {
                new ProductDto { Id = 1, Title = "Product 1", Price = 10 },
                new ProductDto { Id = 2, Title = "Product 2", Price = 20 }
            };
            _productRepoMock.Setup(repo => repo.GetAll()).ReturnsAsync(products);
            _mapperMock.Setup(mapper => mapper.Map<List<ProductDto>>(products)).Returns(productDtos);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<List<ProductDto>>(okResult.Value);
            Assert.Equal(productDtos, model);
        }

        [Fact]
        public async Task GetById_WithExistingId_ReturnsOkResult_WithProduct()
        {
            // Arrange
            var id = 1;
            var product = new Product { Id = id, Title = "Product 1", Price = 10 };
            var productDto = new ProductDto { Id = id, Title = "Product 1", Price = 10 };
            _productRepoMock.Setup(repo => repo.ProductExists(id)).ReturnsAsync(true);
            _productRepoMock.Setup(repo => repo.GetById(id)).ReturnsAsync(product);
            _mapperMock.Setup(mapper => mapper.Map<ProductDto>(product)).Returns(productDto);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<ProductDto>(okResult.Value);
            Assert.Equal(productDto, model);
        }

        [Fact]
        public async Task GetById_WithNonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            var id = 1;
            _productRepoMock.Setup(repo => repo.ProductExists(id)).ReturnsAsync(false);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateProduct_WithValidProduct_ReturnsOkResult_WithSuccessMessage()
        {
            // Arrange
            var productDto = new ProductDto
            {
                Title = "New Product",
                Price = 10.99m
            };

            _productRepoMock.Setup(repo => repo.GetTitleTrimLower(It.IsAny<string>()))
                .ReturnsAsync(() => null);

            _productRepoMock.Setup(repo => repo.Create(It.IsAny<Product>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.CreateProduct(productDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Product created successfully", okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
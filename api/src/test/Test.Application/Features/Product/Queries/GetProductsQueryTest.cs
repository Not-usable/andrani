using Application.Features.GeoRequest.Querries;
using Application.Interfaces.Repositories;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Spv.ProjectName.Test.Application
{
    public class GetProductsQueryTest
    {
        [Fact]
        public async void Should_get_all_products()
        {
            // Arrange
            var command = new GetProductsQuerry();

            var entity1 = new Product { Id = 1, Description = "test1", Name = "test1" };
            var entity2 = new Product { Id = 2, Description = "test2", Name = "test2" };
            var entity3 = new Product { Id = 3, Description = "test3", Name = "test3" };
            var products = new List<Product>() { entity1, entity2, entity3 }.AsQueryable();

            var mapperConfig = new MapperConfiguration(opts =>
            {
                opts.AddProfile<GeneralProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            var fakeRepo = new Mock<IGeoRequestRepository>();
            fakeRepo.Setup(m => m.All()).Returns(products);

            // Act
            var res = await new GetProductCommandHandler(fakeRepo.Object, mapper).Handle(command, default);

            // Assert
            fakeRepo.Verify(x => x.All(), Times.Once());
            Assert.Equal(products.Count(), res.Count);
        }
    }
}

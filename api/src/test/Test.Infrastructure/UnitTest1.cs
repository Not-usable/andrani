using Application.Features.GeoRequest.Querries;
using Application.Interfaces.Repositories;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Contexts;
using Infrastructure.Repository.EfCore;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Spv.ProjectName.Test.Application
{
    public class Test
    {
        [Fact]
        public void Should_work()
        {
            // Arrange
            var command = new GetProductsQuerry();

            var entity1 = new Product { Id = 1, Description = "test1", Name = "test1" };
            var entity2 = new Product { Id = 2, Description = "test2", Name = "test2" };
            var entity3 = new Product { Id = 3, Description = "test3", Name = "test3" };
            var products = new List<Product>() { entity1, entity2, entity3 }.AsQueryable();

            var fakeDbSet = new Mock<DbSet<Product>>();
            fakeDbSet.Setup(dbs => dbs.AsQueryable()).Returns(products);

            var fakeDbContext = new Mock<BasicDbContext>(new DbContextOptionsBuilder().Options);
            fakeDbContext.Setup(dbc => dbc.Set<Product>()).Returns(fakeDbSet.Object);

            // Act
            var res = new GeoRequestRepository(fakeDbContext.Object).All();

            // Assert
            fakeDbSet.Verify(x => x.AsQueryable(), Times.Once());
            Assert.Equal(products.Count(), res.Count());
        }
    }
}

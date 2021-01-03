using Microsoft.AspNetCore.Mvc;
using Testing.Models;
using Testing.Controllers;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace Testing.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionIsDone()
        {
            //Arrange
            HomeController controller = new HomeController();
            List<Product> testData = new List<Product>(){
                new Product(){Name = "Ha", Price = 15},
                new Product(){Name = "Ho", Price = 25}
            };
            Mock<IDataSource> mock = new Mock<IDataSource>();
            mock.SetupGet(m => m.Products).Returns(testData);
            controller.dataSource = mock.Object;

            //Act
            IEnumerable<Product> result = controller.Index()?.ViewData.Model as IEnumerable<Product>;

            //Assert
            Assert.Equal(result, testData, MyComparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}
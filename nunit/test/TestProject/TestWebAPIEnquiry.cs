using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using dotnetapiapp.Controllers;
using dotnetapiapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
namespace dotnetapiapp.Tests
{
    [TestFixture]
    public class DeliveryControllerTests
    {
        private DeliveryController _DeliveryController;
        private OrderDeliveryDbContext _context;

        [SetUp]
        public void Setup()
        {
            // Initialize an in-memory database for testing
            var options = new DbContextOptionsBuilder<OrderDeliveryDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new OrderDeliveryDbContext(options);
            _context.Database.EnsureCreated(); // Create the database

            // Seed the database with sample data
            _context.Deliverys.AddRange(new List<Delivery>
            {
new Delivery { DeliveryID = 1,userId="101",EstablishmentDate=DateTime.Parse("2023-04-30"),DeliveryStatus=0,OrderId=100},
new Delivery { DeliveryID = 2,userId="102",EstablishmentDate=DateTime.Parse("2023-04-10"),DeliveryStatus=0,OrderId=50},
new Delivery { DeliveryID = 3,userId="103",EstablishmentDate=DateTime.Parse("2023-04-30"),DeliveryStatus=0,OrderId=10}
            });
            _context.SaveChanges();

            _DeliveryController = new DeliveryController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted(); // Delete the in-memory database after each test
            _context.Dispose();
        }
        [Test]
        public void DeliveryClassExists()
        {
            // Arrange
            Type DeliveryType = typeof(Delivery);

            // Act & Assert
            Assert.IsNotNull(DeliveryType, "Delivery class not found.");
        }
        [Test]
        public void Delivery_Properties_userId_ReturnExpectedDataTypes()
        {
            // Arrange
            Delivery delivery = new Delivery();
            PropertyInfo propertyInfo = delivery.GetType().GetProperty("userId");
            // Act & Assert
            Assert.IsNotNull(propertyInfo, "userId property not found.");
            Assert.AreEqual(typeof(string), propertyInfo.PropertyType, "userId property type is not string.");
        }
[Test]
        public void Delivery_Properties_DeliveryStatus_ReturnExpectedDataTypes()
        {
            // Arrange
            Delivery delivery = new Delivery();
            PropertyInfo propertyInfo = delivery.GetType().GetProperty("DeliveryStatus");
            // Act & Assert
            Assert.IsNotNull(propertyInfo, "DeliveryStatus property not found.");
            Assert.AreEqual(typeof(int), propertyInfo.PropertyType, "DeliveryStatus property type is not string.");
        }

        [Test]
        public async Task GetAllDeliverys_ReturnsOkResult()
        {
            // Act
            var result = await _DeliveryController.GetAllDeliverys();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task GetAllDeliverys_ReturnsAllDeliverys()
        {
            // Act
            var result = await _DeliveryController.GetAllDeliverys();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf<IEnumerable<Delivery>>(okResult.Value);
            var Deliverys = okResult.Value as IEnumerable<Delivery>;

            var DeliveryCount = Deliverys.Count();
            Assert.AreEqual(3, DeliveryCount); // Assuming you have 3 Deliverys in the seeded data
        }


        [Test]
        public async Task AddDelivery_ValidData_ReturnsOkResult()
        {
            // Arrange
            var newDelivery = new Delivery
            {
userId="101",EstablishmentDate=DateTime.Parse("2023-04-30"),DeliveryStatus=0,OrderId=100 };

            // Act
            var result = await _DeliveryController.AddDelivery(newDelivery);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }
        [Test]
        public async Task DeleteDelivery_ValidId_ReturnsNoContent()
        {
            // Arrange
              // var controller = new DeliverysController(context);

                // Act
                var result = await _DeliveryController.DeleteDelivery(1) as NoContentResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(204, result.StatusCode);
        }

        [Test]
        public async Task DeleteDelivery_InvalidId_ReturnsBadRequest()
        {
                   // Act
                var result = await _DeliveryController.DeleteDelivery(0) as BadRequestObjectResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(400, result.StatusCode);
                Assert.AreEqual("Not a valid Delivery id", result.Value);
        }
    }
}

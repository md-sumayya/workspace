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
    public class OrderControllerTests
    {
        private OrderController _OrderController;
        private OrderDeliveryDbContext _context;

        [SetUp]
        public void Setup()
        {
            // Initialize an in-memory database for tCustomerNameesting
            var options = new DbContextOptionsBuilder<OrderDeliveryDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new OrderDeliveryDbContext(options);
            _context.Database.EnsureCreated(); // Create the database

            // Seed the database with sample data
            _context.Orders.AddRange(new List<Order>
            {
                new Order { OrderID = 1, OrderType = "Order 1", CustomerName = "Order CustomerName1", ContactNumber = "9876543210",Location="Location 1", Amount=100 },
                new Order { OrderID = 2, OrderType = "Order 2", CustomerName = "Order CustomerName2", ContactNumber = "9876543120",Location="Location 2", Amount=200 },
                new Order { OrderID = 3, OrderType = "Order 3", CustomerName = "Order CustomerName3", ContactNumber = "9898989765",Location="Location 3", Amount=300 }
            });
            _context.SaveChanges();

            _OrderController = new OrderController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted(); // Delete the in-memory database after each test
            _context.Dispose();
        }
        [Test]
        public void OrderClassExists()
        {
            // Arrange
            Type OrderType = typeof(Order);

            // Act & Assert
            Assert.IsNotNull(OrderType, "Order class not found.");
        }
         [Test]
        public void LoginModelClassExists()
        {
            // Arrange
            Type LoginModelType = typeof(LoginModel);

            // Act & Assert
            Assert.IsNotNull(LoginModelType, "LoginModel class not found.");
        }
         [Test]
        public void RegisterModelClassExists()
        {
            // Arrange
            Type RegisterModelType = typeof(RegisterModel);

            // Act & Assert
            Assert.IsNotNull(RegisterModelType, "RegisterModel class not found.");
        }
        [Test]
public void AccountController_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetwebapi"); // Replace with the actual assembly name

    // Get the namespace and controller name
    string controllerName = "Order";
    string controllerNamespace = "dotnetapiapp.Controllers"; // Replace with your controller's namespace

    // Construct the full controller type name
    string controllerTypeName = controllerNamespace + "." + controllerName + "Controller";

    // Act
    Type controllerType = assembly.GetType(controllerTypeName);

    // Assert
    Assert.IsNotNull(controllerType, "Controller not found: " + controllerTypeName);
}
 [Test]
public void DeliveryController_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetwebapi"); // Replace with the actual assembly name

    // Get the namespace and controller name
    string controllerName = "Delivery";
    string controllerNamespace = "dotnetapiapp.Controllers"; // Replace with your controller's namespace

    // Construct the full controller type name
    string controllerTypeName = controllerNamespace + "." + controllerName + "Controller";

    // Act
    Type controllerType = assembly.GetType(controllerTypeName);

    // Assert
    Assert.IsNotNull(controllerType, "Controller not found: " + controllerTypeName);
}
[Test]
public void AuthController_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetwebapi"); // Replace with the actual assembly name

    // Get the namespace and controller name
    string controllerName = "Auth";
    string controllerNamespace = "dotnetapiapp.Controllers"; // Replace with your controller's namespace

    // Construct the full controller type name
    string controllerTypeName = controllerNamespace + "." + controllerName + "Controller";

    // Act
    Type controllerType = assembly.GetType(controllerTypeName);

    // Assert
    Assert.IsNotNull(controllerType, "Controller not found: " + controllerTypeName);
}

        [Test]
        public void Order_Properties_OrderType_ReturnExpectedDataTypes()
        {
            // Arrange
            Order OrderItem = new Order();
            PropertyInfo propertyInfo = OrderItem.GetType().GetProperty("OrderType");
            // Act & Assert
            Assert.IsNotNull(propertyInfo, "OrderType property not found.");
            Assert.AreEqual(typeof(string), propertyInfo.PropertyType, "OrderType property type is not string.");
        }
[Test]
        public void Order_Properties_CustomerName_ReturnExpectedDataTypes()
        {
            // Arrange
            Order OrderItem = new Order();
            PropertyInfo propertyInfo = OrderItem.GetType().GetProperty("CustomerName");
            // Act & Assert
            Assert.IsNotNull(propertyInfo, "CustomerName property not found.");
            Assert.AreEqual(typeof(string), propertyInfo.PropertyType, "CustomerName property type is not string.");
        }

        [Test]
        public async Task GetAllOrders_ReturnsOkResult()
        {
            // Act
            var result = await _OrderController.GetAllOrders();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task GetAllOrders_ReturnsAllOrders()
        {
            // Act
            var result = await _OrderController.GetAllOrders();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;

            Assert.IsInstanceOf<IEnumerable<Order>>(okResult.Value);
            var Orders = okResult.Value as IEnumerable<Order>;

            var OrderCount = Orders.Count();
            Assert.AreEqual(3, OrderCount); // Assuming you have 3 Orders in the seeded data
        }


        [Test]
        public async Task AddOrder_ValidData_ReturnsOkResult()
        {
            // Arrange
            var newOrder = new Order
            {
OrderType = "Order 3", CustomerName = "Order CustomerName3", ContactNumber = "9898989765",Location="Location 3", Amount=300
            };

            // Act
            var result = await _OrderController.AddOrder(newOrder);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }
        [Test]
        public async Task DeleteOrder_ValidId_ReturnsNoContent()
        {
            // Arrange
              // var controller = new OrdersController(context);

                // Act
                var result = await _OrderController.DeleteOrder(1) as NoContentResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(204, result.StatusCode);
        }

        [Test]
        public async Task DeleteOrder_InvalidId_ReturnsBadRequest()
        {
                   // Act
                var result = await _OrderController.DeleteOrder(0) as BadRequestObjectResult;

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(400, result.StatusCode);
                Assert.AreEqual("Not a valid Order id", result.Value);
        }
    }
}

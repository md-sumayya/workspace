using System;
using System.Reflection;
using System.Threading.Tasks;
using dotnetmvcapp.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using dotnetmvcapp.Models;
using dotnetmvcapp.Services;
namespace dotnetmvcapp.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new HomeController();
        }

       [Test]
        public void Delivery_Class_Available()
        {
            // Arrange
            Type DeliveryType = typeof(Delivery);

            // Act & Assert
            Assert.IsNotNull(DeliveryType, "Delivery class not found.");
        }
        [Test]
        public void Order_Class_Available()
        {
            // Arrange
            Type OrderType = typeof(Order);

            // Act & Assert
            Assert.IsNotNull(OrderType, "Order class not found.");
        }
        [Test]
public void AccountController_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetmvc"); // Replace with the actual assembly name

    // Get the namespace and controller name
    string controllerName = "Account";
    string controllerNamespace = "dotnetmvcapp.Controllers"; // Replace with your controller's namespace

    // Construct the full controller type name
    string controllerTypeName = controllerNamespace + "." + controllerName + "Controller";

    // Act
    Type controllerType = assembly.GetType(controllerTypeName);

    // Assert
    Assert.IsNotNull(controllerType, "Controller not found: " + controllerTypeName);
}
[Test]
        public void HomeIndex_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("Index", new Type[0]) != null,
                Is.True, "Index action does not exist."
            );
        }

[Test]
        public void HomeError_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("Error", new Type[0]) != null,
                Is.True, "Error action does not exist."
            );
        }
[Test]
public void HomeController_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetmvc"); // Replace with the actual assembly name

    // Get the namespace and controller name
    string controllerName = "Home";
    string controllerNamespace = "dotnetmvcapp.Controllers"; // Replace with your controller's namespace

    // Construct the full controller type name
    string controllerTypeName = controllerNamespace + "." + controllerName + "Controller";

    // Act
    Type controllerType = assembly.GetType(controllerTypeName);

    // Assert
    Assert.IsNotNull(controllerType, "Controller not found: " + controllerTypeName);
}

[Test]
public void OrderService_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetmvc");
    string className = "dotnetmvcapp.Services.OrderService";
    Type type = assembly.GetType(className);
    Assert.That(type, Is.Not.Null, "OrderService class does not exist in the assembly.");

}

[Test]
public void DeliveryService_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetmvc");
    string className = "dotnetmvcapp.Services.DeliveryService";
    Type type = assembly.GetType(className);
    Assert.That(type, Is.Not.Null, "DeliveryService class does not exist in the assembly.");

}
[TestFixture]
    public class OrderServiceTests
    {
        private Type _OrderServiceType;

        [SetUp]
        public void Setup()
        {
            _OrderServiceType = typeof(OrderService);
        }

        [Test]
        public void AddOrder_MethodExists()
        {
            Assert.That(_OrderServiceType.GetMethod("AddOrder", new[] { typeof(Order) }), Is.Not.Null, "AddOrder method does not exist.");
        }

        [Test]
        public void GetOrderTypes_MethodExists()
        {
            Assert.That(_OrderServiceType.GetMethod("GetOrderTypes"), Is.Not.Null, "GetOrderTypes method does not exist.");
        }

        [Test]
        public void GetAllOrders_MethodExists()
        {
            Assert.That(_OrderServiceType.GetMethod("GetAllOrders"), Is.Not.Null, "GetAllOrders method does not exist.");
        }

        [Test]
        public void DeleteOrder_MethodExists()
        {
            Assert.That(_OrderServiceType.GetMethod("DeleteOrder", new[] { typeof(int) }), Is.Not.Null, "DeleteOrder method does not exist.");
        }
    }
    [TestFixture]
    public class DeliveryServiceTests
    {
        private Type _DeliveryServiceType;

        [SetUp]
        public void Setup()
        {
            _DeliveryServiceType = typeof(DeliveryService);
        }

        [Test]
        public void AddDelivery_MethodExists()
        {
            Assert.That(_DeliveryServiceType.GetMethod("AddDelivery", new[] { typeof(Delivery) }), Is.Not.Null, "AddDelivery method does not exist.");
        }

        // [Test]
        // public void GetDeliveryByUserId_MethodExists()
        // {
        //     Assert.That(_DeliveryServiceType.GetMethod("GetDeliveryByUserId", new[] { typeof(string) }), Is.Not.Null, "GetDeliveryByUserId method does not exist.");
        // }

        [Test]
        public void GetAllDeliverys_MethodExists()
        {
            Assert.That(_DeliveryServiceType.GetMethod("GetAllDeliverys"), Is.Not.Null, "GetAllDeliverys method does not exist.");
        }

        [Test]
        public void DeleteDelivery_MethodExists()
        {
            Assert.That(_DeliveryServiceType.GetMethod("DeleteDelivery", new[] { typeof(int) }), Is.Not.Null, "DeleteDelivery method does not exist.");
        }
    }
    }
}

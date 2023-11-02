using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetmvcapp.Controllers;
using dotnetmvcapp.Models;
using dotnetmvcapp.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace dotnetmvcapp.Tests
{
    [TestFixture]
    public class OrderControllerTests
    {
        private OrderController _controller;
        private Mock<IOrderService> _mockOrderService;

        [SetUp]
        public void Setup()
        {
            _mockOrderService = new Mock<IOrderService>();
            _controller = new OrderController(_mockOrderService.Object);
        }
        [Test]
        public void AddOrder_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("AddOrder", new Type[0]) != null,
                Is.True, "AddOrder action does not exist."
            );
        }
        [Test]
        public void OrderIndex_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("Index", new Type[0]) != null,
                Is.True, "Index action does not exist."
            );
        }

    [Test]
public void OrderDelete_ActionExists()
{
    // Assert
    Assert.That(
        _controller.GetType().GetMethod("Delete", new[] { typeof(int) }) != null,
        Is.True, "Delete action does not exist."
    );
}
  [Test]
        public void AddOrder_ValidOrder_RedirectsToIndex()
        {
            // Arrange
            var mockOrderService = new Mock<IOrderService>();
            mockOrderService.Setup(OrderItem => OrderItem.AddOrder(It.IsAny<Order>())).Returns(true);
            var controller = new OrderController(mockOrderService.Object);

            // Act
            var result = controller.AddOrder(new Order());

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = (RedirectToActionResult)result;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));
        }


       [Test]
public void AddOrder_InvalidOrder_ReturnsBadRequest()
{
    // Arrange
    var controller = new OrderController(Mock.Of<IOrderService>());

    // Act
    var result = controller.AddOrder(null);

    // Assert
    Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
}



        [Test]
        public async Task Delete_ValidId_RedirectsToIndex()
        {
            // Arrange
            int OrderId = 1;
            _mockOrderService.Setup(OrderItem => OrderItem.DeleteOrder(OrderId))
                .Returns(true);

            // Act
            var result = _controller.Delete(OrderId);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = (RedirectToActionResult)result;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Delete_OrderFails_ReturnsErrorView()
        {
            // Arrange
            int OrderId = 1;
            _mockOrderService.Setup(OrderItem => OrderItem.DeleteOrder(OrderId))
                .Returns(false);

            // Act
            var result = _controller.Delete(OrderId);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.ViewName, Is.EqualTo("Error"));
        }

        [Test]
        public void Delete_ExceptionThrown_ReturnsErrorView()
        {
            // Arrange
            int OrderId = 1;
            _mockOrderService.Setup(OrderItem => OrderItem.DeleteOrder(OrderId))
                .Throws<Exception>();

            // Act
            var result = _controller.Delete(OrderId);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.ViewName, Is.EqualTo("Error"));
        }
    }
}

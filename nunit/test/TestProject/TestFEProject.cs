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
    public class DeliveryControllerTests
    {
        private DeliveryController _controller;
        private Mock<IDeliveryService> _mockDeliveryService;

        [SetUp]
        public void Setup()
        {
            _mockDeliveryService = new Mock<IDeliveryService>();
            _controller = new DeliveryController(_mockDeliveryService.Object);
        }

        [Test]
        public void AddDelivery_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("AddDelivery", new Type[0]) != null,
                Is.True, "AddDelivery action does not exist."
            );
        }

        [Test]
        public void DeliveryIndex_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("Index", new Type[0]) != null,
                Is.True, "Index action does not exist."
            );
        }

        // [Test]
        // public void UserDelivery_ActionExists()
        // {
        //     // Assert
        //     Assert.That(
        //         _controller.GetType().GetMethod("UserDelivery", new Type[0]) != null,
        //         Is.True, "UserDelivery action does not exist."
        //     );
        // }

        [Test]
        public void DeliveryDelete_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("Delete", new[] { typeof(int) }) != null,
                Is.True, "Delete action does not exist."
            );
        }


        [Test]
        public async Task Delete_ValidId_RedirectsToIndex()
        {
            // Arrange
            int DeliveryId = 1;
            _mockDeliveryService.Setup(service => service.DeleteDelivery(DeliveryId))
                .Returns(true);

            // Act
            var result = _controller.Delete(DeliveryId);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = (RedirectToActionResult)result;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Delete_ServiceFails_ReturnsErrorView()
        {
            // Arrange
            int DeliveryId = 1;
            _mockDeliveryService.Setup(service => service.DeleteDelivery(DeliveryId))
                .Returns(false);

            // Act
            var result = _controller.Delete(DeliveryId);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.ViewName, Is.EqualTo("Error"));
        }

        [Test]
        public void Delete_ExceptionThrown_ReturnsErrorView()
        {
            // Arrange
            int DeliveryId = 1;
            _mockDeliveryService.Setup(service => service.DeleteDelivery(DeliveryId))
                .Throws<Exception>();

            // Act
            var result = _controller.Delete(DeliveryId);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.ViewName, Is.EqualTo("Error"));
        }
    }
}

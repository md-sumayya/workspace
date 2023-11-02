using NUnit.Framework;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Reflection;
using dotnetmvcapp.Controllers;

namespace dotnetmvcapp.Tests
{
    [TestFixture]
    public class OrderProjectTests
    {
        [Test]
        public void AuthorizeHomeControllerOrNot()
        {
            // Arrange
            Type controllerType = typeof(HomeController);
            var authorizeAttributeType = typeof(AuthorizeAttribute);

            // Act
            var authorizeAttributes = controllerType.GetCustomAttributes(authorizeAttributeType, inherit: true);

            // Assert
            Assert.IsTrue(authorizeAttributes.Any(), "[Authorize] attribute is not applied to the controller.");
        }
        [Test]
        public void AuthorizeOrderControllerOrNot()
        {
            // Arrange
            Type controllerType = typeof(OrderController);
            var authorizeAttributeType = typeof(AuthorizeAttribute);

            // Act
            var authorizeAttributes = controllerType.GetCustomAttributes(authorizeAttributeType, inherit: true);

            // Assert
            Assert.IsTrue(authorizeAttributes.Any(), "[Authorize] attribute is not applied to the controller.");
        }
        [Test]
        public void AuthorizeDeliveryControllerOrNot()
        {
            // Arrange
            Type controllerType = typeof(DeliveryController);
            var authorizeAttributeType = typeof(AuthorizeAttribute);

            // Act
            var authorizeAttributes = controllerType.GetCustomAttributes(authorizeAttributeType, inherit: true);

            // Assert
            Assert.IsTrue(authorizeAttributes.Any(), "[Authorize] attribute is not applied to the controller.");
        }
    }
}

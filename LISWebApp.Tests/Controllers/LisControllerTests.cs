using LISWebApp.Controllers;
using LISWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;

namespace LISWebApp.Tests.Controllers
{
    public class LisControllerTests
    {
        private LisService _service;
        private LisController _controller;

        public LisControllerTests()
        {
            _service = new LisService();
            _controller = new LisController(_service);
        }

        [Fact]
        public void LisControllerConstructor_ThrowsArgumentException_WhenServiceIsNull()
        {
            // Act 
            var ex = Assert.Throws<ArgumentException>(() => new LisController(lisService: null!));

            // Assert
            Assert.Contains("lisService", ex.Message);
        }

        [Fact]
        public void LisControllerConstructor_DoesNotThrow_WhenServiceIsProvided()
        {
            // Arrange
            var mockService = new Mock<ILisService>();

            // Act
            var controller = new LisController(mockService.Object);

            // Assert
            Assert.NotNull(controller);
        }

        [Fact]
        public void Index_Returns_ViewResult()
        {
            // Act
            var result = _controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Compute_EmptyInput_Returns_EmptyResult()
        {
            // Act
            var result = _controller.Compute("") as JsonResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Compute_ValidInput_Returns_LIS_Result()
        {
            // Arrange
            var input = "6 1 5 9 2";
            var expected = "1 5 9"; 

            // Act
            var result = _controller.Compute(input) as JsonResult;

            // Assert
            Assert.NotNull(result);
            var actual = result!.Value!.GetType().GetProperty("result")!.GetValue(result!.Value);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Compute_Exception_Returns_BadRequest()
        {
            // Arrange
            var mockService = new Mock<ILisService>();
            mockService.Setup(x => x.GetLis(It.IsAny<List<int>>())).Throws(new Exception("Test error"));

            var controller = new LisController(mockService.Object);

            // Act
            var result = controller.Compute("1 2 3");

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}

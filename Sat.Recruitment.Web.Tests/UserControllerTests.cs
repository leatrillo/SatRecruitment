using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Business.Contract;
using Sat.Recruitment.Common.DTO;
using Sat.Recruitment.Common.Entities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Web.Tests
{
    public class UserControllerTests
    {
        private readonly Mock<IUserBusiness> _mockUserBusiness;
        private readonly Mock<ILogger<UserController>> _mockLogger;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _mockUserBusiness = new Mock<IUserBusiness>();
            _mockLogger = new Mock<ILogger<UserController>>();
            _controller = new UserController(_mockUserBusiness.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task CreateUser_ReturnsOkResult()
        {
            // Arrange
            var user = new User();
            var userOutput = new UserOutput();
            _mockUserBusiness.Setup(b => b.CreateUser(user)).ReturnsAsync(userOutput);

            // Act
            var result = await _controller.CreateUser(user);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(userOutput, okResult.Value);
        }

        [Fact]
        public async Task CreateUser_CallsUserBusiness()
        {
            // Arrange
            var user = new User();
            var userOutput = new UserOutput();
            _mockUserBusiness.Setup(b => b.CreateUser(user)).ReturnsAsync(userOutput);

            // Act
            var result = await _controller.CreateUser(user);

            // Assert
            _mockUserBusiness.Verify(b => b.CreateUser(user), Times.Once);
        }

        [Fact]
        public async Task CreateUser_ThrowsException_ReturnsInternalServerError()
        {
            // Arrange
            var user = new User();
            _mockUserBusiness.Setup(b => b.CreateUser(user)).ThrowsAsync(new Exception());

            // Act
            Func<Task> action = async () => await _controller.CreateUser(user);

            // Assert
            await Assert.ThrowsAsync<Exception>(action);
        }

        [Fact]
        public async Task GetUser_ReturnsOkResult()
        {
            // Arrange
            var userId = 1;
            var user = new User();
            _mockUserBusiness.Setup(b => b.GetUser(userId)).ReturnsAsync(user);

            // Act
            var result = await _controller.GetUser(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(user, okResult.Value);
        }

        [Fact]
        public async Task GetUser_CallsUserBusiness()
        {
            // Arrange
            var userId = 1;
            var user = new User();
            _mockUserBusiness.Setup(b => b.GetUser(userId)).ReturnsAsync(user);

            // Act
            var result = await _controller.GetUser(userId);

            // Assert
            _mockUserBusiness.Verify(b => b.GetUser(userId), Times.Once);
        }

        [Fact]
        public async Task GetUser_ThrowsException_ReturnsInternalServerError()
        {
            // Arrange
            var userId = 1;
            _mockUserBusiness.Setup(b => b.GetUser(userId)).ThrowsAsync(new Exception());

            // Act
            Func<Task> action = async () => await _controller.GetUser(userId);

            // Assert
            await Assert.ThrowsAsync<Exception>(action);
        }
    }
}

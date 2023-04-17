using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Business.Implementation;
using Sat.Recruitment.Common.Entities;
using Sat.Recruitment.Common.Enums;
using Sat.Recruitment.Data.EF.Contract;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.BusinessTests
{
    public class UserBusinessTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<ILogger<UserBusiness>> _loggerMock;
        private readonly UserBusiness _userBusiness;

        public UserBusinessTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _loggerMock = new Mock<ILogger<UserBusiness>>();
            _userBusiness = new UserBusiness(_loggerMock.Object, _userRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateUser_ValidUser_ReturnsUserOutputWithUserId()
        {
            // Arrange
            var user = new User
            {
                Name = "Leandro",
                Email = "leaaa@gmail.com",
                Address = "av. siempre viva",
                Phone = "11-2222-3333",
                UserTypeId = (int)UserTypes.Normal,
                Money = 200
            };
            _userRepositoryMock.Setup(x => x.GetByEmail(user.Email)).ReturnsAsync((User)null);
            _userRepositoryMock.Setup(x => x.SaveUserAsync(user)).ReturnsAsync(1);

            // Act
            var result = await _userBusiness.CreateUser(user);

            // Assert
            Assert.Equal(1, result.UserId);
            Assert.Equal("User Created", result.Status);
        }

        [Fact]
        public async Task CreateUser_EmailAlreadyExists_ThrowsArgumentException()
        {
            // Arrange
            var user = new User
            {
                Name = "Leandro",
                Email = "leaaa@gmail.com",
                Address = "av. siempre viva",
                Phone = "11-2222-3333",
                UserTypeId = (int)UserTypes.Normal,
                Money = 200
            };
            _userRepositoryMock.Setup(x => x.GetByEmail(user.Email)).ReturnsAsync(user);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _userBusiness.CreateUser(user));
        }

        [Theory]
        [InlineData("invalidemail")]
        [InlineData("no_at_symbol.com")]
        [InlineData("missing_tld@domain.")]
        public async Task CreateUser_InvalidEmailFormat_ThrowsArgumentException(string email)
        {
            // Arrange
            var user = new User
            {
                Name = "Leandro",
                Email = email,
                Address = "av. siempre viva",
                Phone = "11-2222-3333",
                UserTypeId = (int)UserTypes.Normal,
                Money = 200
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _userBusiness.CreateUser(user));
        }

        [Fact]
        public async Task CreateUser_UserTypeIsIncorrect_ThrowsArgumentException()
        {
            // Arrange
            var user = new User
            {
                Name = "Leandro",
                Email = "leaaa@gmail.com",
                Address = "av. siempre viva",
                Phone = "11-2222-3333",
                UserTypeId = 4, // Invalid user type
                Money = 200
            };
            _userRepositoryMock.Setup(x => x.GetByEmail(user.Email)).ReturnsAsync((User)null);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _userBusiness.CreateUser(user));
        }

    }
}

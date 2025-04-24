using CashFlow.Transaction.API.Controllers;
using CashFlow.Transaction.Application.DTOs;
using CashFlow.Transaction.Application.Interfaces;
using CashFlow.Transaction.Application.Services;
using CashFlow.Transaction.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CashFlow.Transaction.Test.Controllers
{
    public class UserControllerTest
    {
        private readonly IUserService _userService;
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly Mock<IPasswordHasher> _mockPasswordHasher;
        private readonly Mock<IAuthService> _mockAuthService;
        private readonly UserController _userController;

        public UserControllerTest()
        {
            _mockRepository = new Mock<IUserRepository>();
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _mockAuthService = new Mock<IAuthService>();
            _userService = new UserService(_mockRepository.Object, _mockPasswordHasher.Object, _mockAuthService.Object);
            _userController = new UserController(_userService);
        }
        [Fact]
        public async Task RegisterWithSuccessTest()
        {
            CreateUserDto createUser = new CreateUserDto
            {
                Username = "testuser",
                Password = "password123"
            };
            var result = await _userController.Register(createUser);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task RegisterWithInvalidPayloadTest()
        {
            CreateUserDto createUser = new CreateUserDto
            {
                Username = "",
                Password = ""
            };
            var result = await _userController.Register(createUser);
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task LoginWithSuccessTest()
        {
            _mockPasswordHasher.Setup(repo => repo.HashPassword(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns("hashedpassword");

            _mockRepository.Setup(repo => repo.GetUserByUsername(It.IsAny<string>()))
                .ReturnsAsync(new User("testuser", "hashedpassword", "salt"));

            LoginUserDto loginUser = new LoginUserDto
            {
                Username = "testuser",
                Password = "hashedpassword"
            };
            var result = await _userController.Login(loginUser);
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<TokenUserDto>(((OkObjectResult)result).Value);
        }
        [Fact]
        public async Task LoginWithInvalidPayloadTest()
        {
            LoginUserDto loginUser = new LoginUserDto
            {
                Username = "",
                Password = ""
            };
            var result = await _userController.Login(loginUser);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}

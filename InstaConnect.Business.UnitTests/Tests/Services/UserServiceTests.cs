using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Services;
using InstaConnect.Business.UnitTests.Utilities;
using InstaConnect.Business.UnitTests.Utilities.Services;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

namespace InstaConnect.Business.UnitTests.Tests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IMapper> _mockMapper;
        private IResultFactory _resultFactory;
        private Mock<IUserRepository> _mockUserRepository;
        private IUserService _userService;

        public UserServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(
                _mockMapper.Object,
                _resultFactory,
                _mockUserRepository.Object);
        }

        [SetUp]
        public void Setup()
        {
            _mockUserRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<User, bool>>>()))
               .ReturnsAsync((Expression<Func<User, bool>> expression) => TestUserServiceUtilities.TestUsers.Find(new Predicate<User>(expression.Compile())));
        }

        [Test]
        [TestCase(TestUserServiceUtilities.TestNonExistingUserId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestUserServiceUtilities.TestExistingUserId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _userService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestUserServiceUtilities.TestNonExistingUserUsername, InstaConnectStatusCode.NotFound)]
        [TestCase(TestUserServiceUtilities.TestExistingUserUsername, InstaConnectStatusCode.OK)]
        public async Task GetByUsernameAsync_HasUsername_ReturnsExpectedResult(string username, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _userService.GetByUsernameAsync(username);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestUserServiceUtilities.TestNonExistingUserId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestUserServiceUtilities.TestExistingUserId, InstaConnectStatusCode.OK)]
        public async Task GetPersonalByIdAsync_HasId_ReturnsExpectedResult(string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _userService.GetPersonalByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

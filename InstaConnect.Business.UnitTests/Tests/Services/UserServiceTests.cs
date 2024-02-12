using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Services;
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
        private const string ExistingUserId = "ExistingUserId";
        private const string NonExistingUserId = "NonExistingUserId";

        private const string ExistingUserName = "ExistingUserName";
        private const string NonExistingUserName = "NonExistingUserName";

        private readonly Mock<IMapper> _mockMapper;
        private readonly IResultFactory _resultFactory;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly IUserService _userService;

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
            var existingUser = new User()
            {
                Id = ExistingUserId,
                UserName = ExistingUserName
            };

            var existingUsers = new List<User>()
            {
                existingUser
            };

            _mockUserRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<User, bool>>>()))
               .ReturnsAsync((Expression<Func<User, bool>> expression) => existingUsers.Find(new Predicate<User>(expression.Compile())));
        }

        [Test]
        [TestCase(NonExistingUserId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingUserId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _userService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserName, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingUserName, InstaConnectStatusCode.OK)]
        public async Task GetByUsernameAsync_HasUsername_ReturnsExpectedResult(
            string username,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _userService.GetByUsernameAsync(username);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingUserId, InstaConnectStatusCode.OK)]
        public async Task GetPersonalByIdAsync_HasId_ReturnsExpectedResult(
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _userService.GetPersonalByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Services;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

namespace InstaConnect.Business.UnitTests.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        public const string TestExistingUserId = "ExistingUserId";
        public const string TestNonExistingUserId = "NonExistingUserId";
        public const string TestExistingUserUsername = "ExistingUserUsername";
        public const string TestNonExistingUserUsername = "NonExistingUserUsername";

        private IMapper _mapper;
        private IResultFactory _resultFactory;
        private Mock<IUserRepository> _mockUserRepository;
        private IUserService _userService;

        [SetUp]
        public void Setup()
        {
            var testUsers = new List<User>()
            {
                new User()
                {
                    Id = TestExistingUserId,
                    UserName = TestExistingUserUsername
                }
            };

            var testExistingUser = new User();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InstaConnectProfile());
            });
            _mapper = config.CreateMapper();
            _resultFactory = new ResultFactory();
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(
                _mapper,
                _resultFactory,
                _mockUserRepository.Object);

            _mockUserRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<User, bool>>>()))
               .ReturnsAsync((Expression<Func<User, bool>> expression) => testUsers.Find(new Predicate<User>(expression.Compile())));
        }

        [Test]
        [TestCase(TestNonExistingUserId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingUserId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _userService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingUserUsername, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingUserUsername, InstaConnectStatusCode.OK)]
        public async Task GetByUsernameAsync_HasUsername_ReturnsExpectedResult(string username, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _userService.GetByUsernameAsync(username);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingUserId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingUserId, InstaConnectStatusCode.OK)]
        public async Task GetPersonalByIdAsync_HasId_ReturnsExpectedResult(string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _userService.GetPersonalByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

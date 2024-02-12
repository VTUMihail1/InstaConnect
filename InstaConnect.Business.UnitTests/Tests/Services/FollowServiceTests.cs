using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Follow;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Services;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

namespace InstaConnect.Business.UnitTests.Tests.Services
{
    [TestFixture]
    public class FollowServiceTests
    {
        private const string ExistingFollowId = "ExistingFollowId";
        private const string NonExistingFollowId = "NonExistingFollowId";
    
        private const string ExistingFollowerId = "ExistingFollowerId";
        private const string NonExistingFollowerId = "NonExistingFollowerId";
        private const string ExistingFollowFollowerId = "ExistingFollowFollowerId";
      
        private const string ExistingFollowingId = "ExistingFollowingId";
        private const string NonExistingFollowingId = "NonExistingFolloweingId";
        private const string ExistingFollowFollowingId = "ExistingFollowFollowingId";

        private readonly Mock<IMapper> _mockMapper;
        private readonly IResultFactory _resultFactory;
        private readonly Mock<IFollowRepository> _mockFollowRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IAccountManager> _mockAccountManager;
        private readonly IFollowService _followService;

        public FollowServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockFollowRepository = new Mock<IFollowRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockAccountManager = new Mock<IAccountManager>();
            _followService = new FollowService(
                _mockMapper.Object,
                _resultFactory,
                _mockFollowRepository.Object,
                _mockUserRepository.Object,
                _mockAccountManager.Object);
        }

        [SetUp]
        public void Setup()
        {
            var existingFollow = new Follow()
            {
                Id = ExistingFollowId,
                FollowerId = ExistingFollowFollowerId,
                FollowingId = ExistingFollowFollowingId
            };

            var existingFollows = new List<Follow>()
            {
                existingFollow
            };

            var existingFollower = new User()
            {
                Id = ExistingFollowerId
            };

            var existingFollowFollower = new User()
            {
                Id = ExistingFollowFollowerId
            };

            var existingFollowing = new User()
            {
                Id = ExistingFollowingId
            };

            var existingFollowFollowing = new User()
            {
                Id = ExistingFollowFollowingId
            };

            var existingUsers = new List<User>()
            {
                existingFollower,
                existingFollowFollower,
                existingFollowing,
                existingFollowFollowing
            };

            _mockUserRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync((Expression<Func<User, bool>> expression) => existingUsers.Find(new Predicate<User>(expression.Compile())));

            _mockFollowRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Follow, bool>>>()))
                .ReturnsAsync((Expression<Func<Follow, bool>> expression) => existingFollows.Find(new Predicate<Follow>(expression.Compile())));

            _mockAccountManager.Setup(m => m.ValidateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns<string, string>((currentUserId, userId) => currentUserId == userId);
        }

        [Test]
        [TestCase(NonExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingFollowId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _followService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingFollowerId, NonExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingFollowFollowerId, NonExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingFollowerId, ExistingFollowFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingFollowFollowerId, ExistingFollowFollowingId, InstaConnectStatusCode.OK)]
        public async Task GetByFollowerIdAndFollowingIdAsync_HasArguments_ReturnsExpectedResult(
            string followerId,
            string followingId,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _followService.GetByFollowerIdAndFollowingIdAsync(followerId, followingId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingFollowerId, NonExistingFollowerId, NonExistingFollowingId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingFollowerId, NonExistingFollowerId, ExistingFollowingId, InstaConnectStatusCode.Forbidden)]
        [TestCase(ExistingFollowerId, ExistingFollowerId, NonExistingFollowingId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingFollowerId, ExistingFollowerId, ExistingFollowingId, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingFollowerId, ExistingFollowerId, ExistingFollowFollowingId, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingFollowFollowerId, ExistingFollowFollowerId, ExistingFollowingId, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingFollowFollowerId, ExistingFollowFollowerId, ExistingFollowFollowingId, InstaConnectStatusCode.BadRequest)]
        public async Task AddAsync_HasArguments_ReturnsExpectedResult(
            string currentFollowerId,
            string followerId,
            string followingId,
            InstaConnectStatusCode statusCode)
        {
            // Arrange
            var followAddDTO = new FollowAddDTO()
            {
                FollowerId = followerId,
                FollowingId = followingId
            };

            // Act
            var result = await _followService.AddAsync(currentFollowerId, followAddDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingFollowerId, NonExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingFollowFollowerId, NonExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingFollowerId, ExistingFollowFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingFollowFollowerId, ExistingFollowFollowingId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteByFollowerIdAndFollowingIdAsync_HasArguments_ReturnsExpectedResult(
            string followerId,
            string followingId,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _followService.DeleteByFollowerIdAndFollowingIdAsync(followerId, followingId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingFollowerId, NonExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingFollowFollowerId, NonExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingFollowerId, ExistingFollowId, InstaConnectStatusCode.Forbidden)]
        [TestCase(ExistingFollowFollowerId, ExistingFollowId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasId_ReturnsExpectedResult(
            string followerId,
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _followService.DeleteAsync(followerId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }

}

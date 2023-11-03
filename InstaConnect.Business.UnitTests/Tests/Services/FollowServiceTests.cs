using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Follow;
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


        private Mock<IMapper> _mockMapper;
        private IResultFactory _resultFactory;
        private Mock<IFollowRepository> _mockFollowRepository;
        private Mock<IUserRepository> _mockUserRepository;
        private IFollowService _followService;

        public FollowServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockFollowRepository = new Mock<IFollowRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _followService = new FollowService(
                _mockMapper.Object,
                _resultFactory,
                _mockFollowRepository.Object,
                _mockUserRepository.Object);
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
        [TestCase(NonExistingFollowerId, NonExistingFollowingId, InstaConnectStatusCode.BadRequest)]
        [TestCase(NonExistingFollowerId, ExistingFollowingId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingFollowerId, NonExistingFollowingId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingFollowerId, ExistingFollowingId, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingFollowerId, ExistingFollowFollowingId, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingFollowFollowerId, ExistingFollowingId, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingFollowFollowerId, ExistingFollowFollowingId, InstaConnectStatusCode.BadRequest)]
        public async Task AddAsync_HasArguments_ReturnsExpectedResult(
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
            var result = await _followService.AddAsync(followAddDTO);

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
        [TestCase(NonExistingFollowerId, ExistingFollowId, InstaConnectStatusCode.NotFound)]
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

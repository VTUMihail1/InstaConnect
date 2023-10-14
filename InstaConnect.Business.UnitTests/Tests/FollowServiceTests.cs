using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Follow;
using InstaConnect.Business.Models.DTOs.PostLike;
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
    public class FollowServiceTests
    {
        public const string TestExistingFollowId = "ExistingFollowId";
        public const string TestNonExistingFollowId = "NonExistingFollowId";
        public const string TestExistingFollowerId = "ExistingFollowerId";
        public const string TestNonExistingFollowerId = "NonExistingFollowerId";
        public const string TestExistingFollowingId = "ExistingFollowingId";
        public const string TestNonExistingFollowingId = "NonExistingFolloweingId";
        public const string TestExistingFollowFollowerId = "ExistingFollowFollowerId";
        public const string TestExistingFollowFollowingId = "ExistingFollowFollowingId";

        private IMapper _mapper;
        private IResultFactory _resultFactory;
        private Mock<IFollowRepository> _mockFollowRepository;
        private Mock<IInstaConnectUserManager> _mockInstaConnectUserManager;
        private IFollowService _followService;

        [SetUp]
        public void Setup()
        {

            var testFollows = new List<Follow>()
            {
                new Follow() {Id = TestExistingFollowId, FollowerId = TestExistingFollowFollowerId, FollowingId = TestExistingFollowFollowingId}
            };

            var testExistingUser = new User();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InstaConnectProfile());
            });

            _mapper = config.CreateMapper();
            _resultFactory = new ResultFactory();
            _mockFollowRepository = new Mock<IFollowRepository>();
            _mockInstaConnectUserManager = new Mock<IInstaConnectUserManager>();
            _followService = new FollowService(
                _mapper, 
                _resultFactory,
                _mockFollowRepository.Object,
                _mockInstaConnectUserManager.Object);

            _mockFollowRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Follow, bool>>>()))
               .ReturnsAsync((Expression<Func<Follow, bool>> expression) => testFollows.Find(new Predicate<Follow>(expression.Compile())));

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestExistingFollowerId))
                .ReturnsAsync(testExistingUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestExistingFollowingId))
                .ReturnsAsync(testExistingUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestExistingFollowFollowerId))
                .ReturnsAsync(testExistingUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestExistingFollowFollowingId))
                .ReturnsAsync(testExistingUser);
        }

        [Test]
        [TestCase(TestNonExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingFollowId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _followService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingFollowerId, TestNonExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingFollowerId, TestNonExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestNonExistingFollowerId, TestExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingFollowerId, TestExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingFollowFollowerId, TestExistingFollowFollowingId, InstaConnectStatusCode.OK)]
        public async Task GetByFollowerIdAndFollowingIdAsync_HasArguments_ReturnsExpectedResult(string followerId, string followingId, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _followService.GetByFollowerIdAndFollowingIdAsync(followerId, followingId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingFollowerId, TestNonExistingFollowingId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestNonExistingFollowerId, TestExistingFollowingId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestExistingFollowerId, TestNonExistingFollowingId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestExistingFollowerId, TestExistingFollowingId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestExistingFollowerId, TestExistingFollowFollowingId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestExistingFollowFollowerId, TestExistingFollowingId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestExistingFollowFollowerId, TestExistingFollowFollowingId, InstaConnectStatusCode.BadRequest)]
        public async Task AddAsync_HasArguments_ReturnsExpectedResult(string followerId, string followingId, InstaConnectStatusCode statusCode)
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
        [TestCase(TestNonExistingFollowerId, TestNonExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingFollowerId, TestNonExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestNonExistingFollowerId, TestExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingFollowerId, TestExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingFollowFollowerId, TestExistingFollowFollowingId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteByFollowerIdAndFollowingIdAsync_HasArguments_ReturnsExpectedResult(string followerId, string followingId, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _followService.DeleteByFollowerIdAndFollowingIdAsync(followerId, followingId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingFollowerId, TestNonExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingFollowerId, TestNonExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestNonExistingFollowerId, TestExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingFollowerId, TestExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingFollowFollowerId, TestExistingFollowId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasId_ReturnsExpectedResult(string followerId, string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _followService.DeleteAsync(followerId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

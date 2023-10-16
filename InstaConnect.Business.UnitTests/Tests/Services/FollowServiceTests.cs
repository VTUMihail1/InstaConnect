using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Follow;
using InstaConnect.Business.Models.DTOs.PostLike;
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
    public class FollowServiceTests
    {
        private Mock<IMapper> _mockMapper;
        private IResultFactory _resultFactory;
        private Mock<IFollowRepository> _mockFollowRepository;
        private Mock<IInstaConnectUserManager> _mockInstaConnectUserManager;
        private IFollowService _followService;

        public FollowServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockFollowRepository = new Mock<IFollowRepository>();
            _mockInstaConnectUserManager = new Mock<IInstaConnectUserManager>();
            _followService = new FollowService(
                _mockMapper.Object,
                _resultFactory,
                _mockFollowRepository.Object,
                _mockInstaConnectUserManager.Object);
        }

        [SetUp]
        public void Setup()
        {
            _mockFollowRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Follow, bool>>>()))
                .ReturnsAsync((Expression<Func<Follow, bool>> expression) => TestFollowServiceUtilities.TestFollows.Find(new Predicate<Follow>(expression.Compile())));

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestFollowServiceUtilities.TestExistingFollowerId))
                .ReturnsAsync(TestFollowServiceUtilities.TestExistingUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestFollowServiceUtilities.TestExistingFollowingId))
                .ReturnsAsync(TestFollowServiceUtilities.TestExistingUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestFollowServiceUtilities.TestExistingFollowFollowerId))
                .ReturnsAsync(TestFollowServiceUtilities.TestExistingUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestFollowServiceUtilities.TestExistingFollowFollowingId))
                .ReturnsAsync(TestFollowServiceUtilities.TestExistingUser);
        }

        [Test]
        [TestCase(TestFollowServiceUtilities.TestNonExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _followService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestFollowServiceUtilities.TestNonExistingFollowerId, TestFollowServiceUtilities.TestNonExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowerId, TestFollowServiceUtilities.TestNonExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestFollowServiceUtilities.TestNonExistingFollowerId, TestFollowServiceUtilities.TestExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowerId, TestFollowServiceUtilities.TestExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowFollowerId, TestFollowServiceUtilities.TestExistingFollowFollowingId, InstaConnectStatusCode.OK)]
        public async Task GetByFollowerIdAndFollowingIdAsync_HasArguments_ReturnsExpectedResult(string followerId, string followingId, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _followService.GetByFollowerIdAndFollowingIdAsync(followerId, followingId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestFollowServiceUtilities.TestNonExistingFollowerId, TestFollowServiceUtilities.TestNonExistingFollowingId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestFollowServiceUtilities.TestNonExistingFollowerId, TestFollowServiceUtilities.TestExistingFollowingId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowerId, TestFollowServiceUtilities.TestNonExistingFollowingId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowerId, TestFollowServiceUtilities.TestExistingFollowingId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowerId, TestFollowServiceUtilities.TestExistingFollowFollowingId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowFollowerId, TestFollowServiceUtilities.TestExistingFollowingId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowFollowerId, TestFollowServiceUtilities.TestExistingFollowFollowingId, InstaConnectStatusCode.BadRequest)]
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
        [TestCase(TestFollowServiceUtilities.TestNonExistingFollowerId, TestFollowServiceUtilities.TestNonExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowerId, TestFollowServiceUtilities.TestNonExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestFollowServiceUtilities.TestNonExistingFollowerId, TestFollowServiceUtilities.TestExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowerId, TestFollowServiceUtilities.TestExistingFollowingId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowFollowerId, TestFollowServiceUtilities.TestExistingFollowFollowingId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteByFollowerIdAndFollowingIdAsync_HasArguments_ReturnsExpectedResult(string followerId, string followingId, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _followService.DeleteByFollowerIdAndFollowingIdAsync(followerId, followingId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestFollowServiceUtilities.TestNonExistingFollowerId, TestFollowServiceUtilities.TestNonExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowerId, TestFollowServiceUtilities.TestNonExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestFollowServiceUtilities.TestNonExistingFollowerId, TestFollowServiceUtilities.TestExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowerId, TestFollowServiceUtilities.TestExistingFollowId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestFollowServiceUtilities.TestExistingFollowFollowerId, TestFollowServiceUtilities.TestExistingFollowId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasId_ReturnsExpectedResult(string followerId, string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _followService.DeleteAsync(followerId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }

}

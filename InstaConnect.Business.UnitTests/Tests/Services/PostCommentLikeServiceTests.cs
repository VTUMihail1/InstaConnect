using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.PostCommentLike;
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
    public class PostCommentLikeServiceTests
    {
        private Mock<IMapper> _mockMapper;
        private IResultFactory _resultFactory;
        private Mock<IPostCommentLikeRepository> _mockPostCommentLikeRepository;
        private Mock<IPostCommentRepository> _mockPostCommentRepository;
        private Mock<IInstaConnectUserManager> _mockInstaConnectUserManager;
        private IPostCommentLikeService _postCommentLikeService;

        public PostCommentLikeServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockPostCommentLikeRepository = new Mock<IPostCommentLikeRepository>();
            _mockPostCommentRepository = new Mock<IPostCommentRepository>();
            _mockInstaConnectUserManager = new Mock<IInstaConnectUserManager>();
            _postCommentLikeService = new PostCommentLikeService(
                _mockMapper.Object,
                _resultFactory,
                _mockPostCommentLikeRepository.Object,
                _mockPostCommentRepository.Object,
                _mockInstaConnectUserManager.Object);
        }

        [SetUp]
        public void Setup()
        {
            _mockPostCommentRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<PostComment, bool>>>()))
               .ReturnsAsync((Expression<Func<PostComment, bool>> expression) => TestPostCommentLikeServiceUtilities.TestPostComments.Find(new Predicate<PostComment>(expression.Compile())));

            _mockPostCommentLikeRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<PostCommentLike, bool>>>())).
                ReturnsAsync((Expression<Func<PostCommentLike, bool>> expression) => TestPostCommentLikeServiceUtilities.TestPostCommentLikes.Find(new Predicate<PostCommentLike>(expression.Compile())));

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestPostCommentLikeServiceUtilities.TestExistingUserId))
                .ReturnsAsync(TestPostCommentLikeServiceUtilities.TestExistingUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikeUserId))
                .ReturnsAsync(TestPostCommentLikeServiceUtilities.TestExistingUser);
        }

        [Test]
        [TestCase(TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikeId, InstaConnectStatusCode.OK)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestNonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        public async Task GetById_HasId_ReturnsExpectedResult(string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postCommentLikeService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestPostCommentLikeServiceUtilities.TestNonExistingUserId, TestPostCommentLikeServiceUtilities.TestNonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikeUserId, TestPostCommentLikeServiceUtilities.TestNonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestNonExistingUserId, TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikeUserId, TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.OK)]
        public async Task GetByUserIdAndPostCommentIdAsync_HasArguments_ReturnsExpectedResult(string userId, string postCommentId, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postCommentLikeService.GetByUserIdAndPostCommentIdAsync(userId, postCommentId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestPostCommentLikeServiceUtilities.TestNonExistingUserId, TestPostCommentLikeServiceUtilities.TestNonExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestNonExistingUserId, TestPostCommentLikeServiceUtilities.TestExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestExistingUserId, TestPostCommentLikeServiceUtilities.TestNonExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestExistingUserId, TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestExistingUserId, TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikeUserId, TestPostCommentLikeServiceUtilities.TestExistingPostCommentId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikeUserId, TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.BadRequest)]
        public async Task AddAsync_HasArguments_ReturnsExpectedResult(string userId, string postCommentId, InstaConnectStatusCode statusCode)
        {
            // Arrange
            var postCommentLikeAddDTO = new PostCommentLikeAddDTO()
            {
                UserId = userId,
                PostCommentId = postCommentId
            };

            // Act
            var result = await _postCommentLikeService.AddAsync(postCommentLikeAddDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestPostCommentLikeServiceUtilities.TestNonExistingUserId, TestPostCommentLikeServiceUtilities.TestNonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikeUserId, TestPostCommentLikeServiceUtilities.TestNonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestNonExistingUserId, TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikeUserId, TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikeId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasId_ReturnsExpectedResult(string userId, string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postCommentLikeService.DeleteAsync(userId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestPostCommentLikeServiceUtilities.TestNonExistingUserId, TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikeUserId, TestPostCommentLikeServiceUtilities.TestNonExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestNonExistingUserId, TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikeUserId, TestPostCommentLikeServiceUtilities.TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteByUserIdAndPostCommentIdAsync_HasArguments_ReturnsExpectedResult(string userId, string postCommentId, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postCommentLikeService.DeleteByUserIdAndPostCommentIdAsync(userId, postCommentId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

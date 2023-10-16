using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Post;
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
    public class PostLikeServiceTests
    {

        private Mock<IMapper> _mockMapper;
        private IResultFactory _resultFactory;
        private Mock<IPostLikeRepository> _mockPostLikeRepository;
        private Mock<IPostRepository> _mockPostRepository;
        private Mock<IInstaConnectUserManager> _mockInstaConnectUserManager;
        private IPostLikeService _postLikeService;

        public PostLikeServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockPostLikeRepository = new Mock<IPostLikeRepository>();
            _mockPostRepository = new Mock<IPostRepository>();
            _mockInstaConnectUserManager = new Mock<IInstaConnectUserManager>();
            _postLikeService = new PostLikeService(
                _mockMapper.Object,
                _resultFactory,
                _mockPostLikeRepository.Object,
                _mockPostRepository.Object,
                _mockInstaConnectUserManager.Object);

        }

        [SetUp]
        public void Setup()
        {
            _mockPostRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Post, bool>>>()))
               .ReturnsAsync((Expression<Func<Post, bool>> expression) => TestPostLikeServiceUtilities.TestPosts.Find(new Predicate<Post>(expression.Compile())));

            _mockPostLikeRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<PostLike, bool>>>())).
                ReturnsAsync((Expression<Func<PostLike, bool>> expression) => TestPostLikeServiceUtilities.TestPostLikes.Find(new Predicate<PostLike>(expression.Compile())));

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestPostLikeServiceUtilities.TestExistingUserId))
                .ReturnsAsync(TestPostLikeServiceUtilities.TestExistingUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestPostLikeServiceUtilities.TestExistingPostCommentUserId))
                .ReturnsAsync(TestPostLikeServiceUtilities.TestExistingUser);
        }

        [Test]
        [TestCase(TestPostLikeServiceUtilities.TestNonExistingPostLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostLikeServiceUtilities.TestExistingPostLikeId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postLikeService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestPostLikeServiceUtilities.TestNonExistingUserId, TestPostLikeServiceUtilities.TestNonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostLikeServiceUtilities.TestExistingPostCommentUserId, TestPostLikeServiceUtilities.TestNonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostLikeServiceUtilities.TestNonExistingUserId, TestPostLikeServiceUtilities.TestExistingPostCommentPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostLikeServiceUtilities.TestExistingPostCommentUserId, TestPostLikeServiceUtilities.TestExistingPostCommentPostId, InstaConnectStatusCode.OK)]
        public async Task GetByUserIdAndPostId_HasArguments_ReturnsExpectedResult(string userId, string postId, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postLikeService.GetByUserIdAndPostIdAsync(userId, postId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestPostLikeServiceUtilities.TestExistingUserId, TestPostLikeServiceUtilities.TestExistingPostId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestPostLikeServiceUtilities.TestNonExistingUserId, TestPostLikeServiceUtilities.TestNonExistingPostId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostLikeServiceUtilities.TestNonExistingUserId, TestPostLikeServiceUtilities.TestExistingPostId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostLikeServiceUtilities.TestExistingUserId, TestPostLikeServiceUtilities.TestNonExistingPostId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostLikeServiceUtilities.TestExistingUserId, TestPostLikeServiceUtilities.TestExistingPostCommentPostId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestPostLikeServiceUtilities.TestExistingPostCommentUserId, TestPostLikeServiceUtilities.TestExistingPostId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestPostLikeServiceUtilities.TestExistingPostCommentUserId, TestPostLikeServiceUtilities.TestExistingPostCommentPostId, InstaConnectStatusCode.BadRequest)]
        public async Task AddAsync_HasArguments_ReturnsExpectedResult(string userId, string postId, InstaConnectStatusCode statusCode)
        {
            // Arrange
            var postLikeAddDTO = new PostLikeAddDTO()
            {
                UserId = userId,
                PostId = postId
            };

            // Act
            var result = await _postLikeService.AddAsync(postLikeAddDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestPostLikeServiceUtilities.TestNonExistingUserId, TestPostLikeServiceUtilities.TestNonExistingPostLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostLikeServiceUtilities.TestExistingPostCommentUserId, TestPostLikeServiceUtilities.TestNonExistingPostLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostLikeServiceUtilities.TestNonExistingUserId, TestPostLikeServiceUtilities.TestExistingPostLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostLikeServiceUtilities.TestExistingPostCommentUserId, TestPostLikeServiceUtilities.TestExistingPostLikeId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasArguments_ReturnsExpectedResult(string userId, string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postLikeService.DeleteAsync(userId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestPostLikeServiceUtilities.TestNonExistingUserId, TestPostLikeServiceUtilities.TestNonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostLikeServiceUtilities.TestExistingPostCommentUserId, TestPostLikeServiceUtilities.TestNonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostLikeServiceUtilities.TestNonExistingUserId, TestPostLikeServiceUtilities.TestExistingPostCommentPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostLikeServiceUtilities.TestExistingPostCommentUserId, TestPostLikeServiceUtilities.TestExistingPostCommentPostId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteByUserIdAndPostIdAsync_HasArguments_ReturnsExpectedResult(string userId, string postId, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postLikeService.DeleteByUserIdAndPostIdAsync(userId, postId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

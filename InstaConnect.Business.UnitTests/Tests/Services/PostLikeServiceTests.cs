using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.PostLike;
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
    public class PostLikeServiceTests
    {
        public const string ExistingPostId = "ExistingPostId";
        public const string NonExistingPostId = "NonExistingPostId";
        public const string ExistingPostCommentPostId = "ExistingPostCommentPostId";

        public const string ExistingPostLikeId = "ExistingPostLikeId";
        public const string NonExistingPostLikeId = "NonExistingPostLikeId";

        public const string ExistingUserId = "ExistingUserId";
        public const string NonExistingUserId = "NonExistingUserId";
        public const string ExistingPostCommentUserId = "ExistingPostCommentUserId";

        private Mock<IMapper> _mockMapper;
        private IResultFactory _resultFactory;
        private Mock<IPostLikeRepository> _mockPostLikeRepository;
        private Mock<IPostRepository> _mockPostRepository;
        private Mock<IUserRepository> _mockUserRepository;
        private IPostLikeService _postLikeService;

        public PostLikeServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockPostLikeRepository = new Mock<IPostLikeRepository>();
            _mockPostRepository = new Mock<IPostRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _postLikeService = new PostLikeService(
                _mockMapper.Object,
                _resultFactory,
                _mockPostLikeRepository.Object,
                _mockPostRepository.Object,
                _mockUserRepository.Object);
        }

        [SetUp]
        public void Setup()
        {
            var existingPost = new Post()
            {
                Id = ExistingPostId,
                UserId = ExistingUserId
            };

            var existingPostCommentPost = new Post()
            {
                Id = ExistingPostCommentPostId,
                UserId = ExistingPostCommentUserId
            };

            var existingPosts = new List<Post>()
            {
                existingPost,
                existingPostCommentPost
            };

            var existingPostLike = new PostLike()
            {
                Id = ExistingPostLikeId,
                UserId = ExistingPostCommentUserId,
                PostId = ExistingPostCommentPostId
            };

            var existingPostLikes = new List<PostLike>()
            {
                existingPostLike
            };

            var existingUser = new User()
            {
                Id = ExistingUserId
            };

            var existingPostCommentUser = new User()
            {
                Id = ExistingPostCommentUserId
            };

            var existingUsers = new List<User>()
            {
                existingUser,
                existingPostCommentUser
            };

            _mockPostRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Post, bool>>>()))
               .ReturnsAsync((Expression<Func<Post, bool>> expression) => existingPosts.Find(new Predicate<Post>(expression.Compile())));

            _mockPostLikeRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<PostLike, bool>>>()))
                .ReturnsAsync((Expression<Func<PostLike, bool>> expression) => existingPostLikes.Find(new Predicate<PostLike>(expression.Compile())));

            _mockUserRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync((Expression<Func<User, bool>> expression) => existingUsers.Find(new Predicate<User>(expression.Compile())));
        }

        [Test]
        [TestCase(NonExistingPostLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostLikeId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postLikeService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserId, NonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostCommentUserId, NonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingUserId, ExistingPostCommentPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostCommentUserId, ExistingPostCommentPostId, InstaConnectStatusCode.OK)]
        public async Task GetByUserIdAndPostId_HasArguments_ReturnsExpectedResult(
            string userId,
            string postId,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postLikeService.GetByUserIdAndPostIdAsync(userId, postId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(ExistingUserId, ExistingPostId, InstaConnectStatusCode.NoContent)]
        [TestCase(NonExistingUserId, NonExistingPostId, InstaConnectStatusCode.BadRequest)]
        [TestCase(NonExistingUserId, ExistingPostId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, NonExistingPostId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, ExistingPostCommentPostId, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingPostCommentUserId, ExistingPostId, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingPostCommentUserId, ExistingPostCommentPostId, InstaConnectStatusCode.BadRequest)]
        public async Task AddAsync_HasArguments_ReturnsExpectedResult(
            string userId,
            string postId,
            InstaConnectStatusCode statusCode)
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
        [TestCase(NonExistingUserId, NonExistingPostLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostCommentUserId, NonExistingPostLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingUserId, ExistingPostLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostCommentUserId, ExistingPostLikeId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasArguments_ReturnsExpectedResult(
            string userId,
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postLikeService.DeleteAsync(userId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserId, NonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostCommentUserId, NonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingUserId, ExistingPostCommentPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostCommentUserId, ExistingPostCommentPostId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteByUserIdAndPostIdAsync_HasArguments_ReturnsExpectedResult(
            string userId,
            string postId,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postLikeService.DeleteByUserIdAndPostIdAsync(userId, postId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

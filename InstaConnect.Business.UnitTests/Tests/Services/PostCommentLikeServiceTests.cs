using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.PostCommentLike;
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
    public class PostCommentLikeServiceTests
    {
        private const string ExistingPostCommentLikeId = "ExistingPostCommentLikeId";
        private const string NonExistingPostCommentLikeId = "NonExistingPostCommentLikeId";
  
        private const string ExistingPostCommentId = "ExistingPostCommentId";
        private const string NonExistingPostCommentId = "NonExistingPostCommentId";
        private const string ExistingPostCommentLikePostCommentId = "ExistingLikePostCommentId";
  
        private const string ExistingUserId = "ExistingUserId";
        private const string NonExistingUserId = "NonExistingUserId";
        private const string ExistingPostCommentLikeUserId = "ExistingLikeUserId";

        private Mock<IMapper> _mockMapper;
        private IResultFactory _resultFactory;
        private Mock<IPostCommentLikeRepository> _mockPostCommentLikeRepository;
        private Mock<IPostCommentRepository> _mockPostCommentRepository;
        private Mock<IUserRepository> _mockUserRepository;
        private IPostCommentLikeService _postCommentLikeService;

        public PostCommentLikeServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockPostCommentLikeRepository = new Mock<IPostCommentLikeRepository>();
            _mockPostCommentRepository = new Mock<IPostCommentRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _postCommentLikeService = new PostCommentLikeService(
                _mockMapper.Object,
                _resultFactory,
                _mockPostCommentLikeRepository.Object,
                _mockPostCommentRepository.Object,
                _mockUserRepository.Object);
        }

        [SetUp]
        public void Setup()
        {
            var existingPostCommentLike = new PostCommentLike()
            {
                Id = ExistingPostCommentLikeId,
                UserId = ExistingPostCommentLikeUserId,
                PostCommentId = ExistingPostCommentLikePostCommentId
            };

            var existingPostCommentLikes = new List<PostCommentLike>()
            {
                existingPostCommentLike
            };

            var existingPostComment = new PostComment()
            {
                Id = ExistingPostCommentId
            };

            var existingChildPostComment = new PostComment()
            {
                Id = ExistingPostCommentLikePostCommentId
            };

            var existingPostComments = new List<PostComment>()
            {
                existingPostComment,
                existingChildPostComment
            };

            var existingUser = new User()
            {
                Id = ExistingUserId
            };

            var existingPostCommentLikeUser = new User()
            {
                Id = ExistingPostCommentLikeUserId
            };

            var existingUsers = new List<User>()
            {
                existingUser,
                existingPostCommentLikeUser
            };

            _mockPostCommentRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<PostComment, bool>>>()))
                .ReturnsAsync((Expression<Func<PostComment, bool>> expression) => existingPostComments.Find(new Predicate<PostComment>(expression.Compile())));

            _mockPostCommentLikeRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<PostCommentLike, bool>>>())).
                ReturnsAsync((Expression<Func<PostCommentLike, bool>> expression) => existingPostCommentLikes.Find(new Predicate<PostCommentLike>(expression.Compile())));

            _mockUserRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<User, bool>>>())).
                ReturnsAsync((Expression<Func<User, bool>> expression) => existingUsers.Find(new Predicate<User>(expression.Compile())));
        }

        [Test]
        [TestCase(ExistingPostCommentLikeId, InstaConnectStatusCode.OK)]
        [TestCase(NonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        public async Task GetById_HasId_ReturnsExpectedResult(
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postCommentLikeService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserId, NonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostCommentLikeUserId, NonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingUserId, ExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostCommentLikeUserId, ExistingPostCommentLikePostCommentId, InstaConnectStatusCode.OK)]
        public async Task GetByUserIdAndPostCommentIdAsync_HasArguments_ReturnsExpectedResult(
            string userId,
            string postCommentId,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postCommentLikeService.GetByUserIdAndPostCommentIdAsync(userId, postCommentId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserId, NonExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(NonExistingUserId, ExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, NonExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, ExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingUserId, ExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingPostCommentLikeUserId, ExistingPostCommentId, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingPostCommentLikeUserId, ExistingPostCommentLikePostCommentId, InstaConnectStatusCode.BadRequest)]
        public async Task AddAsync_HasArguments_ReturnsExpectedResult(
            string userId,
            string postCommentId,
            InstaConnectStatusCode statusCode)
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
        [TestCase(NonExistingUserId, NonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostCommentLikeUserId, NonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingUserId, ExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostCommentLikeUserId, ExistingPostCommentLikeId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasId_ReturnsExpectedResult(
            string userId,
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postCommentLikeService.DeleteAsync(userId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserId, ExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostCommentLikeUserId, NonExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingUserId, ExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostCommentLikeUserId, ExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteByUserIdAndPostCommentIdAsync_HasArguments_ReturnsExpectedResult(
            string userId,
            string postCommentId,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postCommentLikeService.DeleteByUserIdAndPostCommentIdAsync(userId, postCommentId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

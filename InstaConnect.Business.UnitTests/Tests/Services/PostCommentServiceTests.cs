using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.PostComment;
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
    public class PostCommentServiceTests
    {
        private const string ExistingPostId = "ExistingPostId";
        private const string NonExistingPostId = "NonExistingPostId";

        private const string ExistingPostCommentId = "ExistingPostCommentId";
        private const string NonExistingPostCommentId = "NonExistingPostCommentId";
     
        private const string ExistingUserId = "ExistingUserId";
        private const string NonExistingUserId = "NonExistingUserId";

        private readonly Mock<IMapper> _mockMapper;
        private readonly IResultFactory _resultFactory;
        private readonly Mock<IPostCommentRepository> _mockPostCommentRepository;
        private readonly Mock<IPostRepository> _mockPostRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IAccountManager> _mockAccountManager;
        private readonly IPostCommentService _postCommentService;

        public PostCommentServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockPostCommentRepository = new Mock<IPostCommentRepository>();
            _mockPostRepository = new Mock<IPostRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockAccountManager = new Mock<IAccountManager>();
            _postCommentService = new PostCommentService(
                _mockMapper.Object,
                _resultFactory,
                _mockPostCommentRepository.Object,
                _mockPostRepository.Object,
                _mockUserRepository.Object,
                _mockAccountManager.Object);
        }

        [SetUp]
        public void Setup()
        {
            var existingPosts = new List<Post>()
            {
                new Post()
                {
                    Id = ExistingPostId
                }
            };

            var existingPostComments = new List<PostComment>()
            {
                new PostComment() {
                    Id = ExistingPostCommentId,
                    UserId = ExistingUserId,
                    PostId = ExistingPostId,
                    PostCommentId = ExistingPostCommentId
                }
            };

            var existingUser = new User()
            {
                Id = ExistingUserId
            };

            var existingUsers = new List<User>()
            {
                existingUser
            };

            _mockPostRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Post, bool>>>()))
               .ReturnsAsync((Expression<Func<Post, bool>> expression) => existingPosts.Find(new Predicate<Post>(expression.Compile())));

            _mockPostCommentRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<PostComment, bool>>>())).
                ReturnsAsync((Expression<Func<PostComment, bool>> expression) => existingPostComments.Find(new Predicate<PostComment>(expression.Compile())));

            _mockUserRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<User, bool>>>())).
                ReturnsAsync((Expression<Func<User, bool>> expression) => existingUsers.Find(new Predicate<User>(expression.Compile())));

            _mockAccountManager.Setup(m => m.ValidateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns<string, string>((currentUserId, userId) => currentUserId == userId);
        }

        [Test]
        [TestCase(NonExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostCommentId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasArguments_ReturnsExpectedResult(
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Act 
            var result = await _postCommentService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(ExistingUserId, NonExistingUserId, NonExistingPostId, NonExistingPostCommentId, InstaConnectStatusCode.Forbidden)]
        [TestCase(NonExistingUserId, NonExistingUserId, NonExistingPostId, NonExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, ExistingUserId, NonExistingPostId, NonExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(NonExistingUserId, NonExistingUserId, ExistingPostId, NonExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, ExistingUserId, ExistingPostId, NonExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(NonExistingUserId, NonExistingUserId, NonExistingPostId, ExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, ExistingUserId, NonExistingPostId, ExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(NonExistingUserId, NonExistingUserId, ExistingPostId, ExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, ExistingUserId, ExistingPostId, ExistingPostCommentId, InstaConnectStatusCode.NoContent)]
        [TestCase(NonExistingUserId, NonExistingUserId, NonExistingPostId, null, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, ExistingUserId, NonExistingPostId, null, InstaConnectStatusCode.BadRequest)]
        [TestCase(NonExistingUserId, NonExistingUserId, ExistingPostId, null, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, ExistingUserId, ExistingPostId, null, InstaConnectStatusCode.NoContent)]
        public async Task AddAsync_HasArguments_ReturnsExpectedResult(
            string currentUserId,
            string userId,
            string postId,
            string postCommentId,
            InstaConnectStatusCode statusCode)
        {
            // Arrange
            var postCommentAddDTO = new PostCommentAddDTO()
            {
                UserId = userId,
                PostId = postId,
                PostCommentId = postCommentId
            };

            // Act
            var result = await _postCommentService.AddAsync(currentUserId, postCommentAddDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(ExistingUserId, NonExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingUserId, ExistingPostCommentId, InstaConnectStatusCode.Forbidden)]
        [TestCase(NonExistingUserId, NonExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingUserId, ExistingPostCommentId, InstaConnectStatusCode.NoContent)]
        public async Task UpdateAsync_HasArguments_ReturnsExpectedResult(
            string userId,
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Arrange
            var postCommentUpdateDTO = new PostCommentUpdateDTO();

            // Act 
            var result = await _postCommentService.UpdateAsync(userId, id, postCommentUpdateDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(ExistingUserId, NonExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingUserId, ExistingPostCommentId, InstaConnectStatusCode.Forbidden)]
        [TestCase(NonExistingUserId, NonExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingUserId, ExistingPostCommentId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasArguments_ReturnsExpectedResult(
            string userId,
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Act 
            var result = await _postCommentService.DeleteAsync(userId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Post;
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
    public class PostServiceTests
    {
        private const string ExistingUserId = "ExistingUserId";
        private const string NonExistingUserId = "NonExistingUserId";

        private const string ExistingPostId = "ExistingPostId";
        private const string NonExistingPostId = "NonExistingPostId";

        private readonly Mock<IMapper> _mockMapper;
        private readonly IResultFactory _resultFactory;
        private readonly Mock<IPostRepository> _mockPostRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IAccountManager> _mockAccountManager;
        private readonly IPostService _postService;

        public PostServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockPostRepository = new Mock<IPostRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockAccountManager = new Mock<IAccountManager>();
            _postService = new PostService(
                _mockMapper.Object,
                _resultFactory,
                _mockPostRepository.Object,
                _mockUserRepository.Object,
                _mockAccountManager.Object);
        }

        [SetUp]
        public void Setup()
        {
            var existingPost = new Post()
            {
                Id = ExistingPostId,
                UserId = ExistingUserId
            };

            var existingPosts = new List<Post>()
            {
                existingPost
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

            _mockUserRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<User, bool>>>()))
               .ReturnsAsync((Expression<Func<User, bool>> expression) => existingUsers.Find(new Predicate<User>(expression.Compile())));

            _mockAccountManager.Setup(m => m.ValidateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns<string, string>((currentUserId, userId) => currentUserId == userId);
        }

        [Test]
        [TestCase(NonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(ExistingUserId, NonExistingUserId, InstaConnectStatusCode.Forbidden)]
        [TestCase(NonExistingUserId, NonExistingUserId, InstaConnectStatusCode.BadRequest)]
        [TestCase(NonExistingUserId, ExistingUserId, InstaConnectStatusCode.Forbidden)]
        [TestCase(ExistingUserId, ExistingUserId, InstaConnectStatusCode.NoContent)]
        public async Task AddAsync_HasArguments_ReturnsExpectedResult(
            string currentUserId,
            string userId,
            InstaConnectStatusCode statusCode)
        {
            // Arrange
            var postAddDTO = new PostAddDTO()
            {
                UserId = userId
            };

            // Act
            var result = await _postService.AddAsync(currentUserId, postAddDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserId, NonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingUserId, NonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingUserId, ExistingPostId, InstaConnectStatusCode.Forbidden)]
        [TestCase(ExistingUserId, ExistingPostId, InstaConnectStatusCode.NoContent)]
        public async Task UpdateAsync_HasUserIdAndPostId_ReturnsExpectedResult(
            string userId,
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Arrange
            var postUpdateDTO = new PostUpdateDTO();

            // Act
            var result = await _postService.UpdateAsync(userId, id, postUpdateDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserId, NonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingUserId, NonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingUserId, ExistingPostId, InstaConnectStatusCode.Forbidden)]
        [TestCase(ExistingUserId, ExistingPostId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasUserIdAndPostId_ReturnsExpectedResult(
            string userId,
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postService.DeleteAsync(userId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

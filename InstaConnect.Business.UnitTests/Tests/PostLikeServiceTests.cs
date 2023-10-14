using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Post;
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
    public class PostLikeServiceTests
    {

        public const string TestExistingPostId = "ExistingPostId";
        public const string TestNonExistingPostId = "NonExistingPostId";
        public const string TestExistingPostLikeId = "ExistingPostLikeId";
        public const string TestNonExistingPostLikeId = "NonExistingPostLikeId";
        public const string TestExistingUserId = "ExistingUserId";
        public const string TestNonExistingUserId = "NonExistingUserId";
        public const string TestExistingPostIdThatHasPostLike = "ExistingCommentPostId";
        public const string TestExistingCommentPostLikeId = "ExistingCommentPostLikeId";
        public const string TestExistingCommentUserId = "ExistingCommentUserId";


        private IMapper _mapper;
        private IResultFactory _resultFactory;
        private Mock<IPostLikeRepository> _mockPostLikeRepository;
        private Mock<IPostRepository> _mockPostRepository;
        private Mock<IInstaConnectUserManager> _mockInstaConnectUserManager;
        private IPostLikeService _postLikeService;

        [SetUp]
        public void Setup()
        {

            var testPostList = new List<Post>()
            {
                new Post() { Id = TestExistingPostId, UserId = TestExistingUserId},
                new Post() { Id = TestExistingPostIdThatHasPostLike, UserId = TestExistingCommentUserId}
            };

            var testPostLikeList = new List<PostLike>()
            {
                new PostLike() { Id = TestExistingPostLikeId, UserId = TestExistingCommentUserId, PostId = TestExistingPostIdThatHasPostLike},
            };

            var testExistingUser = new User();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InstaConnectProfile());
            });

            _mapper = config.CreateMapper();
            _resultFactory = new ResultFactory();
            _mockPostLikeRepository = new Mock<IPostLikeRepository>();
            _mockPostRepository = new Mock<IPostRepository>();
            _mockInstaConnectUserManager = new Mock<IInstaConnectUserManager>();
            _postLikeService = new PostLikeService(
                _mapper, 
                _resultFactory,
                _mockPostLikeRepository.Object,
                _mockPostRepository.Object,
                _mockInstaConnectUserManager.Object);

            _mockPostRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Post, bool>>>()))
               .ReturnsAsync((Expression<Func<Post, bool>> expression) => testPostList.Find(new Predicate<Post>(expression.Compile())));

            _mockPostLikeRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<PostLike, bool>>>())).
                ReturnsAsync((Expression<Func<PostLike, bool>> expression) => testPostLikeList.Find(new Predicate<PostLike>(expression.Compile())));

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestExistingUserId))
                .ReturnsAsync(testExistingUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestExistingCommentUserId))
                .ReturnsAsync(testExistingUser);
        }

        [Test]
        [TestCase(TestNonExistingPostLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingPostLikeId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postLikeService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingUserId, TestNonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingUserId, TestNonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestNonExistingUserId, TestExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingCommentUserId, TestExistingPostIdThatHasPostLike, InstaConnectStatusCode.OK)]
        public async Task GetByUserIdAndPostId_HasArguments_ReturnsExpectedResult(string userId, string postId, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postLikeService.GetByUserIdAndPostIdAsync(userId, postId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestExistingUserId, TestExistingPostId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestNonExistingUserId, TestNonExistingPostId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestNonExistingUserId, TestExistingPostId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestExistingUserId, TestNonExistingPostId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestExistingUserId, TestExistingPostIdThatHasPostLike, InstaConnectStatusCode.NoContent)]
        [TestCase(TestExistingCommentUserId, TestExistingPostId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestExistingCommentUserId, TestExistingPostIdThatHasPostLike, InstaConnectStatusCode.BadRequest)]
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
        [TestCase(TestNonExistingUserId, TestNonExistingPostLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingUserId, TestNonExistingPostLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestNonExistingUserId, TestExistingPostLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingCommentUserId, TestExistingPostLikeId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasId_ReturnsExpectedResult(string userId, string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postLikeService.DeleteAsync(userId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingUserId, TestNonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingUserId, TestNonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestNonExistingUserId, TestExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingCommentUserId, TestExistingPostIdThatHasPostLike, InstaConnectStatusCode.NoContent)]
        public async Task DeleteByUserIdAndPostIdAsync_HasArguments_ReturnsExpectedResult(string userId, string postId, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postLikeService.DeleteByUserIdAndPostIdAsync(userId, postId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

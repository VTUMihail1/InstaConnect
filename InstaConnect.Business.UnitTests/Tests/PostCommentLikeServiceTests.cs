using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.PostCommentLike;
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
    public class PostCommentLikeServiceTests
    {
        public const string TestExistingPostCommentLikeId = "ExistingPostCommentLikeId";
        public const string TestNonExistingPostCommentLikeId = "NonExistingPostCommentLikeId";
        public const string TestExistingPostCommentId = "ExistingPostCommentId";
        public const string TestNonExistingPostCommentId = "NonExistingPostCommentId";
        public const string TestExistingUserId = "ExistingUserId";
        public const string TestNonExistingUserId = "NonExistingUserId";
        public const string TestExistingPostCommentLikeUserId = "ExistingLikeUserId";
        public const string TestExistingPostCommentLikePostCommentId = "ExistingLikePostCommentId";

        private IMapper _mapper;
        private IResultFactory _resultFactory;
        private Mock<IPostCommentLikeRepository> _mockPostCommentLikeRepository;
        private Mock<IPostCommentRepository> _mockPostCommentRepository;
        private Mock<IInstaConnectUserManager> _mockInstaConnectUserManager;
        private IPostCommentLikeService _postCommentLikeService;

        [SetUp]
        public void Setup()
        {

            var testPostCommentLikes = new List<PostCommentLike>()
            {
                new PostCommentLike() 
                { 
                    Id = TestExistingPostCommentLikeId, 
                    UserId = TestExistingPostCommentLikeUserId, 
                    PostCommentId = TestExistingPostCommentLikePostCommentId
                }
            };

            var testPostComments = new List<PostComment>()
            {
                new PostComment() { Id = TestExistingPostCommentId},
                new PostComment() { Id = TestExistingPostCommentLikePostCommentId}
            };

            var testExistingUser = new User();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InstaConnectProfile());
            });

            _mapper = config.CreateMapper();
            _resultFactory = new ResultFactory();
            _mockPostCommentLikeRepository = new Mock<IPostCommentLikeRepository>();
            _mockPostCommentRepository = new Mock<IPostCommentRepository>();
            _mockInstaConnectUserManager = new Mock<IInstaConnectUserManager>();
            _postCommentLikeService = new PostCommentLikeService(
                _mapper,
                _resultFactory,
                _mockPostCommentLikeRepository.Object,
                _mockPostCommentRepository.Object,
                _mockInstaConnectUserManager.Object);

            _mockPostCommentRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<PostComment, bool>>>()))
               .ReturnsAsync((Expression<Func<PostComment, bool>> expression) => testPostComments.Find(new Predicate<PostComment>(expression.Compile())));

            _mockPostCommentLikeRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<PostCommentLike, bool>>>())).
                ReturnsAsync((Expression<Func<PostCommentLike, bool>> expression) => testPostCommentLikes.Find(new Predicate<PostCommentLike>(expression.Compile())));

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestExistingUserId))
                .ReturnsAsync(testExistingUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestExistingPostCommentLikeUserId))
                .ReturnsAsync(testExistingUser);
        }

        [Test]
        [TestCase(TestExistingPostCommentLikeId, InstaConnectStatusCode.OK)]
        [TestCase(TestNonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        public async Task GetById_HasId_ReturnsExpectedResult(string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postCommentLikeService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingUserId, TestNonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingPostCommentLikeUserId, TestNonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestNonExistingUserId, TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingPostCommentLikeUserId, TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.OK)]
        public async Task GetByUserIdAndPostCommentIdAsync_HasArguments_ReturnsExpectedResult(string userId, string postCommentId, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postCommentLikeService.GetByUserIdAndPostCommentIdAsync(userId, postCommentId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingUserId, TestNonExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestNonExistingUserId, TestExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestExistingUserId, TestNonExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestExistingUserId, TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestExistingUserId, TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestExistingPostCommentLikeUserId, TestExistingPostCommentId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestExistingPostCommentLikeUserId, TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.BadRequest)]
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
        [TestCase(TestNonExistingUserId, TestNonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingPostCommentLikeUserId, TestNonExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestNonExistingUserId, TestExistingPostCommentLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingPostCommentLikeUserId, TestExistingPostCommentLikeId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasId_ReturnsExpectedResult(string userId, string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postCommentLikeService.DeleteAsync(userId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingUserId, TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingPostCommentLikeUserId, TestNonExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestNonExistingUserId, TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingPostCommentLikeUserId, TestExistingPostCommentLikePostCommentId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteByUserIdAndPostCommentIdAsync_HasArguments_ReturnsExpectedResult(string userId, string postCommentId, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postCommentLikeService.DeleteByUserIdAndPostCommentIdAsync(userId, postCommentId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

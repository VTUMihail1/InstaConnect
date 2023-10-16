using AutoMapper;
using EllipticCurve;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.PostComment;
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
    public class PostCommentServiceTests
    {
        private Mock<IMapper> _mockMapper;
        private IResultFactory _resultFactory;
        private Mock<IPostCommentRepository> _mockPostCommentRepository;
        private Mock<IPostRepository> _mockPostRepository;
        private Mock<IInstaConnectUserManager> _mockInstaConnectUserManager;
        private IPostCommentService _postCommentService;

        public PostCommentServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockPostCommentRepository = new Mock<IPostCommentRepository>();
            _mockPostRepository = new Mock<IPostRepository>();
            _mockInstaConnectUserManager = new Mock<IInstaConnectUserManager>();
            _postCommentService = new PostCommentService(
                _mockMapper.Object,
                _resultFactory,
                _mockPostCommentRepository.Object,
                _mockPostRepository.Object,
                _mockInstaConnectUserManager.Object);
        }

        [SetUp]
        public void Setup()
        {
            _mockPostRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Post, bool>>>()))
               .ReturnsAsync((Expression<Func<Post, bool>> expression) => TestPostCommentServiceUtilities.TestPosts.Find(new Predicate<Post>(expression.Compile())));

            _mockPostCommentRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<PostComment, bool>>>())).
                ReturnsAsync((Expression<Func<PostComment, bool>> expression) => TestPostCommentServiceUtilities.TestPostComments.Find(new Predicate<PostComment>(expression.Compile())));

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestPostCommentServiceUtilities.TestExistingUserId))
                .ReturnsAsync(TestPostCommentServiceUtilities.TestExistingUser);
        }

        [Test]
        [TestCase(TestPostCommentServiceUtilities.TestNonExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentServiceUtilities.TestExistingPostCommentId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasArguments_ReturnsExpectedResult(string id, InstaConnectStatusCode statusCode)
        {
            // Act 
            var result = await _postCommentService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestPostCommentServiceUtilities.TestNonExistingUserId, TestPostCommentServiceUtilities.TestNonExistingPostId, TestPostCommentServiceUtilities.TestNonExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostCommentServiceUtilities.TestExistingUserId, TestPostCommentServiceUtilities.TestNonExistingPostId, TestPostCommentServiceUtilities.TestNonExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostCommentServiceUtilities.TestNonExistingUserId, TestPostCommentServiceUtilities.TestExistingPostId, TestPostCommentServiceUtilities.TestNonExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostCommentServiceUtilities.TestExistingUserId, TestPostCommentServiceUtilities.TestExistingPostId, TestPostCommentServiceUtilities.TestNonExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostCommentServiceUtilities.TestNonExistingUserId, TestPostCommentServiceUtilities.TestNonExistingPostId, TestPostCommentServiceUtilities.TestExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostCommentServiceUtilities.TestExistingUserId, TestPostCommentServiceUtilities.TestNonExistingPostId, TestPostCommentServiceUtilities.TestExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostCommentServiceUtilities.TestNonExistingUserId, TestPostCommentServiceUtilities.TestExistingPostId, TestPostCommentServiceUtilities.TestExistingPostCommentId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostCommentServiceUtilities.TestExistingUserId, TestPostCommentServiceUtilities.TestExistingPostId, TestPostCommentServiceUtilities.TestExistingPostCommentId, InstaConnectStatusCode.NoContent)]
        [TestCase(TestPostCommentServiceUtilities.TestNonExistingUserId, TestPostCommentServiceUtilities.TestNonExistingPostId, null, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostCommentServiceUtilities.TestExistingUserId, TestPostCommentServiceUtilities.TestNonExistingPostId, null, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostCommentServiceUtilities.TestNonExistingUserId, TestPostCommentServiceUtilities.TestExistingPostId, null, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostCommentServiceUtilities.TestExistingUserId, TestPostCommentServiceUtilities.TestExistingPostId, null, InstaConnectStatusCode.NoContent)]
        public async Task AddAsync_HasArguments_ReturnsExpectedResult(
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
            var result = await _postCommentService.AddAsync(postCommentAddDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestPostCommentServiceUtilities.TestExistingUserId, TestPostCommentServiceUtilities.TestNonExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentServiceUtilities.TestNonExistingUserId, TestPostCommentServiceUtilities.TestExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentServiceUtilities.TestNonExistingUserId, TestPostCommentServiceUtilities.TestNonExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentServiceUtilities.TestExistingUserId, TestPostCommentServiceUtilities.TestExistingPostCommentId, InstaConnectStatusCode.NoContent)]
        public async Task UpdateAsync_HasArguments_ReturnsExpectedResult(string userId, string id, InstaConnectStatusCode statusCode)
        {
            // Arrange
            var postCommentUpdateDTO = new PostCommentUpdateDTO();

            // Act 
            var result = await _postCommentService.UpdateAsync(userId, id, postCommentUpdateDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestPostCommentServiceUtilities.TestExistingUserId, TestPostCommentServiceUtilities.TestNonExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentServiceUtilities.TestNonExistingUserId, TestPostCommentServiceUtilities.TestExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentServiceUtilities.TestNonExistingUserId, TestPostCommentServiceUtilities.TestNonExistingPostCommentId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostCommentServiceUtilities.TestExistingUserId, TestPostCommentServiceUtilities.TestExistingPostCommentId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasArguments_ReturnsExpectedResult(string userId, string id, InstaConnectStatusCode statusCode)
        {
            // Act 
            var result = await _postCommentService.DeleteAsync(userId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

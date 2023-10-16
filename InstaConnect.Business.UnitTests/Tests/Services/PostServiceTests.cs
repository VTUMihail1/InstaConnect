using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Services;
using InstaConnect.Business.UnitTests.Utilities;
using InstaConnect.Business.UnitTests.Utilities.Services;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Moq;
using NuGet.Frameworks;
using NUnit.Framework;
using System.Linq.Expressions;

namespace InstaConnect.Business.UnitTests.Tests.Services
{
    [TestFixture]
    public class PostServiceTests
    {
        private Mock<IMapper> _mockMapper;
        private IResultFactory _resultFactory;
        private Mock<IPostRepository> _mockPostRepository;
        private Mock<IInstaConnectUserManager> _mockInstaConnectUserManager;
        private IPostService _postService;

        public PostServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockPostRepository = new Mock<IPostRepository>();
            _mockInstaConnectUserManager = new Mock<IInstaConnectUserManager>();
            _postService = new PostService(
                _mockMapper.Object,
                _resultFactory,
                _mockPostRepository.Object,
                _mockInstaConnectUserManager.Object);
        }

        [SetUp]
        public void Setup()
        {
            _mockPostRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Post, bool>>>()))
               .ReturnsAsync((Expression<Func<Post, bool>> expression) => TestPostServiceUtilities.TestPosts.Find(new Predicate<Post>(expression.Compile())));

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestPostServiceUtilities.TestExistingUserId))
                .ReturnsAsync(TestPostServiceUtilities.TestExistingUser);
        }

        [Test]
        [TestCase(TestPostServiceUtilities.TestNonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostServiceUtilities.TestExistingPostId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestPostServiceUtilities.TestInvalidUserId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestPostServiceUtilities.TestExistingUserId, InstaConnectStatusCode.NoContent)]
        public async Task AddAsync_HasArguments_ReturnsExpectedResult(string userId, InstaConnectStatusCode statusCode)
        {
            // Arrange
            var postAddDTO = new PostAddDTO()
            {
                UserId = userId
            };

            // Act
            var result = await _postService.AddAsync(postAddDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestPostServiceUtilities.TestInvalidUserId, TestPostServiceUtilities.TestNonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostServiceUtilities.TestExistingUserId, TestPostServiceUtilities.TestNonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostServiceUtilities.TestInvalidUserId, TestPostServiceUtilities.TestExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostServiceUtilities.TestExistingUserId, TestPostServiceUtilities.TestExistingPostId, InstaConnectStatusCode.NoContent)]
        public async Task UpdateAsync_HasUserIdAndPostId_ReturnsExpectedResult(string userId, string id, InstaConnectStatusCode statusCode)
        {
            // Arrange
            var postUpdateDTO = new PostUpdateDTO();

            // Act
            var result = await _postService.UpdateAsync(userId, id, postUpdateDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestPostServiceUtilities.TestInvalidUserId, TestPostServiceUtilities.TestNonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostServiceUtilities.TestExistingUserId, TestPostServiceUtilities.TestNonExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostServiceUtilities.TestInvalidUserId, TestPostServiceUtilities.TestExistingPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestPostServiceUtilities.TestExistingUserId, TestPostServiceUtilities.TestExistingPostId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasUserIdAndPostId_ReturnsExpectedResult(string userId, string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postService.DeleteAsync(userId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

    }
}

using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Post;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Services;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Moq;
using NuGet.Frameworks;
using NUnit.Framework;
using System.Linq.Expressions;

namespace InstaConnect.Business.UnitTests.Tests
{
    [TestFixture]
    public class PostServiceTests
    {
        public const string TestValidUserId = "ValidUserId";
        public const string TestInvalidUserId = "InvalidUserId";
        public const string TestValidPostId = "ValidPostId";
        public const string TestInvalidPostId = "InvalidPostId";

        private IMapper _mapper;
        private IResultFactory _resultFactory;
        private Mock<IPostRepository> _mockPostRepository;
        private Mock<IInstaConnectUserManager> _mockInstaConnectUserManager;
        private IPostService _postService;

        [SetUp]
        public void Setup()
        {
            var testPostList = new List<Post>()
            {
                new Post() { Id = TestValidPostId, UserId = TestValidUserId}
            };

            User testValidUser = new User();
            User testInvalidUser = null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InstaConnectProfile());
            });
            _mapper = config.CreateMapper();
            _resultFactory = new ResultFactory();
            _mockPostRepository = new Mock<IPostRepository>();
            _mockInstaConnectUserManager = new Mock<IInstaConnectUserManager>();
            _postService = new PostService(_mapper, _resultFactory, _mockPostRepository.Object, _mockInstaConnectUserManager.Object);

            _mockPostRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Post, bool>>>()))
               .ReturnsAsync((Expression<Func<Post, bool>> expression) => testPostList.Find(new Predicate<Post>(expression.Compile())));

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestValidUserId))
                .ReturnsAsync(testValidUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestInvalidUserId))
                .ReturnsAsync(testInvalidUser);
        }

        [Test]
        [TestCase(TestInvalidPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestValidPostId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postService.GetByIdAsync(id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestInvalidUserId, InstaConnectStatusCode.BadRequest)]
		[TestCase(TestValidUserId, InstaConnectStatusCode.NoContent)]
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
        [TestCase(TestInvalidUserId, TestInvalidPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestValidUserId, TestInvalidPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestInvalidUserId, TestValidPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestValidUserId, TestValidPostId, InstaConnectStatusCode.NoContent)]
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
        [TestCase(TestInvalidUserId, TestInvalidPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestValidUserId, TestInvalidPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestInvalidUserId, TestValidPostId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestValidUserId, TestValidPostId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasUserIdAndPostId_ReturnsExpectedResult(string userId, string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _postService.DeleteAsync(userId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

﻿using AutoMapper;
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
        private const string ExistingPostId = "ExistingPostId";
        private const string NonExistingPostId = "NonExistingPostId";
        private const string ExistingPostCommentPostId = "ExistingPostCommentPostId";
       
        private const string ExistingPostLikeId = "ExistingPostLikeId";
        private const string NonExistingPostLikeId = "NonExistingPostLikeId";
  
        private const string ExistingUserId = "ExistingUserId";
        private const string NonExistingUserId = "NonExistingUserId";
        private const string ExistingPostCommentUserId = "ExistingPostCommentUserId";

        private readonly Mock<IMapper> _mockMapper;
        private readonly IResultFactory _resultFactory;
        private readonly Mock<IPostLikeRepository> _mockPostLikeRepository;
        private readonly Mock<IPostRepository> _mockPostRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IAccountManager> _mockAccountManager;
        private readonly IPostLikeService _postLikeService;

        public PostLikeServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockPostLikeRepository = new Mock<IPostLikeRepository>();
            _mockPostRepository = new Mock<IPostRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockAccountManager = new Mock<IAccountManager>();
            _postLikeService = new PostLikeService(
                _mockMapper.Object,
                _resultFactory,
                _mockPostLikeRepository.Object,
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

            _mockAccountManager.Setup(m => m.ValidateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns<string, string>((currentUserId, userId) => currentUserId == userId);
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
        [TestCase(ExistingUserId, NonExistingUserId, ExistingPostId, InstaConnectStatusCode.Forbidden)]
        [TestCase(ExistingUserId, ExistingUserId, ExistingPostId, InstaConnectStatusCode.NoContent)]
        [TestCase(NonExistingUserId, NonExistingUserId, ExistingPostId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, ExistingUserId, NonExistingPostId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, ExistingUserId, ExistingPostCommentPostId, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingPostCommentUserId, ExistingPostCommentUserId, ExistingPostId, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingPostCommentUserId, ExistingPostCommentUserId, ExistingPostCommentPostId, InstaConnectStatusCode.BadRequest)]
        public async Task AddAsync_HasArguments_ReturnsExpectedResult(
            string currentUserId,
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
            var result = await _postLikeService.AddAsync(currentUserId, postLikeAddDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserId, NonExistingPostLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingPostCommentUserId, NonExistingPostLikeId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingUserId, ExistingPostLikeId, InstaConnectStatusCode.Forbidden)]
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

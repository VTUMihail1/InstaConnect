using AutoMapper;
using EllipticCurve;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.PostComment;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Services;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Linq.Expressions;

namespace InstaConnect.Business.UnitTests.Tests
{
	[TestFixture]
	public class PostCommentServiceTests
	{
		public const string TestValidPostId = "ValidPostId";
		public const string TestInvalidPostId = "InvalidPostId";
		public const string TestValidPostCommentId = "ValidPostCommentId";
		public const string TestInvalidPostCommentId = "InvalidPostCommentId";
		public const string TestValidUserId = "ValidUserId";
		public const string TestInvalidUserId = "InvalidUserId";

		private IMapper _mapper;
		private IResultFactory _resultFactory;
		private Mock<IPostCommentRepository> _mockPostCommentRepository;
		private Mock<IPostRepository> _mockPostRepository;
		private Mock<IInstaConnectUserManager> _mockInstaConnectUserManager;
		private IPostCommentService _postCommentService;

        [SetUp]
		public void Setup()
		{

            var testPostList = new List<Post>()
            {
                new Post() { Id = TestValidPostId}
            };

			var testPostCommentList = new List<PostComment>()
			{
				new PostComment() { Id = TestValidPostCommentId}
			};

			User testValidUser = new User() { Id = TestValidUserId };
			User testInvalidUser = null;

			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new InstaConnectProfile());
			});

			_mapper = config.CreateMapper();
			_resultFactory = new ResultFactory();
			_mockPostCommentRepository = new Mock<IPostCommentRepository>();
			_mockPostRepository = new Mock<IPostRepository>();
			_mockInstaConnectUserManager = new Mock<IInstaConnectUserManager>();
			_postCommentService = new PostCommentService(
				_mapper, _resultFactory, 
				_mockPostCommentRepository.Object, 
				_mockPostRepository.Object, 
				_mockInstaConnectUserManager.Object);

            _mockPostRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Post, bool>>>()))
               .ReturnsAsync((Expression<Func<Post, bool>> expression) => testPostList.Find(new Predicate<Post>(expression.Compile())));

            _mockPostCommentRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<PostComment, bool>>>())).
				ReturnsAsync((Expression<Func<PostComment, bool>> expression) => testPostCommentList.Find(new Predicate<PostComment>(expression.Compile())));

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestValidUserId))
                .ReturnsAsync(testValidUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestInvalidUserId))
                .ReturnsAsync(testInvalidUser);
        }

		[Test]
		[TestCase(TestInvalidPostCommentId, InstaConnectStatusCode.NotFound)]
		[TestCase(TestValidPostCommentId, InstaConnectStatusCode.OK)]
		public async Task GetById_HasArguments_ReturnsExpectedResult(string id, InstaConnectStatusCode statusCode)
		{
			// Act 
			var result = await _postCommentService.GetByIdAsync(id);

			// Assert
			Assert.That(result.StatusCode, Is.EqualTo(statusCode));
		}

		[Test]
		[TestCase(TestInvalidUserId, TestInvalidPostId, TestInvalidPostCommentId, InstaConnectStatusCode.BadRequest)]
		[TestCase(TestValidUserId, TestInvalidPostId, TestInvalidPostCommentId, InstaConnectStatusCode.BadRequest)]
		[TestCase(TestInvalidUserId, TestValidPostId, TestInvalidPostCommentId, InstaConnectStatusCode.BadRequest)]
		[TestCase(TestValidUserId, TestValidPostId, TestInvalidPostCommentId, InstaConnectStatusCode.BadRequest)]
		[TestCase(TestInvalidUserId, TestInvalidPostId, TestValidPostCommentId, InstaConnectStatusCode.BadRequest)]
		[TestCase(TestValidUserId, TestInvalidPostId, TestValidPostCommentId, InstaConnectStatusCode.BadRequest)]
		[TestCase(TestInvalidUserId, TestValidPostId, TestValidPostCommentId, InstaConnectStatusCode.BadRequest)]
		[TestCase(TestValidUserId, TestValidPostId, TestValidPostCommentId, InstaConnectStatusCode.NoContent)]
		[TestCase(TestInvalidUserId, TestInvalidPostId, null, InstaConnectStatusCode.BadRequest)]
		[TestCase(TestValidUserId, TestInvalidPostId, null, InstaConnectStatusCode.BadRequest)]
		[TestCase(TestInvalidUserId, TestValidPostId, null, InstaConnectStatusCode.BadRequest)]
		[TestCase(TestValidUserId, TestValidPostId, null, InstaConnectStatusCode.NoContent)]
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
	}
}

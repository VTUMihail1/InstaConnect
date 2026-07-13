using InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Services;

public class AddPostCommentLikeServiceUnitTests : BasePostCommentLikeDomainCommandUnitTest
{
	private readonly AddPostCommentLikeCommandBuilderFactory _commandBuilderFactory;
	private readonly AddPostCommentLikeCommandBuilder _commandBuilder;
	private readonly AddPostCommentLikeCommand _command;

	private readonly PostInclude _include;
	private readonly PostCommentInclude _commentInclude;

	private readonly PostCommentLikeCommandService _service;

	public AddPostCommentLikeServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostComment, User);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();
		_commentInclude = CommentIncludeBuilderFactory.Create().WithUser().WithPost(_include).Build();

		_service = new(Mapper, EventPublisher, Repository, UserRepository, Factory, CommentRepository, IncludeBuilderFactory, CommentLikeRepository, CommentIncludeBuilderFactory, CommentLikeIncludeBuilderFactory);

		UserRepository.SetupGetById(_command, User, CancellationToken);
		Repository.SetupExistsById(_command, CancellationToken);
		CommentRepository.SetupGetById(_command, _commentInclude, PostComment, CancellationToken);
		Factory.SetupCreate(_command, PostCommentLike);
		CommentLikeRepository.SetupGetById(_command, PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
	{
		// Arrange
		UserRepository.RemoveGetById(_command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveExistsById(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostCommentNotFoundException_WhenCommentIdIsInvalid()
	{
		// Arrange
		CommentRepository.RemoveGetById(_command, _commentInclude, PostComment, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExists()
	{
		// Arrange
		CommentLikeRepository.SetupGetByIdExists(_command, PostCommentLike, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostCommentLike, _command);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneExistsByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCommentRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await CommentRepository.ShouldReceiveOneGetByIdAsync(_command, _commentInclude, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		Factory.ShouldReceiveOneCreate(_command);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCommentLikeRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldReceiveOneGetByIdAsync(_command, PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCommentLikeRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldReceiveOneAddAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(_command, PostCommentLike, CancellationToken);
	}
}

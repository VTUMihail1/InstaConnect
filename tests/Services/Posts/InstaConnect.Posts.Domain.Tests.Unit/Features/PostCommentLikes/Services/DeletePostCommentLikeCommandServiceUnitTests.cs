using InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostCommentLikes.Services;

public class DeletePostCommentLikeCommandServiceUnitTests : BasePostCommentLikeDomainCommandUnitTest
{
	private readonly DeletePostCommentLikeCommandBuilderFactory _commandBuilderFactory;
	private readonly DeletePostCommentLikeCommandBuilder _commandBuilder;
	private readonly DeletePostCommentLikeCommand _command;

	private readonly PostInclude _include;
	private readonly PostCommentInclude _commentInclude;
	private readonly PostCommentLikeInclude _commentLikeInclude;

	private readonly PostCommentLikeCommandService _service;

	public DeletePostCommentLikeCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostCommentLike);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();
		_commentInclude = CommentIncludeBuilderFactory.Create().WithUser().WithPost(_include).Build();
		_commentLikeInclude = CommentLikeIncludeBuilderFactory.Create().WithUser().WithPostComment(_commentInclude).Build();

		_service = new(Mapper, EventPublisher, Repository, UserRepository, Factory, CommentRepository, IncludeBuilderFactory, CommentLikeRepository, CommentIncludeBuilderFactory, CommentLikeIncludeBuilderFactory);

		Repository.SetupExistsById(_command, CancellationToken);
		CommentRepository.SetupExistsById(_command, CancellationToken);
		CommentLikeRepository.SetupGetById(_command, _commentLikeInclude, PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveExistsById(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostCommentNotFoundException_WhenCommentIdIsInvalid()
	{
		// Arrange
		CommentRepository.RemoveExistsById(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostCommentLikeNotFoundException_WhenUserIdIsInvalid()
	{
		// Arrange
		CommentLikeRepository.RemoveGetById(_command, _commentLikeInclude, PostCommentLike, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentLikeNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneExistsByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCommentRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await CommentRepository.ShouldReceiveOneExistsByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCommentLikeRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldReceiveOneGetByIdAsync(_command, _commentLikeInclude, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCommentLikeRepositoryDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await CommentLikeRepository.ShouldReceiveOneDeleteAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(_command, PostCommentLike, CancellationToken);
	}
}

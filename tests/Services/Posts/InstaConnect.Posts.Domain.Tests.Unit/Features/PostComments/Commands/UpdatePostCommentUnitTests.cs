using InstaConnect.Posts.Domain.Features.PostComments.Helpers;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Commands;

public class UpdatePostCommentUnitTests : BasePostCommentDomainCommandUnitTest
{
	private readonly UpdatePostCommentCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdatePostCommentCommandBuilder _commandBuilder;
	private readonly UpdatePostCommentCommand _command;

	private readonly PostInclude _include;
	private readonly PostCommentInclude _commentInclude;

	private readonly PostCommentCommandService _service;

	public UpdatePostCommentUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostComment);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();
		_commentInclude = CommentIncludeBuilderFactory.Create().WithUser().WithPost(_include).Build();

		_service = new(Mapper, EventPublisher, Repository, DateTimeProvider, Factory, UserRepository, CommentRepository, IncludeBuilderFactory, CommentIncludeBuilderFactory);

		Repository.SetupExistsById(_command, CancellationToken);
		CommentRepository.SetupGetById(_command, _commentInclude, PostComment, CancellationToken);
		DateTimeProvider.SetupGetOffsetUtcNow(_command, PostComment);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveExistsById(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentDoesNotExist()
	{
		// Arrange
		CommentRepository.RemoveGetById(_command, _commentInclude, PostComment, CancellationToken);

		// Assert
		await _service.ShouldThrowPostCommentNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostCommentForbiddenException_WhenUserIdIsInvalid()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		var command = _commandBuilder.WithUserId(user.Id).Build();

		// Assert
		await _service.ShouldThrowPostCommentForbiddenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(PostComment, _command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneExistsByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCommentRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await CommentRepository.ShouldReceiveOneGetByIdAsync(_command, _commentInclude, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldReceiveOneGetOffsetUtcNow(_command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCommentRepositoryUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await CommentRepository.ShouldReceiveOneUpdateAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(_command, PostComment, CancellationToken);
	}
}

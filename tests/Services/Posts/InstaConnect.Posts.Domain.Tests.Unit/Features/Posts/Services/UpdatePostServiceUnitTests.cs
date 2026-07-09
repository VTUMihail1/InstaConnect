using InstaConnect.Posts.Domain.Features.Posts.Helpers;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Services;

public class UpdatePostServiceUnitTests : BasePostDomainCommandUnitTest
{
	private readonly UpdatePostCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdatePostCommandBuilder _commandBuilder;
	private readonly UpdatePostCommand _command;

	private readonly PostInclude _include;

	private readonly PostCommandService _service;

	public UpdatePostServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Post);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();

		_service = new(Factory, Mapper, EventPublisher, Repository, DateTimeProvider, UserRepository, IncludeBuilderFactory);

		Repository.SetupGetById(_command, _include, Post, CancellationToken);
		DateTimeProvider.SetupGetOffsetUtcNow(_command, Post);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveGetById(_command, _include, Post, CancellationToken);

		// Assert
		await _service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostForbiddenException_WhenUserIdIsInvalid()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		var command = _commandBuilder.WithUserId(user.Id).Build();

		// Assert
		await _service.ShouldThrowPostForbiddenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(Post, _command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(_command, _include, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneUpdateAsync(_command, CancellationToken);
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
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(_command, Post, CancellationToken);
	}
}

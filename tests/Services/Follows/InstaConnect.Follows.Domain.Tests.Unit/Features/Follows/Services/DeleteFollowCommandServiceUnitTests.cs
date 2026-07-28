using InstaConnect.Follows.Domain.Features.Follows.Helpers;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Services;

public class DeleteFollowCommandServiceUnitTests : BaseFollowDomainCommandUnitTest
{
	private readonly DeleteFollowCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteFollowCommandBuilder _commandBuilder;
	private readonly DeleteFollowCommand _command;

	private readonly FollowInclude _include;

	private readonly FollowCommandService _service;

	public DeleteFollowCommandServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Follow);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithFollower().WithFollowing().Build();

		_service = new(Factory, Mapper, EventPublisher, Repository, UserRepository, NotificationService, IncludeBuilderFactory);

		Repository.SetupGetById(_command, _include, Follow, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowFollowNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveGetById(_command, _include, Follow, CancellationToken);

		// Assert
		await _service.ShouldThrowFollowNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(_command, _include, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheRepositoryDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneDeleteAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(_command, Follow, CancellationToken);
	}
}

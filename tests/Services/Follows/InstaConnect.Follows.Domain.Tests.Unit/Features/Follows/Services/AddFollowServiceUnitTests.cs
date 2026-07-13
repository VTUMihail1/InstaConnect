using InstaConnect.Follows.Domain.Features.Follows.Helpers;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Services;

public class AddFollowServiceUnitTests : BaseFollowDomainCommandUnitTest
{
	private readonly AddFollowCommandBuilderFactory _commandBuilderFactory;
	private readonly AddFollowCommandBuilder _commandBuilder;
	private readonly AddFollowCommand _command;

	private readonly FollowCommandService _service;

	public AddFollowServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Follower, Following);
		_command = _commandBuilder.Build();

		_service = new(Factory, Mapper, EventPublisher, Repository, UserRepository, NotificationService, IncludeBuilderFactory);

		UserRepository.SetupGetByFollowerId(_command, Follower, CancellationToken);
		UserRepository.SetupGetByFollowingId(_command, Following, CancellationToken);
		Factory.SetupCreate(_command, Follow);
		Repository.SetupExistsById(_command, Follow, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenFollowerIdIsInvalid()
	{
		// Arrange
		UserRepository.RemoveGetByFollowerId(_command, Follower, CancellationToken);

		// Assert
		await _service.ShouldThrowFollowerNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenFollowingIdIsInvalid()
	{
		// Arrange
		UserRepository.RemoveGetByFollowingId(_command, Following, CancellationToken);

		// Assert
		await _service.ShouldThrowFollowingNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExists()
	{
		// Arrange
		Repository.SetupExistsByIdExists(_command, Follow, CancellationToken);

		// Assert
		await _service.ShouldThrowFollowAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(Follow, _command);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryGetByFollowerIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByFollowerIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryGetByFollowingIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByFollowingIdAsync(_command, CancellationToken);
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
	public async Task AddAsync_ShouldCallTheRepositoryExistsByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneExistsByIdAsync(_command, Follow, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneAddAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(_command, Follow, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheNotificationServiceAddedAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await NotificationService.ShouldReceiveOneAddedAsync(_command, Follow, CancellationToken);
	}
}

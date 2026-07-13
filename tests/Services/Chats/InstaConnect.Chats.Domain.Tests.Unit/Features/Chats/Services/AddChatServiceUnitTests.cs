using InstaConnect.Chats.Domain.Features.Chats.Helpers;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Domain.Tests.Unit.Features.Chats.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.Chats.Services;

public class AddChatServiceUnitTests : BaseChatDomainCommandUnitTest
{
	private readonly AddChatCommandBuilderFactory _commandBuilderFactory;
	private readonly AddChatCommandBuilder _commandBuilder;
	private readonly AddChatCommand _command;

	private readonly ChatCommandService _service;

	public AddChatServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(ParticipantOne, ParticipantTwo);
		_command = _commandBuilder.Build();

		_service = new(Factory, Mapper, EventPublisher, Repository, UserRepository);

		UserRepository.SetupGetByParticipantOneId(_command, ParticipantOne, CancellationToken);
		UserRepository.SetupGetByParticipantTwoId(_command, ParticipantTwo, CancellationToken);
		Factory.SetupCreate(_command, Chat);
		Repository.SetupGetById(_command, Chat, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenParticipantOneIdIsInvalid()
	{
		// Arrange
		UserRepository.RemoveGetByParticipantOneId(_command, ParticipantOne, CancellationToken);

		// Assert
		await _service.ShouldThrowParticipantOneNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenParticipantTwoIdIsInvalid()
	{
		// Arrange
		UserRepository.RemoveGetByParticipantTwoId(_command, ParticipantTwo, CancellationToken);

		// Assert
		await _service.ShouldThrowParticipantTwoNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExists()
	{
		// Arrange
		Repository.SetupGetByIdExists(_command, Chat, CancellationToken);

		// Assert
		await _service.ShouldThrowChatAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(Chat, _command);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryGetByParticipantOneIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByParticipantOneIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheUserRepositoryGetByParticipantTwoIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByParticipantTwoIdAsync(_command, CancellationToken);
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
	public async Task AddAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(_command, Chat, CancellationToken);
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
		await EventPublisher.ShouldReceiveOnePublishAsync(_command, Chat, CancellationToken);
	}
}

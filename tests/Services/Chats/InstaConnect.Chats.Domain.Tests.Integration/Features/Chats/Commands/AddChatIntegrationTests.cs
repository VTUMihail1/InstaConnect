using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Builders;
using InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Assertions;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Commands;

public class AddChatIntegrationTests : BaseChatDomainCommandIntegrationTest
{
	private readonly AddChatCommandBuilderFactory _commandBuilderFactory;
	private readonly AddChatCommandBuilder _commandBuilder;
	private readonly AddChatCommand _command;

	public AddChatIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(ParticipantOne, ParticipantTwo);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddUserAsync(ParticipantTwo, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenParticipantOneIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(ParticipantOne, CancellationToken);

		// Assert
		await Service.ShouldThrowParticipantOneNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenParticipantTwoIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(ParticipantTwo, CancellationToken);

		// Assert
		await Service.ShouldThrowParticipantTwoNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddChatAsync(Chat, CancellationToken);

		// Assert
		await Service.ShouldThrowChatAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExistsAndParticipantOneIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddChatAsync(Chat, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Assert
		await Service.ShouldThrowChatAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenChatAlreadyExistsAndParticipantTwoIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddChatAsync(Chat, CancellationToken);
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Assert
		await Service.ShouldThrowChatAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddChatAsync(Chat, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Assert
		await Service.ShouldThrowChatAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExistsAndParticipantOneIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddChatAsync(Chat, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Assert
		await Service.ShouldThrowChatAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowChatAlreadyExistsException_WhenInvertedChatAlreadyExistsAndParticipantTwoIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddChatAsync(Chat, CancellationToken);
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Assert
		await Service.ShouldThrowChatAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chat, _command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chat, command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chat, command);
	}

	[Fact]
	public async Task AddAsync_ShouldAddChat_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChat_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChat_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response, CancellationToken);

		// Assert
		chat.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishChatAddedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedChatAddedAsync(_command, chat, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishChatAddedEvent_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedChatAddedAsync(command, chat, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishChatAddedEvent_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chat = await ServiceScope.GetChatByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedChatAddedAsync(command, chat, CancellationToken);
	}
}

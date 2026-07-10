using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;
using InstaConnect.Chats.Domain.Tests.Integration.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.ChatMessages.Commands;

public class AddChatMessageIntegrationTests : BaseChatMessageDomainCommandIntegrationTest
{
	private readonly AddChatMessageCommandBuilderFactory _commandBuilderFactory;
	private readonly AddChatMessageCommandBuilder _commandBuilder;
	private readonly AddChatMessageCommand _command;

	public AddChatMessageIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(Chat);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(ParticipantOne, CancellationToken);
		await ServiceScope.AddUserAsync(ParticipantTwo, CancellationToken);
		await ServiceScope.AddChatAsync(Chat, CancellationToken);

		await base.OnInitializeAsync();
	}

	[Fact]
	public async Task AddAsync_ShouldThrowChatNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteChatAsync(Chat, CancellationToken);

		// Assert
		await Service.ShouldThrowChatNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, _command);
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
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, command);
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
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, command);
	}

	[Fact]
	public async Task AddAsync_ShouldAddChatMessage_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChatMessage_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddChatMessage_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishChatMessageAddedNotification_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishChatMessageAddedNotification_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishChatMessageAddedNotification_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantTwoId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnInvertedResponse_WhenCommandIsValid()
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnInvertedResponse_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnInvertedResponse_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(chatMessage, command);
	}

	[Fact]
	public async Task AddAsync_ShouldAddInvertedChatMessage_WhenCommandIsValid()
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddInvertedChatMessage_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddInvertedChatMessage_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);

		// Assert
		chatMessage.ShouldSatisfyInverted(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenCommandIsValid()
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenCommandAndParticipantOneIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwo.Id, transformer).WithParticipantTwoId(ParticipantOne.Id).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishInvertedChatMessageAddedNotification_WhenCommandAndParticipantTwoIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithParticipantOneId(ParticipantTwo.Id).WithParticipantTwoId(ParticipantOne.Id, transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var chatMessage = await ServiceScope.GetChatMessageByIdAsync(response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(chatMessage);
	}
}

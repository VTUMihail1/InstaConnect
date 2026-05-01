using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;

internal class ChatMessageCommandService : IChatMessageCommandService
{
	private readonly IApplicationMapper _mapper;
	private readonly IChatCommandRepository _repository;
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly IChatMessageFactory _messageFactory;
	private readonly IChatMessageCommandRepository _messageRepository;
	private readonly IChatIncludeBuilderFactory _includeBuilderFactory;
	private readonly IChatMessageNotificationService _messageNotificationService;
	private readonly IChatMessageIncludeBuilderFactory _messageIncludeBuilderFactory;

	public ChatMessageCommandService(
		IApplicationMapper mapper,
		IChatCommandRepository repository,
		IDateTimeProvider dateTimeProvider,
		IChatMessageFactory messageFactory,
		IChatMessageCommandRepository messageRepository,
		IChatIncludeBuilderFactory includeBuilderFactory,
		IChatMessageNotificationService messageNotificationService,
		IChatMessageIncludeBuilderFactory messageIncludeBuilderFactory)
	{
		_mapper = mapper;
		_repository = repository;
		_dateTimeProvider = dateTimeProvider;
		_messageFactory = messageFactory;
		_messageRepository = messageRepository;
		_includeBuilderFactory = includeBuilderFactory;
		_messageNotificationService = messageNotificationService;
		_messageIncludeBuilderFactory = messageIncludeBuilderFactory;
	}

	public async Task<ChatMessageId> AddAsync(AddChatMessageCommand command, CancellationToken cancellationToken)
	{
		var chatInclude = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
		var chat = await _repository.GetByIdAsync(command.Id, chatInclude, cancellationToken);

		if (chat == null)
		{
			throw new ChatNotFoundException(command.Id);
		}

		var newChatMessage = _messageFactory.Create(chat.Id, chat.Id.ParticipantOneId, command.Content).AddSender(chat.ParticipantOne).AddChat(chat);
		await _messageRepository.AddAsync(newChatMessage, cancellationToken);

		await _messageNotificationService.AddedAsync(
			_mapper.Map<ChatMessageAddedNotificationRequest>(newChatMessage), cancellationToken);

		return newChatMessage.Id;
	}

	public async Task<ChatMessageId> UpdateAsync(UpdateChatMessageCommand command, CancellationToken cancellationToken)
	{
		var chatNotExists = !await _repository.ExistsByIdAsync(command.Id.Id, cancellationToken);

		if (chatNotExists)
		{
			throw new ChatNotFoundException(command.Id.Id);
		}

		var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
		var messageInclude = _messageIncludeBuilderFactory.Create().WithSender().WithChat(include).Build();
		var chatMessage = await _messageRepository.GetByIdAsync(command.Id, messageInclude, cancellationToken);

		if (chatMessage == null)
		{
			throw new ChatMessageNotFoundException(command.Id);
		}

		if (chatMessage.SenderId.IsNot(command.Id.Id.ParticipantOneId))
		{
			throw new ChatMessageForbiddenException(command.Id, command.Id.Id.ParticipantOneId);
		}

		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		chatMessage.Update(command.Content, utcNow);
		await _messageRepository.UpdateAsync(chatMessage, cancellationToken);

		await _messageNotificationService.UpdatedAsync(
			_mapper.Map<ChatMessageUpdatedNotificationRequest>(chatMessage), cancellationToken);

		return chatMessage.Id;
	}

	public async Task DeleteAsync(DeleteChatMessageCommand command, CancellationToken cancellationToken)
	{
		var chatNotExists = !await _repository.ExistsByIdAsync(command.Id.Id, cancellationToken);

		if (chatNotExists)
		{
			throw new ChatNotFoundException(command.Id.Id);
		}

		var include = _includeBuilderFactory.Create().WithParticipantOne().WithParticipantTwo().Build();
		var messageInclude = _messageIncludeBuilderFactory.Create().WithSender().WithChat(include).Build();
		var chatMessage = await _messageRepository.GetByIdAsync(command.Id, messageInclude, cancellationToken);

		if (chatMessage == null)
		{
			throw new ChatMessageNotFoundException(command.Id);
		}

		if (chatMessage.SenderId.IsNot(command.Id.Id.ParticipantOneId))
		{
			throw new ChatMessageForbiddenException(command.Id, command.Id.Id.ParticipantOneId);
		}

		await _messageRepository.DeleteAsync(chatMessage, cancellationToken);

		await _messageNotificationService.DeletedAsync(
			_mapper.Map<ChatMessageDeletedNotificationRequest>(chatMessage), cancellationToken);
	}
}

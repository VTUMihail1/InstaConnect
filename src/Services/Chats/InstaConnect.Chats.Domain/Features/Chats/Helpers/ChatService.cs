using InstaConnect.Common.Events.Abstractions;

namespace InstaConnect.Chats.Domain.Features.Chats.Helpers;
internal class ChatService : IChatService
{
    private readonly IChatFactory _chatFactory;
    private readonly IEventPublisher _eventPublisher;
    private readonly IUserRepository _userRepository;
    private readonly IChatRepository _chatRepository;
    private readonly IApplicationMapper _applicationMapper;

    public ChatService(
        IChatFactory chatFactory,
        IEventPublisher eventPublisher,
        IUserRepository userRepository,
        IChatRepository chatRepository,
        IApplicationMapper applicationMapper)
    {
        _chatFactory = chatFactory;
        _eventPublisher = eventPublisher;
        _userRepository = userRepository;
        _chatRepository = chatRepository;
        _applicationMapper = applicationMapper;
    }

    public async Task<ChatCollection> GetAllByParticipantAsync(GetAllChatsByParticipantQuery query, CancellationToken cancellationToken)
    {
        var existingParticipantOne = await _userRepository.GetByIdAsync(query.Filter.ParticipantId, cancellationToken);

        if (existingParticipantOne.IsNull())
        {
            throw new UserNotFoundException(query.Filter.ParticipantId);
        }

        var existingChatCollection = await _chatRepository.GetAllByParticipantAsync(
            query.Filter,
            query.Sorting,
            query.Pagination,
            query.Include,
            cancellationToken);

        return existingChatCollection;
    }

    public async Task<Chat> GetByIdAsync(GetChatByIdQuery query, CancellationToken cancellationToken)
    {
        var existingChat = await _chatRepository.GetByIdAsync(
            query.Id,
            query.Include,
            cancellationToken);

        if (existingChat.IsNull())
        {
            throw new ChatNotFoundException(query.Id);
        }

        return existingChat!;
    }

    public async Task<Chat> AddAsync(AddChatCommand command, CancellationToken cancellationToken)
    {
        var existingParticipantOne = await _userRepository.GetByIdAsync(command.ParticipantOneId, cancellationToken);

        if (existingParticipantOne.IsNull())
        {
            throw new UserNotFoundException(command.ParticipantOneId);
        }

        var existingParticipantTwo = await _userRepository.GetByIdAsync(command.ParticipantTwoId, cancellationToken);

        if (existingParticipantTwo.IsNull())
        {
            throw new UserNotFoundException(command.ParticipantTwoId);
        }

        var chat = _chatFactory.Create(command.ParticipantOneId, command.ParticipantTwoId);
        var existingChat = await _chatRepository.GetByIdAsync(chat.Id, cancellationToken);

        if (existingChat.IsNotNull())
        {
            throw new ChatAlreadyExistsException(chat.Id);
        }

        await _chatRepository.AddAsync(chat, cancellationToken);

        var eventRequest = _applicationMapper.Map<ChatAddedEventRequest>(chat);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);

        return chat;
    }

    public async Task DeleteAsync(DeleteChatCommand command, CancellationToken cancellationToken)
    {
        var existingChat = await _chatRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingChat.IsNull())
        {
            throw new ChatNotFoundException(command.Id);
        }

        await _chatRepository.DeleteAsync(existingChat!, cancellationToken);

        var eventRequest = _applicationMapper.Map<ChatDeletedEventRequest>(existingChat!);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);
    }
}

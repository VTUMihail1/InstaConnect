using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Extensions;
using InstaConnect.ChatLikes.Domain.Features.ChatLikes.Abstractions;
using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetById;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Exceptions;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Exceptions;

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

        var existingChatCollection = await _chatRepository.GetAllByParticipantAsync(query, cancellationToken);

        return existingChatCollection;
    }

    public async Task<Chat> GetByIdAsync(GetChatByIdQuery query, CancellationToken cancellationToken)
    {
        var existingChat = await _chatRepository.GetByIdAsync(query.ParticipantOneId, query.ParticipantTwoId, cancellationToken);

        if (existingChat.IsNull())
        {
            throw new ChatNotFoundException(query.ParticipantOneId, query.ParticipantTwoId);
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

        var existingChat = await _chatRepository.GetByIdAsync(command.ParticipantOneId, command.ParticipantTwoId, cancellationToken);

        if (existingChat.IsNotNull())
        {
            throw new ChatAlreadyExistsException(command.ParticipantOneId, command.ParticipantTwoId);
        }

        var chat = _chatFactory.Create(command.ParticipantOneId, command.ParticipantTwoId);
        _chatRepository.Add(chat);

        var eventRequest = _applicationMapper.Map<ChatAddedEventRequest>(chat);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);

        return chat;
    }

    public async Task DeleteAsync(DeleteChatCommand command, CancellationToken cancellationToken)
    {
        var existingChat = await _chatRepository.GetByIdAsync(command.ParticipantOneId, command.ParticipantTwoId, cancellationToken);

        if (existingChat.IsNull())
        {
            throw new ChatNotFoundException(command.ParticipantOneId, command.ParticipantTwoId);
        }

        _chatRepository.Delete(existingChat!);

        var eventRequest = _applicationMapper.Map<ChatDeletedEventRequest>(existingChat!);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);
    }
}

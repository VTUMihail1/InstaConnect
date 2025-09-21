using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Responses;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Models;
using InstaConnect.Posts.Infrastructure;
using InstaConnect.Messages.Infrastructure;

namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Repositories;

internal class ChatMessageRepository : IChatMessageRepository
{
    private readonly ChatsContext _chatsContext;
    private readonly IChatMessageQueryFactory _chatMessageQueryFactory;
    private readonly IApplicationMapper _applicationMapper;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IChatMessageCollectionFactory _chatMessageCollectionFactory;

    public ChatMessageRepository(
        ChatsContext chatsContext,
        IChatMessageQueryFactory chatMessageQueryFactory,
        IApplicationMapper applicationMapper,
        ISqlConnectionFactory sqlConnectionFactory,
        IChatMessageCollectionFactory chatMessageCollectionFactory)
    {
        _chatsContext = chatsContext;
        _applicationMapper = applicationMapper;
        _chatMessageQueryFactory = chatMessageQueryFactory;
        _sqlConnectionFactory = sqlConnectionFactory;
        _chatMessageCollectionFactory = chatMessageCollectionFactory;
    }

    public async Task<ChatMessageCollection> GetAllAsync(GetAllChatMessagesQuery query, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getAllQuery = _chatMessageQueryFactory.CreateGetAll(query);
        var queryEntity = await connection.ExecuteQueryAsync<ChatMessageQueryEntity>(
            getAllQuery.Sql,
            getAllQuery.Parameters,
            cancellationToken);
        var chatMessages = _applicationMapper.Map<ICollection<ChatMessage>>(queryEntity.ToList());

        var getAllTotalCountQuery = _chatMessageQueryFactory.CreateGetAllTotalCount(query.Filter);
        var chatMessagesTotalCount = await connection.ExecuteFunctionAsync<int>(getAllTotalCountQuery.Sql, getAllTotalCountQuery.Parameters, cancellationToken);

        var response = _chatMessageCollectionFactory.Create(chatMessages, chatMessagesTotalCount, query.Pagination);

        return response;
    }

    public async Task<ChatMessage?> GetByIdAsync(string participantOneId, string participantTwoId, string messageId, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByIdQuery = _chatMessageQueryFactory.CreateGetById(participantOneId, participantTwoId, messageId);
        var queryResponse = await connection.ExecuteQueryFirstAsync<ChatMessageQueryEntity>(
            getByIdQuery.Sql,
            getByIdQuery.Parameters,
            cancellationToken);
        var chatMessage = _applicationMapper.Map<ChatMessage>(queryResponse!);

        return chatMessage;
    }

    public void Add(ChatMessage chatMessage)
    {
        _chatsContext
            .ChatMessages
            .Add(chatMessage);
    }

    public void Update(ChatMessage chatMessage)
    {
        _chatsContext
            .ChatMessages
            .Update(chatMessage);
    }

    public void Delete(ChatMessage chatMessage)
    {
        _chatsContext
            .ChatMessages
            .Remove(chatMessage);
    }
}

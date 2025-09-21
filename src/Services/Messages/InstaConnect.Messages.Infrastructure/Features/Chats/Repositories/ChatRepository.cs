using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Models;
using InstaConnect.Posts.Infrastructure;
using InstaConnect.Messages.Infrastructure;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Repositories;

internal class ChatRepository : IChatRepository
{
    private readonly ChatsContext _chatsContext;
    private readonly IChatQueryFactory _chatQueryFactory;
    private readonly IApplicationMapper _applicationMapper;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IChatCollectionFactory _chatCollectionFactory;

    public ChatRepository(
        ChatsContext chatsContext,
        IChatQueryFactory chatQueryFactory,
        IApplicationMapper applicationMapper,
        ISqlConnectionFactory sqlConnectionFactory,
        IChatCollectionFactory chatCollectionFactory)
    {
        _chatsContext = chatsContext;
        _applicationMapper = applicationMapper;
        _chatQueryFactory = chatQueryFactory;
        _sqlConnectionFactory = sqlConnectionFactory;
        _chatCollectionFactory = chatCollectionFactory;
    }

    public async Task<ChatCollection> GetAllByParticipantAsync(GetAllChatsByParticipantQuery query, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getAllByParticipantQuery = _chatQueryFactory.CreateGetAllByParticipant(query);
        var queryEntity = await connection.ExecuteQueryAsync<ChatQueryEntity>(
            getAllByParticipantQuery.Sql,
            getAllByParticipantQuery.Parameters,
            cancellationToken);
        var chats = _applicationMapper.Map<ICollection<Chat>>(queryEntity.ToList());

        var getAllByParticipantTotalCountQuery = _chatQueryFactory.CreateGetAllByParticipantTotalCount(query.Filter);
        var chatsTotalCount = await connection.ExecuteFunctionAsync<int>(getAllByParticipantTotalCountQuery.Sql, getAllByParticipantTotalCountQuery.Parameters, cancellationToken);

        var response = _chatCollectionFactory.Create(chats, chatsTotalCount, query.Pagination);

        return response;
    }

    public async Task<Chat?> GetByIdAsync(string participantOneId, string participantTwoId, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByIdQuery = _chatQueryFactory.CreateGetById(participantOneId, participantTwoId);
        var queryResponse = await connection.ExecuteQueryFirstAsync<ChatQueryEntity>(
            getByIdQuery.Sql,
            getByIdQuery.Parameters,
            cancellationToken);
        var chat = _applicationMapper.Map<Chat>(queryResponse!);

        return chat;
    }

    public void Add(Chat chat)
    {
        _chatsContext
            .Chats
            .Add(chat);
    }

    public void Update(Chat chat)
    {
        _chatsContext
            .Chats
            .Update(chat);
    }

    public void Delete(Chat chat)
    {
        _chatsContext
            .Chats
            .Remove(chat);
    }
}

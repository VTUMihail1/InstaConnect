using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Application.Features.Chats.Commands.Delete;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

using Mapster;

namespace InstaConnect.Chats.Application.Features.Chats.Mappings;

public class ChatApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllChatsQueryRequest, GetAllChatsQuery>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.ParticipantOneId),
                                           new(src.ParticipantTwoName)),
                                       new(
                                           src.SortOrder,
                                           src.SortTerm),
                                       new(
                                           src.Page,
                                           src.PageSize),
                                       new(
                                           new(src.CurrentUserId))));

        config.NewConfig<ChatCollectionResponse, GetAllChatsQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<ChatCollectionQueryResponse>(config)));

        config.NewConfig<GetChatByIdQueryRequest, GetChatByIdQuery>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.ParticipantOneId),
                                           new(src.ParticipantTwoId)),
                                       new(
                                           new(src.CurrentUserId))));

        config.NewConfig<Chat, GetChatByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<ChatQueryResponse>(config)));

        config.NewConfig<AddChatCommandRequest, AddChatCommand>()
            .ConstructUsing(src => new(
                                       new(src.ParticipantOneId),
                                       new(src.ParticipantTwoId)));

        config.NewConfig<Chat, AddChatCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<ChatIdCommandResponse>(config)));

        config.NewConfig<DeleteChatCommandRequest, DeleteChatCommand>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.ParticipantOneId),
                                           new(src.ParticipantTwoId))));

        config.NewConfig<ChatId, ChatIdCommandResponse>()
            .ConstructUsing(src => new(
                src.ParticipantOneId.Id,
                src.ParticipantTwoId.Id));

        config.NewConfig<Chat, ChatQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.ParticipantOneId.Id,
                src.Id.ParticipantTwoId.Id,
                src.ParticipantOne.Adapt<UserQueryResponse>(config),
                src.ParticipantTwo.Adapt<UserQueryResponse>(config),
                src.CreatedAtUtc));

        config.NewConfig<ChatCollectionResponse, ChatCollectionQueryResponse>()
            .ConstructUsing(src => new(
                  src.ParticipantOne.Adapt<UserQueryResponse>(config),
                  src.ParticipantTwo.Adapt<UserQueryResponse>(config),
                  src.Chats.Adapt<ICollection<ChatQueryResponse>>(config),
                  src.Page,
                  src.PageSize,
                  src.TotalCount,
                  src.HasNextPage,
                  src.HasPreviousPage));
    }
}

using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Application.Features.Chats.Commands.Delete;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetAllByParticipant;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetById;
using InstaConnect.Common.Domain.Models.ValueObjects;

using Mapster;

namespace InstaConnect.Chats.Application.Features.Chats.Mappings;

public class ChatApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllChatsByParticipantQueryRequest, GetAllChatsByParticipantQuery>()
            .ConstructUsing(src => new(
                src.Filter.Adapt<ChatByParticipantFilterQuery>(),
                src.Sorting.Adapt<ChatByParticipantSortingQuery>(),
                src.Pagination.Adapt<ChatPaginationQuery>()));

        config.NewConfig<ChatCollection, GetAllChatsByParticipantQueryResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Adapt<ICollection<ChatQueryResponse>>(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetChatByIdQueryRequest, GetChatByIdQuery>()
            .ConstructUsing(src => new(src.Id.Adapt<ChatId>()));

        config.NewConfig<Chat, GetChatByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<ChatQueryResponse>()));

        config.NewConfig<AddChatCommandRequest, AddChatCommand>()
            .ConstructUsing(src => new(
                src.ParticipantOneId.Adapt<UserId>(),
                src.ParticipantTwoId.Adapt<UserId>()));

        config.NewConfig<Chat, AddChatCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<ChatIdPayload>()));

        config.NewConfig<DeleteChatCommandRequest, DeleteChatCommand>()
            .ConstructUsing(src => new(src.Id.Adapt<ChatId>()));

        config.NewConfig<ChatIdPayload, ChatId>()
            .ConstructUsing(src => new(
                src.ParticipantOneId.Adapt<UserId>(),
                src.ParticipantTwoId.Adapt<UserId>()));

        config.NewConfig<ChatId, ChatIdPayload>()
            .ConstructUsing(src => new(
                src.ParticipantOneId.Adapt<UserIdPayload>(),
                src.ParticipantTwoId.Adapt<UserIdPayload>()));

        config.NewConfig<Chat, ChatQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ChatIdPayload>(),
                src.ParticipantOne.Adapt<UserQueryResponse>(),
                src.ParticipantTwo.Adapt<UserQueryResponse>(),
                src.CreatedAtUtc));

        config.NewConfig<ChatByParticipantFilterQueryRequest, ChatByParticipantFilterQuery>()
            .ConstructUsing(src => new(
                src.ParticipantId.Adapt<UserId>(),
                src.ParticipantName.Adapt<Name>()));

        config.NewConfig<ChatByParticipantSortingQueryRequest, ChatByParticipantSortingQuery>()
            .ConstructUsing(src => new(
                src.Order,
                src.Property));

        config.NewConfig<ChatPaginationQueryRequest, ChatPaginationQuery>()
            .ConstructUsing(src => new(
                src.Page,
                src.PageSize));
    }
}

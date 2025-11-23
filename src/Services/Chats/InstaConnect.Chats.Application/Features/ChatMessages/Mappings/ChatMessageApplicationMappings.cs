using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;
using InstaConnect.Common.Domain.Models.ValueObjects;

using Mapster;

namespace InstaConnect.Chats.Application.Features.ChatMessages.Mappings;

public class ChatMessageApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllChatMessagesQueryRequest, GetAllChatMessagesQuery>()
            .ConstructUsing(src => new(
                src.Filter.Adapt<ChatMessageFilterQuery>(),
                src.Sorting.Adapt<ChatMessageSortingQuery>(),
                src.Pagination.Adapt<ChatMessagePaginationQuery>()));

        config.NewConfig<ChatMessageCollection, GetAllChatMessagesQueryResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Adapt<ICollection<ChatMessageQueryResponse>>(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetChatMessageByIdQueryRequest, GetChatMessageByIdQuery>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ChatMessageId>(),
                src.SenderId.Adapt<UserId>()));

        config.NewConfig<ChatMessage, GetChatMessageByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<ChatMessageQueryResponse>()));

        config.NewConfig<AddChatMessageCommandRequest, AddChatMessageCommand>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ChatId>(),
                src.SenderId.Adapt<UserId>(),
                src.Content));

        config.NewConfig<ChatMessage, AddChatMessageCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<ChatMessageIdPayload>()));

        config.NewConfig<UpdateChatMessageCommandRequest, UpdateChatMessageCommand>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ChatMessageId>(),
                src.SenderId.Adapt<UserId>(),
                src.Content));

        config.NewConfig<ChatMessage, UpdateChatMessageCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<ChatMessageIdPayload>()));

        config.NewConfig<DeleteChatMessageCommandRequest, DeleteChatMessageCommand>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ChatMessageId>(),
                src.SenderId.Adapt<UserId>()));

        config.NewConfig<ChatMessageIdPayload, ChatMessageId>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ChatId>(),
                src.MessageId));

        config.NewConfig<ChatMessageId, ChatMessageIdPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ChatIdPayload>(),
                src.MessageId));

        config.NewConfig<ChatMessage, ChatMessageQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ChatMessageIdPayload>(),
                src.Content,
                src.Sender.Adapt<UserQueryResponse>(),
                src.CreatedAtUtc,
                src.UpdatedAtUtc));

        config.NewConfig<ChatMessageFilterQueryRequest, ChatMessageFilterQuery>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ChatId>(),
                src.SenderId.Adapt<UserId>()));

        config.NewConfig<ChatMessageSortingQueryRequest, ChatMessageSortingQuery>()
            .ConstructUsing(src => new(
                src.Order,
                src.Property));

        config.NewConfig<ChatPaginationQueryRequest, ChatPaginationQuery>()
            .ConstructUsing(src => new(
                src.Page,
                src.PageSize));
    }
}

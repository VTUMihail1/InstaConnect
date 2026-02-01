using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;

using Mapster;

namespace InstaConnect.Chats.Application.Features.ChatMessages.Mappings;

public class ChatMessageApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllChatMessagesQueryRequest, GetAllChatMessagesQuery>()
            .ConstructUsing(src => new(
                                       new(
                                           new(
                                               new(src.ParticipantOneId),
                                               new(src.ParticipantTwoId)),
                                           new(src.UserId)),
                                        new(
                                            src.SortOrder,
                                            src.SortTerm),
                                        new(
                                            src.Page,
                                            src.PageSize)));

        config.NewConfig<ChatMessageCollection, GetAllChatMessagesQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<ChatMessageCollectionQueryResponse>(config)));

        config.NewConfig<GetChatMessageByIdQueryRequest, GetChatMessageByIdQuery>()
            .ConstructUsing(src => new(
                                       new(
                                           new(
                                               new(src.ParticipantOneId),
                                               new(src.ParticipantTwoId)),
                                           src.MessageId),
                                       new(src.UserId)));

        config.NewConfig<ChatMessage, GetChatMessageByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<ChatMessageQueryResponse>(config)));

        config.NewConfig<AddChatMessageCommandRequest, AddChatMessageCommand>()
            .ConstructUsing(src => new(
                                       new(
                                               new(src.ParticipantOneId),
                                               new(src.ParticipantTwoId)),
                                       new(src.SenderId),
                                       src.Content));

        config.NewConfig<ChatMessage, AddChatMessageCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<ChatMessageIdCommandResponse>(config)));

        config.NewConfig<UpdateChatMessageCommandRequest, UpdateChatMessageCommand>()
            .ConstructUsing(src => new(
                                       new(
                                           new(
                                               new(src.ParticipantOneId),
                                               new(src.ParticipantTwoId)),
                                           src.MessageId),
                                       new(src.SenderId),
                                       src.Content));

        config.NewConfig<ChatMessage, UpdateChatMessageCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<ChatMessageIdCommandResponse>(config)));

        config.NewConfig<DeleteChatMessageCommandRequest, DeleteChatMessageCommand>()
            .ConstructUsing(src => new(
                                       new(
                                           new(
                                               new(src.ParticipantOneId),
                                               new(src.ParticipantTwoId)),
                                           src.MessageId),
                                       new(src.SenderId)));

        config.NewConfig<ChatMessageId, ChatMessageIdCommandResponse>()
            .ConstructUsing(src => new(
                src.Id.ParticipantOneId.Id,
                src.Id.ParticipantTwoId.Id,
                src.MessageId));

        config.NewConfig<ChatMessage, ChatMessageQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.Id.ParticipantOneId.Id,
                src.Id.Id.ParticipantTwoId.Id,
                src.Id.MessageId,
                src.Content,
                src.Sender.Adapt<UserQueryResponse>(config),
                src.CreatedAtUtc,
                src.UpdatedAtUtc));

        config.NewConfig<ChatMessageCollection, ChatMessageCollectionQueryResponse>()
            .ConstructUsing(pc => new(
                pc.Entities.Adapt<ICollection<ChatMessageQueryResponse>>(),
                pc.Page,
                pc.PageSize,
                pc.TotalCount,
                pc.HasNextPage,
                pc.HasPreviousPage));
    }
}

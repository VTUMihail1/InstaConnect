using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;
using InstaConnect.Chats.Application.Features.ChatMessages.Commands.Update;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetAll;
using InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;

using Mapster;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Mappings;

internal class ChatMessagePresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllChatMessagesApiRequest, GetAllChatMessagesQueryRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(
                                               new(src.ParticipantOneId),
                                               new(src.ParticipantTwoId)),
                                           new(src.SenderId)),
                                       new(src.SortOrder, src.SortProperty),
                                       new(src.Page, src.PageSize)));

        config.NewConfig<GetAllChatMessagesQueryResponse, GetAllChatMessagesApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Adapt<ICollection<ChatMessageApiResponse>>(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetChatMessageByIdApiRequest, GetChatMessageByIdQueryRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(
                                               new(src.ParticipantOneId),
                                               new(src.ParticipantTwoId)),
                                           src.MessageId),
                                       new(src.SenderId)));

        config.NewConfig<GetChatMessageByIdQueryResponse, GetChatMessageByIdApiResponse>()
            .ConstructUsing(src => new(src.Data.Adapt<ChatMessageApiResponse>()));

        config.NewConfig<AddChatMessageApiRequest, AddChatMessageCommandRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.ParticipantOneId),
                                           new(src.ParticipantTwoId)),
                                       new(src.SenderId),
                                   src.Body.Content));

        config.NewConfig<AddChatMessageCommandResponse, AddChatMessageApiResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<ChatMessageIdApiPayload>()));

        config.NewConfig<UpdateChatMessageApiRequest, UpdateChatMessageCommandRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(
                                               new(src.ParticipantOneId),
                                               new(src.ParticipantTwoId)),
                                           src.MessageId),
                                       new(src.SenderId),
                                       src.Body.Content));

        config.NewConfig<UpdateChatMessageCommandResponse, UpdateChatMessageApiResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<ChatMessageIdApiPayload>()));

        config.NewConfig<DeleteChatMessageApiRequest, DeleteChatMessageCommandRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(
                                               new(src.ParticipantOneId),
                                               new(src.ParticipantTwoId)),
                                           src.MessageId),
                                       new(src.SenderId)));

        config.NewConfig<ChatMessageIdPayload, ChatMessageIdApiPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ChatIdApiPayload>(),
                src.MessageId));

        config.NewConfig<ChatMessageIdApiPayload, ChatMessageIdPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ChatIdPayload>(),
                src.MessageId));

        config.NewConfig<ChatMessageQueryResponse, ChatMessageApiResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ChatMessageIdApiPayload>(),
                src.Content,
                src.Sender.Adapt<UserApiResponse>(),
                src.CreatedAtUtc,
                src.UpdatedAtUtc));
    }
}

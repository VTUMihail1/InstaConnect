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
                new(src.Filter.ParticipantOneId, src.Filter.ParticipantTwoId),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<ChatMessageCollection, GetAllChatMessagesQueryResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new ChatMessageQueryResponse(
                                      p.ParticipantOneId,
                                      p.ParticipantTwoId,
                                      p.MessageId,
                                      p.Content,
                                      new(
                                          p.SenderId,
                                          p.Sender!.Name,
                                          p.Sender.ProfileImage)))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetChatMessageByIdQueryRequest, GetChatMessageByIdQuery>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId, src.MessageId));

        config.NewConfig<ChatMessage, GetChatMessageByIdQueryResponse>()
            .ConstructUsing(src => new(
                new(src.ParticipantOneId,
                    src.ParticipantTwoId,
                    src.MessageId,
                    src.Content,
                    new(
                        src.SenderId,
                        src.Sender!.Name,
                        src.Sender.ProfileImage))));

        config.NewConfig<AddChatMessageCommandRequest, AddChatMessageCommand>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId, src.Content));

        config.NewConfig<ChatMessage, AddChatMessageCommandResponse>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId, src.MessageId, src.Content, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<UpdateChatMessageCommandRequest, UpdateChatMessageCommand>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId, src.MessageId, src.Content));

        config.NewConfig<ChatMessage, UpdateChatMessageCommandResponse>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId, src.MessageId, src.Content, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeleteChatMessageCommandRequest, DeleteChatMessageCommand>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId, src.MessageId));
    }
}

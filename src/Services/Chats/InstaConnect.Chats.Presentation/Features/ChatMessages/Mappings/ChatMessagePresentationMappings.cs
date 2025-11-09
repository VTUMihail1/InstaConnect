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
                new(src.Filter.ParticipantOneId, src.Filter.ParticipantTwoId),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<GetAllChatMessagesQueryResponse, GetAllChatMessagesApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new ChatMessageApiResponse(
                                      p.ParticipantOneId,
                                      p.ParticipantTwoId,
                                      p.MessageId,
                                      p.Content,
                                      new(p.Sender.Id,
                                          p.Sender.Name,
                                          p.Sender.ProfileImage)))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetChatMessageByIdApiRequest, GetChatMessageByIdQueryRequest>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId, src.MessageId));

        config.NewConfig<GetChatMessageByIdQueryResponse, GetChatMessageByIdApiResponse>()
            .ConstructUsing(src => new(
                new(src.Data.ParticipantOneId,
                                      src.Data.ParticipantTwoId,
                                      src.Data.MessageId,
                                      src.Data.Content,
                                      new(src.Data.Sender.Id,
                                          src.Data.Sender.Name,
                                          src.Data.Sender.ProfileImage))));

        config.NewConfig<AddChatMessageApiRequest, AddChatMessageCommandRequest>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId, src.Body.Content));

        config.NewConfig<AddChatMessageCommandResponse, AddChatMessageApiResponse>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId, src.MessageId, src.Content, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<UpdateChatMessageApiRequest, UpdateChatMessageCommandRequest>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId, src.MessageId, src.Body.Content));

        config.NewConfig<UpdateChatMessageCommandResponse, UpdateChatMessageApiResponse>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId, src.MessageId, src.Content, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeleteChatMessageApiRequest, DeleteChatMessageCommandRequest>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId, src.MessageId));
    }
}

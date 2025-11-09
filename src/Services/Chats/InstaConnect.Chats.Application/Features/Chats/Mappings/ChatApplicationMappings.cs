using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Application.Features.Chats.Commands.Delete;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetAllByParticipant;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

using Mapster;

namespace InstaConnect.Chats.Application.Features.Chats.Mappings;

public class ChatApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllChatsByParticipantQueryRequest, GetAllChatsByParticipantQuery>()
            .ConstructUsing(src => new(
                new(src.Filter.ParticipantId, src.Filter.ParticipantName),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<ChatCollection, GetAllChatsByParticipantQueryResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new ChatQueryResponse(
                                      new(
                                          p.ParticipantOneId,
                                          p.ParticipantOne!.Name,
                                          p.ParticipantOne.ProfileImage),
                                      new(
                                          p.ParticipantTwoId,
                                          p.ParticipantTwo!.Name,
                                          p.ParticipantTwo.ProfileImage)))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetChatByIdQueryRequest, GetChatByIdQuery>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId));

        config.NewConfig<Chat, GetChatByIdQueryResponse>()
            .ConstructUsing(src => new(
                new(new(
                        src.ParticipantOneId,
                        src.ParticipantOne!.Name,
                        src.ParticipantOne.ProfileImage),
                    new(
                        src.ParticipantTwoId,
                        src.ParticipantTwo!.Name,
                        src.ParticipantTwo.ProfileImage))));

        config.NewConfig<AddChatCommandRequest, AddChatCommand>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId));

        config.NewConfig<Chat, AddChatCommandResponse>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeleteChatCommandRequest, DeleteChatCommand>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId));
    }
}

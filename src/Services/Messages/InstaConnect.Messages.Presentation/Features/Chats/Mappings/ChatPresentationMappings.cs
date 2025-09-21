using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Application.Features.Chats.Commands.Delete;
using InstaConnect.Chats.Application.Features.Chats.Models;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetById;
using InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

using Mapster;

namespace InstaConnect.Chats.Presentation.Features.Chats.Mappings;

internal class ChatPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllChatsByParticipantApiRequest, GetAllChatsByParticipantQueryRequest>()
            .ConstructUsing(src => new(
                new(src.Filter.ParticipantId, src.Filter.ParticipantName),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<GetAllChatsByParticipantQueryResponse, GetAllChatsByParticipantApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new ChatApiResponse(
                                      new(
                                          p.ParticipantOne.Id,
                                          p.ParticipantOne.Name,
                                          p.ParticipantOne.ProfileImage),
                                      new(
                                          p.ParticipantTwo.Id,
                                          p.ParticipantTwo.Name,
                                          p.ParticipantTwo.ProfileImage)))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetChatByIdApiRequest, GetChatByIdQueryRequest>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId));

        config.NewConfig<GetChatByIdQueryResponse, GetChatByIdApiResponse>()
            .ConstructUsing(src => new(
                new(new(
                        src.Data.ParticipantOne.Id,
                        src.Data.ParticipantOne.Name,
                        src.Data.ParticipantOne.ProfileImage),
                    new(
                        src.Data.ParticipantTwo.Id,
                        src.Data.ParticipantTwo.Name,
                        src.Data.ParticipantTwo.ProfileImage))));

        config.NewConfig<AddChatApiRequest, AddChatCommandRequest>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId));

        config.NewConfig<AddChatCommandResponse, AddChatApiResponse>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeleteChatApiRequest, DeleteChatCommandRequest>()
            .ConstructUsing(src => new(src.ParticipantOneId, src.ParticipantTwoId));
    }
}

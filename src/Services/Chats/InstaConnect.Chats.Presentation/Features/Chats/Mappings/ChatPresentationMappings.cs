using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Application.Features.Chats.Commands.Delete;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetAllByParticipant;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

using Mapster;

namespace InstaConnect.Chats.Presentation.Features.Chats.Mappings;

internal class ChatPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllChatsByParticipantApiRequest, GetAllChatsByParticipantQueryRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.ParticipantId),
                                           new(src.ParticipantName)),
                                       new(
                                           src.SortOrder,
                                           src.SortProperty),
                                       new(
                                           src.Page,
                                           src.PageSize)));

        config.NewConfig<GetAllChatsByParticipantQueryResponse, GetAllChatsByParticipantApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Adapt<ICollection<ChatApiResponse>>(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetChatByIdApiRequest, GetChatByIdQueryRequest>()
            .ConstructUsing(src => new(
                new(
                    new(src.ParticipantOneId),
                    new(src.ParticipantTwoId))));

        config.NewConfig<GetChatByIdQueryResponse, GetChatByIdApiResponse>()
            .ConstructUsing(src => new(src.Data.Adapt<ChatApiResponse>()));

        config.NewConfig<AddChatApiRequest, AddChatCommandRequest>()
            .ConstructUsing(src => new(
                                       new(src.ParticipantOneId),
                                       new(src.ParticipantTwoId)));

        config.NewConfig<AddChatCommandResponse, AddChatApiResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<ChatIdApiPayload>()));

        config.NewConfig<DeleteChatApiRequest, DeleteChatCommandRequest>()
            .ConstructUsing(src => new(
                new(
                    new(src.ParticipantOneId),
                    new(src.ParticipantTwoId))));

        config.NewConfig<ChatIdPayload, ChatIdApiPayload>()
            .ConstructUsing(src => new(
                src.ParticipantOneId.Adapt<UserIdApiPayload>(),
                src.ParticipantTwoId.Adapt<UserIdApiPayload>()));

        config.NewConfig<ChatIdApiPayload, ChatIdPayload>()
            .ConstructUsing(src => new(
                src.ParticipantOneId.Adapt<UserIdPayload>(),
                src.ParticipantTwoId.Adapt<UserIdPayload>()));

        config.NewConfig<ChatQueryResponse, ChatApiResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<ChatIdApiPayload>(),
                src.ParticipantOne.Adapt<UserApiResponse>(),
                src.ParticipantTwo.Adapt<UserApiResponse>(),
                src.CreatedAtUtc));

    }
}

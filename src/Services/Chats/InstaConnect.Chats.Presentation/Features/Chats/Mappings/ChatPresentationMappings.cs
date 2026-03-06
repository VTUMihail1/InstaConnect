using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Application.Features.Chats.Commands.Delete;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetAll;
using InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

using Mapster;

namespace InstaConnect.Chats.Presentation.Features.Chats.Mappings;

internal class ChatPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllChatsApiRequest, GetAllChatsQueryRequest>()
            .ConstructUsing(src => new(
                src.ParticipantOneId,
                src.ParticipantTwoName,
                src.CurrentUserId,
                src.SortOrder,
                src.SortTerm,
                src.Page,
                src.PageSize));

        config.NewConfig<GetAllChatsQueryResponse, GetAllChatsApiResponse>()
            .ConstructUsing(src => new(src.ChatCollection.Adapt<ChatCollectionApiResponse>(config)!));

        config.NewConfig<GetChatByIdApiRequest, GetChatByIdQueryRequest>()
            .ConstructUsing(src => new(
                src.ParticipantOneId,
                src.ParticipantTwoId,
                src.CurrentUserId));

        config.NewConfig<GetChatByIdQueryResponse, GetChatByIdApiResponse>()
            .ConstructUsing(src => new(src.Chat.Adapt<ChatApiResponse>(config)!));

        config.NewConfig<AddChatApiRequest, AddChatCommandRequest>()
            .ConstructUsing(src => new(
                                       new(src.ParticipantOneId),
                                       new(src.ParticipantTwoId)));

        config.NewConfig<AddChatCommandResponse, AddChatApiResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<ChatIdApiResponse>(config)!));

        config.NewConfig<DeleteChatApiRequest, DeleteChatCommandRequest>()
            .ConstructUsing(src => new(
                src.ParticipantOneId,
                src.ParticipantTwoId));

        config.NewConfig<ChatIdCommandResponse, ChatIdApiResponse>()
            .ConstructUsing(src => new(
                src.ParticipantOneId,
                src.ParticipantTwoId));

        config.NewConfig<ChatQueryResponse, ChatApiResponse>()
            .ConstructUsing(src => new(
                src.ParticipantOneId,
                src.ParticipantTwoId,
                src.ParticipantOne.Adapt<UserApiResponse>(config),
                src.ParticipantTwo.Adapt<UserApiResponse>(config),
                src.CreatedAtUtc));

        config.NewConfig<ChatCollectionQueryResponse, ChatCollectionApiResponse>()
            .ConstructUsing(src => new(
                  src.ParticipantOne.Adapt<UserApiResponse>(config),
                  src.ParticipantTwo.Adapt<UserApiResponse>(config),
                  src.Chats.Adapt<ICollection<ChatApiResponse>>(config)!,
                  src.Page,
                  src.PageSize,
                  src.TotalCount,
                  src.HasNextPage,
                  src.HasPreviousPage));

    }
}

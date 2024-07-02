using AutoMapper;
using InstaConnect.Messages.Business.Write.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Write.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Business.Write.Models;
using InstaConnect.Messages.Data.Write.Models.Entities;
using InstaConnect.Messages.Data.Write.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Contracts.Users;

namespace InstaConnect.Messages.Business.Write.Profiles;

public class MessagesBusinessProfile : Profile
{
    public MessagesBusinessProfile()
    {
        // Messages

        CreateMap<UserDeletedEvent, MessageFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new MessageFilteredCollectionQuery
                 {
                     Expression = p => p.SenderId == src.Id
                 });

        CreateMap<AddMessageCommand, GetUserByIdRequest>();

        CreateMap<AddMessageCommand, MessageGetUserByIdModel>()
            .ForMember(dest => dest.GetUserBySenderIdRequest.Id, opt => opt.MapFrom(src => src.CurrentUserId))
            .ForMember(dest => dest.GetUserByReceiverIdRequest.Id, opt => opt.MapFrom(src => src.ReceiverId));

        CreateMap<AddMessageCommand, GetUserByIdRequest>();

        CreateMap<GetUserByIdResponse, Message>()
            .ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.Id));

        CreateMap<AddMessageCommand, Message>()
            .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<UpdateMessageCommand, Message>();

        CreateMap<Message, MessageCreatedEvent>();

        CreateMap<Message, MessageUpdatedEvent>();

        CreateMap<Message, MessageDeletedEvent>();
    }
}

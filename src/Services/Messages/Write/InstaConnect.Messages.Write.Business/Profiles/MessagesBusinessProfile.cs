using AutoMapper;
using InstaConnect.Messages.Write.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Write.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Write.Business.Models;
using InstaConnect.Messages.Write.Data.Models.Entities;
using InstaConnect.Messages.Write.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Contracts.Users;

namespace InstaConnect.Messages.Write.Business.Profiles;

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

using AutoMapper;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Messages.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Models.Users;

namespace InstaConnect.Messages.Business.Profiles;

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

        CreateMap<CurrentUserDetails, Message>()
            .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => src.Id));

        CreateMap<GetUserByIdResponse, Message>()
            .ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.Id));

        CreateMap<AddMessageCommand, Message>();

        CreateMap<UpdateMessageCommand, Message>();

        CreateMap<Message, MessageCreatedEvent>();

        CreateMap<Message, MessageUpdatedEvent>();

        CreateMap<Message, MessageDeletedEvent>();
    }
}

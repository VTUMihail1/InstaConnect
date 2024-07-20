using AutoMapper;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Commands.Messages.DeleteMessage;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Queries.Messages.GetMessageById;
using InstaConnect.Messages.Web.Models.Requests.Messages;
using InstaConnect.Messages.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Messages.Web.Profiles;

internal class MessagesWebProfile : Profile
{
    public MessagesWebProfile()
    {
        // Write Messages

        CreateMap<AddMessageRequest, AddMessageCommand>()
            .ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.AddMessageBindingModel.ReceiverId))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.AddMessageBindingModel.Content));

        CreateMap<CurrentUserModel, AddMessageCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<UpdateMessageRequest, UpdateMessageCommand>()
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.UpdateMessageBindingModel.Content));

        CreateMap<CurrentUserModel, UpdateMessageCommand>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<DeleteMessageRequest, DeleteMessageCommand>();

        CreateMap<CurrentUserModel, DeleteMessageCommand>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<MessageWriteViewModel, MessageWriteViewResponse>();

        // Read Messages

        CreateMap<GetAllFilteredMessagesRequest, GetAllFilteredMessagesQuery>();

        CreateMap<CurrentUserModel, GetAllFilteredMessagesQuery>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<CurrentUserModel, GetMessageByIdQuery>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<GetMessageByIdRequest, GetMessageByIdQuery>();

        CreateMap<MessagePaginationCollectionModel, MessagePaginationCollectionResponse>();

        CreateMap<MessageReadViewModel, MessageReadViewResponse>();
    }
}

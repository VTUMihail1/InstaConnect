using AutoMapper;
using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Web.Features.Messages.Models.Requests;
using InstaConnect.Messages.Web.Features.Messages.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Messages.Web.Features.Messages.Mappings;

internal class MessagesQueryProfile : Profile
{
    public MessagesQueryProfile()
    {
        CreateMap<(CurrentUserModel, GetAllFilteredMessagesRequest), GetAllFilteredMessagesQuery>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Item1.Id))
            .ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.Item2.ReceiverId))
            .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.Item2.ReceiverName))
            .ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.Item2.Page))
            .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.Item2.PageSize))
            .ForMember(dest => dest.SortOrder, opt => opt.MapFrom(src => src.Item2.SortOrder))
            .ForMember(dest => dest.SortPropertyName, opt => opt.MapFrom(src => src.Item2.SortPropertyName));

        CreateMap<(CurrentUserModel, GetMessageByIdRequest), GetMessageByIdQuery>()
            .ConstructUsing(src => new(
                src.Item2.Id,
                src.Item1.Id));

        CreateMap<MessagePaginationCollectionModel, MessagePaginationCollectionQueryResponse>();

        CreateMap<MessageQueryViewModel, MessageQueryViewResponse>();
    }
}

﻿using AutoMapper;
using InstaConnect.Messages.Write.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Write.Business.Commands.Messages.DeleteMessage;
using InstaConnect.Messages.Write.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Write.Business.Models;
using InstaConnect.Messages.Write.Web.Models.Requests.Messages;
using InstaConnect.Messages.Write.Web.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Messages.Write.Web.Profiles;

internal class MessagesWebProfile : Profile
{
    public MessagesWebProfile()
    {
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

        CreateMap<MessageViewModel, MessageViewResponse>();
    }
}

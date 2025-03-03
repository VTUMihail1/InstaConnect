﻿using AutoMapper;

using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

namespace InstaConnect.Posts.Application.Features.PostComments.Mappings;

public class PostCommentCommandProfile : Profile
{
    public PostCommentCommandProfile()
    {
        CreateMap<AddPostCommentCommand, PostComment>()
            .ConstructUsing(src => new(src.CurrentUserId, src.PostId, src.Content));

        CreateMap<UpdatePostCommentCommand, PostComment>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<PostComment, PostCommentCommandViewModel>();
    }
}

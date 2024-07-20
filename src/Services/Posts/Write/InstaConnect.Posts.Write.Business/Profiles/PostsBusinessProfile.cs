﻿using AutoMapper;
using InstaConnect.Posts.Write.Business.Commands.PostCommentLikes.AddPostCommentLike;
using InstaConnect.Posts.Write.Business.Commands.PostComments.AddPostComment;
using InstaConnect.Posts.Write.Business.Commands.PostComments.UpdatePostComment;
using InstaConnect.Posts.Write.Business.Commands.PostLikes.AddPostLike;
using InstaConnect.Posts.Write.Business.Commands.Posts.AddPost;
using InstaConnect.Posts.Write.Business.Commands.Posts.UpdatePost;
using InstaConnect.Posts.Write.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Users;

namespace InstaConnect.Posts.Write.Business.Profiles;

public class PostsBusinessProfile : Profile
{
    public PostsBusinessProfile()
    {
        // Posts
        CreateMap<AddPostCommand, GetUserByIdRequest>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<AddPostCommand, Post>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<UpdatePostCommand, Post>();

        // Post Comments

        CreateMap<AddPostCommentCommand, GetUserByIdRequest>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<AddPostCommentCommand, PostComment>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<UpdatePostCommentCommand, PostComment>();

        // Post Likes

        CreateMap<AddPostLikeCommand, GetUserByIdRequest>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<AddPostLikeCommand, PostLike>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CurrentUserId));

        // Post Comment Likes

        CreateMap<AddPostCommentLikeCommand, GetUserByIdRequest>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<AddPostCommentLikeCommand, PostCommentLike>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CurrentUserId));
    }
}
﻿using AutoMapper;
using InstaConnect.Posts.Business.Models.Post;
using InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Queries.Posts.GetAllPosts;
using InstaConnect.Posts.Data.Models.Filters.Posts;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Posts.Business.Profiles.Posts;

public class PostQueryProfile : Profile
{
    public PostQueryProfile()
    {
        CreateMap<GetAllFilteredPostsQuery, PostFilteredCollectionReadQuery>();

        CreateMap<GetAllPostsQuery, PostCollectionReadQuery>();

        CreateMap<Post, PostQueryViewModel>()
            .ConstructUsing(src => new(
                src.Id,
                src.Title,
                src.Content,
                src.UserId,
                src.User!.UserName,
                src.User.ProfileImage));

        CreateMap<PaginationList<Post>, PostPaginationQueryViewModel>();
    }
}

﻿using AutoMapper;

using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Presentation.Features.Posts.Mappings;

internal class PostQueryProfile : Profile
{
    public PostQueryProfile()
    {
        CreateMap<GetAllPostsRequest, GetAllPostsQuery>();

        CreateMap<GetPostByIdRequest, GetPostByIdQuery>();

        CreateMap<PostQueryViewModel, PostQueryResponse>();

        CreateMap<PostPaginationQueryViewModel, PostPaginationQueryResponse>();
    }
}

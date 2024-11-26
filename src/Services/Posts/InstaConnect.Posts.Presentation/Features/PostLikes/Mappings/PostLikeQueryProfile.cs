using AutoMapper;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllPostLikes;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetPostLikeById;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Mappings;

internal class PostLikeQueryProfile : Profile
{
    public PostLikeQueryProfile()
    {
        CreateMap<GetAllPostLikesRequest, GetAllPostLikesQuery>();

        CreateMap<GetPostLikeByIdRequest, GetPostLikeByIdQuery>();

        CreateMap<PostLikeQueryViewModel, PostLikeQueryResponse>();

        CreateMap<PostLikePaginationQueryViewModel, PostLikePaginationQueryResponse>();
    }
}

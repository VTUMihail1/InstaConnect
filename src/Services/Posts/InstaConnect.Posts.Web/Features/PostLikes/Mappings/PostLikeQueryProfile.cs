using AutoMapper;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllFilteredPostLikes;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetPostLikeById;
using InstaConnect.Posts.Web.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Web.Features.PostLikes.Models.Responses;

namespace InstaConnect.Posts.Web.Features.PostLikes.Mappings;

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

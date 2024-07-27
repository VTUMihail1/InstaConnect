using AutoMapper;
using InstaConnect.Posts.Business.Models.PostComment;
using InstaConnect.Posts.Business.Models.PostLike;
using InstaConnect.Posts.Business.Queries.PostLikes.GetAllFilteredPostLikes;
using InstaConnect.Posts.Business.Queries.PostLikes.GetAllPostLikes;
using InstaConnect.Posts.Business.Queries.PostLikes.GetPostLikeById;
using InstaConnect.Posts.Read.Web.Models.Requests.PostLike;
using InstaConnect.Posts.Read.Web.Models.Responses;

namespace InstaConnect.Posts.Web.Profiles.PostLikes;

internal class PostLikeQueryProfile : Profile
{
    public PostLikeQueryProfile()
    {
        CreateMap<GetAllPostLikesRequest, GetAllPostLikesQuery>();

        CreateMap<GetAllFilteredPostLikesRequest, GetAllFilteredPostLikesQuery>();

        CreateMap<GetPostLikeByIdRequest, GetPostLikeByIdQuery>();

        CreateMap<PostLikeQueryViewModel, PostLikeQueryResponse>();

        CreateMap<PostLikePaginationQueryViewModel, PostLikePaginationQueryResponse>();
    }
}

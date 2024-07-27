using AutoMapper;
using InstaConnect.Posts.Business.Models.PostCommentLike;
using InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;
using InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllPostCommentLikes;
using InstaConnect.Posts.Business.Queries.PostCommentLikes.GetPostCommentLikeById;
using InstaConnect.Posts.Read.Web.Models.Requests.PostCommentLike;
using InstaConnect.Posts.Web.Models.Responses.PostCommentLikes;

namespace InstaConnect.Posts.Web.Profiles.PostCommentLikes;

internal class PostCommentLikeQueryProfile : Profile
{
    public PostCommentLikeQueryProfile()
    {
        CreateMap<GetAllPostCommentLikesRequest, GetAllPostCommentLikesQuery>();

        CreateMap<GetAllFilteredPostCommentLikesRequest, GetAllFilteredPostCommentLikesQuery>();

        CreateMap<GetPostCommentLikeByIdRequest, GetPostCommentLikeByIdQuery>();

        CreateMap<PostCommentLikeQueryViewModel, PostCommentLikeQueryResponse>();

        CreateMap<PostCommentLikePaginationQueryViewModel, PostCommentLikePaginationQueryResponse>();
    }
}

using AutoMapper;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetAllFilteredPostCommentLikes;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetPostCommentLikeById;
using InstaConnect.Posts.Web.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Web.Features.PostCommentLikes.Models.Responses;

namespace InstaConnect.Posts.Web.Features.PostCommentLikes.Mappings;

internal class PostCommentLikeQueryProfile : Profile
{
    public PostCommentLikeQueryProfile()
    {
        CreateMap<GetAllPostCommentLikesRequest, GetAllPostCommentLikesQuery>();

        CreateMap<GetPostCommentLikeByIdRequest, GetPostCommentLikeByIdQuery>();

        CreateMap<PostCommentLikeQueryViewModel, PostCommentLikeQueryResponse>();

        CreateMap<PostCommentLikePaginationQueryViewModel, PostCommentLikePaginationQueryResponse>();
    }
}

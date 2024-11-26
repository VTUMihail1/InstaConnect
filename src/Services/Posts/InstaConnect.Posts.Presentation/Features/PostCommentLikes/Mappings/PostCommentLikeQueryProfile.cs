using AutoMapper;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetPostCommentLikeById;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Mappings;

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

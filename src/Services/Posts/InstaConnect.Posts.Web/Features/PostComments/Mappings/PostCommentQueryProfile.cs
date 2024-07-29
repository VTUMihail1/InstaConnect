using AutoMapper;
using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllFilteredPostComments;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllPostComments;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetPostCommentById;
using InstaConnect.Posts.Web.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Web.Features.PostComments.Models.Responses;

namespace InstaConnect.Posts.Web.Features.PostComments.Mappings;

internal class PostCommentQueryProfile : Profile
{
    public PostCommentQueryProfile()
    {
        CreateMap<GetAllPostCommentsRequest, GetAllPostCommentsQuery>();

        CreateMap<GetAllFilteredPostCommentsRequest, GetAllFilteredPostCommentsQuery>();

        CreateMap<GetPostCommentByIdRequest, GetPostCommentByIdQuery>();

        CreateMap<PostCommentQueryViewModel, PostCommentQueryResponse>();

        CreateMap<PostCommentPaginationQueryViewModel, PostCommentPaginationQueryResponse>();

    }
}

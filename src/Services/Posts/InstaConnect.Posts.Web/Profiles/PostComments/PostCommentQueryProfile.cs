using AutoMapper;
using InstaConnect.Posts.Business.Models.PostComment;
using InstaConnect.Posts.Business.Queries.PostComments.GetAllFilteredPostComments;
using InstaConnect.Posts.Business.Queries.PostComments.GetAllPostComments;
using InstaConnect.Posts.Business.Queries.PostComments.GetPostCommentById;
using InstaConnect.Posts.Read.Web.Models.Requests.PostComment;
using InstaConnect.Posts.Web.Models.Responses.PostComments;

namespace InstaConnect.Posts.Web.Profiles.PostComments;

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

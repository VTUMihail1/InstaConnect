using AutoMapper;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllPostComments;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetPostCommentById;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Mappings;

internal class PostCommentQueryProfile : Profile
{
    public PostCommentQueryProfile()
    {
        CreateMap<GetAllPostCommentsRequest, GetAllPostCommentsQuery>();

        CreateMap<GetPostCommentByIdRequest, GetPostCommentByIdQuery>();

        CreateMap<PostCommentQueryViewModel, PostCommentQueryResponse>();

        CreateMap<PostCommentPaginationQueryViewModel, PostCommentPaginationQueryResponse>();

    }
}

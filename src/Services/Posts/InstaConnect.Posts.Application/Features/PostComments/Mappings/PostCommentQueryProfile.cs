using AutoMapper;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;

namespace InstaConnect.Posts.Application.Features.PostComments.Mappings;

public class PostCommentQueryProfile : Profile
{
    public PostCommentQueryProfile()
    {
        CreateMap<GetAllPostCommentsQuery, PostCommentCollectionReadQuery>();

        CreateMap<PostComment, PostCommentQueryViewModel>()
            .ConstructUsing(src => new(
                src.Id,
                src.Content,
                src.PostId,
                src.UserId,
                src.User!.UserName,
                src.User.ProfileImage));

        CreateMap<PaginationList<PostComment>, PostCommentPaginationQueryViewModel>();
    }
}

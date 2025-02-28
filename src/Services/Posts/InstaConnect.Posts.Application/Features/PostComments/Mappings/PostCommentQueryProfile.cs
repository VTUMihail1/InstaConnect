using AutoMapper;

using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;

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

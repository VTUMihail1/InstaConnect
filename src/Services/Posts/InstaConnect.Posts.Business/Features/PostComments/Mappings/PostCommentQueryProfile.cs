using AutoMapper;
using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllFilteredPostComments;
using InstaConnect.Posts.Business.Features.PostComments.Queries.GetAllPostComments;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostComments.Models.Filters;
using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Posts.Business.Features.PostComments.Mappings;

public class PostCommentQueryProfile : Profile
{
    public PostCommentQueryProfile()
    {
        CreateMap<GetAllFilteredPostCommentsQuery, PostCommentFilteredCollectionReadQuery>();

        CreateMap<GetAllPostCommentsQuery, CollectionReadQuery>();

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

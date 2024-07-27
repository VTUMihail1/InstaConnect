using AutoMapper;
using InstaConnect.Posts.Business.Models.PostComment;
using InstaConnect.Posts.Business.Models.PostLike;
using InstaConnect.Posts.Business.Queries.PostComments.GetAllFilteredPostComments;
using InstaConnect.Posts.Business.Queries.PostComments.GetAllPostComments;
using InstaConnect.Posts.Data.Models.Filters.PostComments;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Posts.Business.Profiles.PostComments;

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

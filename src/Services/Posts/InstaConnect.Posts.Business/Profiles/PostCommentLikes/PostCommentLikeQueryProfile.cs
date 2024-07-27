using AutoMapper;
using InstaConnect.Posts.Business.Models.PostCommentLike;
using InstaConnect.Posts.Business.Models.PostLike;
using InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;
using InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllPostCommentLikes;
using InstaConnect.Posts.Data.Models.Filters.PostCommentLikes;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Posts.Business.Profiles.PostCommentLikes;

public class PostCommentLikeQueryProfile : Profile
{
    public PostCommentLikeQueryProfile()
    {
        CreateMap<GetAllFilteredPostCommentLikesQuery, PostCommentLikeFilteredCollectionReadQuery>();

        CreateMap<GetAllPostCommentLikesQuery, CollectionReadQuery>();

        CreateMap<PostCommentLike, PostCommentLikeQueryViewModel>()
            .ConstructUsing(src => new(
                src.Id,
                src.PostCommentId,
                src.UserId,
                src.User!.UserName,
                src.User.ProfileImage));

        CreateMap<PaginationList<PostCommentLike>, PostCommentLikePaginationQueryViewModel>();
    }
}

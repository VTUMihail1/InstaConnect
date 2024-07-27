using AutoMapper;
using InstaConnect.Posts.Business.Models.Post;
using InstaConnect.Posts.Business.Models.PostLike;
using InstaConnect.Posts.Business.Queries.PostLikes.GetAllFilteredPostLikes;
using InstaConnect.Posts.Business.Queries.PostLikes.GetAllPostLikes;
using InstaConnect.Posts.Data.Models.Filters.PostLikes;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Posts.Business.Profiles.PostLikes;

public class PostLikeQueryProfile : Profile
{
    public PostLikeQueryProfile()
    {
        CreateMap<GetAllFilteredPostLikesQuery, PostLikeFilteredCollectionReadQuery>();

        CreateMap<GetAllPostLikesQuery, CollectionReadQuery>();

        CreateMap<PostLike, PostLikeQueryViewModel>()
            .ConstructUsing(src => new(
                src.Id,
                src.PostId,
                src.UserId,
                src.User!.UserName,
                src.User.ProfileImage));

        CreateMap<PaginationList<PostLike>, PostLikePaginationQueryViewModel>();
    }
}

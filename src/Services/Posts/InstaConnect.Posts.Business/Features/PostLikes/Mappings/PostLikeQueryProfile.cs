using AutoMapper;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllFilteredPostLikes;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Posts.Business.Features.PostLikes.Mappings;

public class PostLikeQueryProfile : Profile
{
    public PostLikeQueryProfile()
    {
        CreateMap<GetAllPostLikesQuery, PostLikeFilteredCollectionReadQuery>();

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

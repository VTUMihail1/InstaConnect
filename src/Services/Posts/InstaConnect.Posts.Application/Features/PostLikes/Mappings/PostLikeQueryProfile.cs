using AutoMapper;

using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;

namespace InstaConnect.Posts.Application.Features.PostLikes.Mappings;

public class PostLikeQueryProfile : Profile
{
    public PostLikeQueryProfile()
    {
        CreateMap<GetAllPostLikesQuery, PostLikeCollectionReadQuery>();

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

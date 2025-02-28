using AutoMapper;

using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;

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

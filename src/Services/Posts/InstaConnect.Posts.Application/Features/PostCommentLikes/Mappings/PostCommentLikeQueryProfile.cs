using AutoMapper;

using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Mappings;

public class PostCommentLikeQueryProfile : Profile
{
    public PostCommentLikeQueryProfile()
    {
        CreateMap<GetAllPostCommentLikesQuery, PostCommentLikeCollectionReadQuery>();

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

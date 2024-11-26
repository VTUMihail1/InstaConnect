using AutoMapper;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;

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

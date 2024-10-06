using AutoMapper;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Mappings;

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

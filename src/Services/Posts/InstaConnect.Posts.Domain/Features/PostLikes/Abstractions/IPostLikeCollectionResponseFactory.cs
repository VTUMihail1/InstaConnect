using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
internal interface IPostLikeCollectionResponseFactory
{
    PostLikeCollectionResponse Create(
        PostResponse? post,
        ICollection<PostLikeResponse> postLikes,
        long totalCount,
        PostLikesPaginationQuery pagination);

    PostLikeCollectionResponse CreateForUser(
        UserResponse? user,
        ICollection<PostLikeResponse> postLikes,
        long totalCount,
        PostLikesPaginationQuery pagination);
}

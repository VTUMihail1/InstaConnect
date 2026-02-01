using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;
internal interface IPostCollectionResponseFactory
{
    PostCollectionResponse Create(ICollection<PostResponse> posts, long totalCount, PostsPaginationQuery pagination);

    PostCollectionResponse Create(UserResponse user, ICollection<PostResponse> posts, long totalCount, PostsPaginationQuery pagination);
}

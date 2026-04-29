using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

internal interface IPostCollectionResponseFactory
{
	public PostCollectionResponse Create(ICollection<PostResponse> posts, long totalCount, PostsPaginationQuery pagination);

	public PostCollectionResponse CreateForUser(UserResponse user, ICollection<PostResponse> posts, long totalCount, PostsPaginationQuery pagination);
}

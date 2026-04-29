using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;

public record PostCommentCollectionResponse(
	PostResponse? Post,
	UserResponse? User,
	ICollection<PostCommentResponse> PostComments,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : IEntityCollectionResponse;

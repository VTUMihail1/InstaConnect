namespace InstaConnect.Posts.Application.Features.PostComments.Models;

public record PostCommentCollectionQueryResponse(
	PostQueryResponse? Post,
	UserQueryResponse? User,
	ICollection<PostCommentQueryResponse> PostComments,
	int Page,
	int PageSize,
	long TotalCount,
	bool HasNextPage,
	bool HasPreviousPage) : ICollectionQueryResponse;

using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikesSortingQuery(
	CommonSortOrder Order,
	PostCommentLikesSortTerm Term) : ISortingQuery<PostCommentLikesSortTerm>;

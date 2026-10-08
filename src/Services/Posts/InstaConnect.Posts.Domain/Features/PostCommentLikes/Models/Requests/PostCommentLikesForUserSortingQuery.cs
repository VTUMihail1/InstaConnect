using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikesForUserSortingQuery(
	CommonSortOrder Order,
	PostCommentLikesForUserSortTerm Term) : ISortingQuery<PostCommentLikesForUserSortTerm>;

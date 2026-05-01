using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Presentation.Features.Controllers.Utilities;
using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record GetAllPostLikesForUserApiRequest(
	[FromRoute] string UserId,
	[UserIdFromClaim] string CurrentUserId,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] PostLikesForUserSortTerm SortTerm = PostLikeDefaultValues.SortTermForUser,
	[FromQuery] int Page = PostLikeDefaultValues.Page,
	[FromQuery] int PageSize = PostLikeDefaultValues.PageSize) : ISortableApiRequest<PostLikesForUserSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;

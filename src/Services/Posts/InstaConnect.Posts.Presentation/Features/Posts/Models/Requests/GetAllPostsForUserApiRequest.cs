using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Presentation.Features.Controllers.Utilities;
using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record GetAllPostsForUserApiRequest(
	[FromRoute] string UserId,
	[UserIdFromClaim] string CurrentUserId,
	[FromQuery] string Title = PostDefaultValues.Title,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] PostsForUserSortTerm SortTerm = PostDefaultValues.SortTermForUser,
	[FromQuery] int Page = PostDefaultValues.Page,
	[FromQuery] int PageSize = PostDefaultValues.PageSize) : ISortableApiRequest<PostsForUserSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;

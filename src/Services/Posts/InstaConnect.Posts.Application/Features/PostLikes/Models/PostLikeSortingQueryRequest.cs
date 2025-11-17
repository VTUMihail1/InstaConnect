using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.PostLikes.Models;

public record PostLikeSortingQueryRequest(
    CommonSortOrder Order,
    PostLikeSortProperty Property);

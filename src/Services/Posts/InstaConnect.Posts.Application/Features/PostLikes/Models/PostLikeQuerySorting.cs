using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.PostLikes.Models;

public record PostLikeQuerySorting(
    CommonSortOrder Order,
    PostLikeSortProperty Property);

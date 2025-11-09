using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.PostLikes.Models;

public record PostLikeQuerySorting(
    SortOrder Order,
    PostLikeSortProperty Property);

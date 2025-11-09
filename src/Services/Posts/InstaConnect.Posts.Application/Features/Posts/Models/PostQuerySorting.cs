using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostQuerySorting(
    SortOrder Order,
    PostSortProperty Property);

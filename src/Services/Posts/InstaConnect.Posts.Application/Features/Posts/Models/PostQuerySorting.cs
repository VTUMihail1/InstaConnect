using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Posts.Domain.Features.Posts.Models;

public record PostQuerySorting(
    SortOrder Order,
    PostSortProperty Property);

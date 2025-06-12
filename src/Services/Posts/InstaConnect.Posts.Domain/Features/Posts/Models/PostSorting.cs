using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Posts.Domain.Features.Posts.Models;

public record PostSorting(
    SortOrder Order,
    PostSortProperty Property);

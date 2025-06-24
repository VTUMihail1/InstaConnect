using InstaConnect.Common.Models.Enums;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Models;

public record PostQuerySorting(
    SortOrder Order,
    PostSortProperty Property);

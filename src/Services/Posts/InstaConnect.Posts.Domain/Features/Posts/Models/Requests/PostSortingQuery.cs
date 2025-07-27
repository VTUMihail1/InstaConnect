using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostSortingQuery(
    SortOrder Order,
    PostSortProperty Property);

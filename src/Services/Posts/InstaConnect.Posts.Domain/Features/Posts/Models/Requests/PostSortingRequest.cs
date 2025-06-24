using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostSortingRequest(
    SortOrder Order,
    PostSortProperty Property);

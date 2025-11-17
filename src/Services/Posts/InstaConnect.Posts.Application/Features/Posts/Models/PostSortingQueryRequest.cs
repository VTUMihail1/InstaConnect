using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostSortingQueryRequest(
    CommonSortOrder Order,
    PostSortProperty Property);

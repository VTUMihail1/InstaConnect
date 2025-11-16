using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostQuerySorting(
    CommonSortOrder Order,
    PostSortProperty Property);

using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record PostSortingQuery(
    CommonSortOrder Order,
    PostSortProperty Property);

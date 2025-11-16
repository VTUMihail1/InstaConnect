using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record PostLikeSortingQuery(
    CommonSortOrder Order,
    PostLikeSortProperty Property);

using InstaConnect.Common.Models.Enums;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

public record PostLikeSortingQuery(
    SortOrder Order,
    PostLikeSortProperty Property);

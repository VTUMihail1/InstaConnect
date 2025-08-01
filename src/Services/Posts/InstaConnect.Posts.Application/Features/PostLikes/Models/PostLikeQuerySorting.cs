using InstaConnect.Common.Models.Enums;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models;

public record PostLikeQuerySorting(
    SortOrder Order,
    PostLikeSortProperty Property);

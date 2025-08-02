using InstaConnect.Common.Models.Enums;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

public record PostLikeSortingApiRequest(
    [FromQuery(Name = "sortOrder")] SortOrder Order = SortOrder.ASC,
    [FromQuery(Name = "sortProperty")] PostLikeSortProperty Property = PostLikeSortProperty.ByCreatedAt);

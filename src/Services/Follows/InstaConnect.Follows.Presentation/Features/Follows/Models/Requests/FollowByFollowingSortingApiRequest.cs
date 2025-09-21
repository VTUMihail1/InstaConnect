using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record FollowByFollowingSortingApiRequest(
    [FromQuery(Name = "sortOrder")] SortOrder Order = SortOrder.ASC,
    [FromQuery(Name = "sortProperty")] FollowByFollowingSortProperty Property = FollowByFollowingSortProperty.ByCreatedAt);

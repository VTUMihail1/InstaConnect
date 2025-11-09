using InstaConnect.Common.Domain.Models;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record UserSortingApiRequest(
    [FromQuery(Name = "sortOrder")] SortOrder Order = SortOrder.ASC,
    [FromQuery(Name = "sortProperty")] UserSortProperty Property = UserSortProperty.ByCreatedAt);

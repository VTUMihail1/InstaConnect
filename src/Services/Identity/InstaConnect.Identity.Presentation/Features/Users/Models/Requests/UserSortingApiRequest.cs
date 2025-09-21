using InstaConnect.Common.Models.Enums;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Users.Presentation.Features.Users.Models.Requests;

public record UserSortingApiRequest(
    [FromQuery(Name = "sortOrder")] SortOrder Order = SortOrder.ASC,
    [FromQuery(Name = "sortProperty")] UserSortProperty Property = UserSortProperty.ByCreatedAt);

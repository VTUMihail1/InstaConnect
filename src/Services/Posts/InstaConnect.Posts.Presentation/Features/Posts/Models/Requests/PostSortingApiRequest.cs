using InstaConnect.Common.Models.Enums;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record PostSortingApiRequest(
    [FromQuery(Name = "sortOrder")] SortOrder Order = SortOrder.ASC,
    [FromQuery(Name = "sortProperty")] PostSortProperty Property = PostSortProperty.ByCreatedAt);

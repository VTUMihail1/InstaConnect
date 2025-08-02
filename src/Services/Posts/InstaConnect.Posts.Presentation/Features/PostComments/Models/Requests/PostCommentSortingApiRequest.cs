using InstaConnect.Common.Models.Enums;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

public record PostCommentSortingApiRequest(
    [FromQuery(Name = "sortOrder")] SortOrder Order = SortOrder.ASC,
    [FromQuery(Name = "sortProperty")] PostCommentSortProperty Property = PostCommentSortProperty.ByCreatedAt);

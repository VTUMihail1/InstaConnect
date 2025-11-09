using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record PostCommentSortingApiRequest(
    [FromQuery(Name = "sortOrder")] SortOrder Order = SortOrder.ASC,
    [FromQuery(Name = "sortProperty")] PostCommentSortProperty Property = PostCommentSortProperty.ByCreatedAt);

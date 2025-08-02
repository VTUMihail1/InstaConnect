using InstaConnect.Common.Models.Enums;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikeSortingApiRequest(
    [FromQuery(Name = "sortOrder")] SortOrder Order = SortOrder.ASC,
    [FromQuery(Name = "sortProperty")] PostCommentLikeSortProperty Property = PostCommentLikeSortProperty.ByCreatedAt);

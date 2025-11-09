using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikeSortingApiRequest(
    [FromQuery(Name = "sortOrder")] SortOrder Order = SortOrder.ASC,
    [FromQuery(Name = "sortProperty")] PostCommentLikeSortProperty Property = PostCommentLikeSortProperty.ByCreatedAt);

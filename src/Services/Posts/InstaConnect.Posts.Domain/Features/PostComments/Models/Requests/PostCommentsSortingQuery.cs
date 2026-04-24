using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentsSortingQuery(
    CommonSortOrder Order,
    PostCommentsSortTerm Term) : ISortingQuery<PostCommentsSortTerm>;

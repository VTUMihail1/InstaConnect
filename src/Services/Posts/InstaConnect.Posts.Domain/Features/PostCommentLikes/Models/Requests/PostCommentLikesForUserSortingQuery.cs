using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikesForUserSortingQuery(
    CommonSortOrder Order,
    PostCommentLikesForUserSortTerm Term) : ISortingQuery<PostCommentLikesForUserSortTerm>;

using InstaConnect.Common.Domain.Features.Messaging.Abstractions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record PostCommentsPaginationQuery(
    int Page,
    int PageSize) : IPaginationQuery;

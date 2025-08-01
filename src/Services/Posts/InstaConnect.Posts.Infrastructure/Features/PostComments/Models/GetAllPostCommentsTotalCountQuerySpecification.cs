using InstaConnect.PostComments.Domain.Features.PostComments.Models;

namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Models;

public record GetAllPostCommentsTotalCountQuerySpecification(
    string Sql,
    GetAllPostCommentsTotalCountQueryParameters Parameters);

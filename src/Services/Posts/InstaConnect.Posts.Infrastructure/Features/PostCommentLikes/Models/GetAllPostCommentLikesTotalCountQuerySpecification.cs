using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;

public record GetAllPostCommentLikesTotalCountQuerySpecification(
    string Sql,
    GetAllPostCommentLikesTotalCountQueryParameters Parameters);

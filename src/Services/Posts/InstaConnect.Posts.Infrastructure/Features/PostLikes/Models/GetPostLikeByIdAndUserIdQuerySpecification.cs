namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Models;

public record GetPostLikeByIdAndUserIdQuerySpecification(
    string Sql,
    GetPostLikeByIdAndUserIdQueryParameters Parameters);

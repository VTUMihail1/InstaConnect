namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Models;

public record GetPostLikeByIdQuerySpecification(
    string Sql,
    GetPostLikeByIdQueryParameters Parameters);

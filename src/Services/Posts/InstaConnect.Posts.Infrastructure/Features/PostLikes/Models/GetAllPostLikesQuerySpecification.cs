namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Models;

public record GetAllPostLikesQuerySpecification(
    string Sql,
    GetAllPostLikesQueryParameters Parameters);

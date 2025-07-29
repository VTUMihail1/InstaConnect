using InstaConnect.PostLikes.Domain.Features.PostLikes.Models;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Models;

public record GetAllPostLikesTotalCountQuerySpecification(
    string Sql,
    GetAllPostLikesTotalCountQueryParameters Parameters);

using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Posts.Domain.Features.Users.Models.Responses;

public record UserResponse(
    UserId Id,
    string FirstName,
    string LastName,
    Email Email,
    Name Name,
    Image? ProfileImage,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc) : IEntityResponse;

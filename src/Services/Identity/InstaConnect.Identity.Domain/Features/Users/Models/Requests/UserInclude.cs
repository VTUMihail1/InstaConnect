namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record UserInclude(ICollection<UserIncludeProperty> Properties) : IInclude<UserIncludeProperty>;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Responses;

public record UserQueryResponse(string Id, string UserName, string FirstName, string LastName, string? ProfileImage);

namespace InstaConnect.Identity.Web.Features.Users.Models.Responses;

public record UserDetailedQueryResponse(string Id, string FirstName, string LastName, string UserName, string Email, string? ProfileImage);

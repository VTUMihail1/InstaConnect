namespace InstaConnect.Identity.Web.Models.Response;

public record UserDetailedQueryResponse(string Id, string FirstName, string LastName, string UserName, string Email, string? ProfileImage);

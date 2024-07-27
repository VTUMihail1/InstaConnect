namespace InstaConnect.Identity.Web.Models.Response;

public record UserQueryResponse(string Id, string UserName, string FirstName, string LastName, string? ProfileImage);

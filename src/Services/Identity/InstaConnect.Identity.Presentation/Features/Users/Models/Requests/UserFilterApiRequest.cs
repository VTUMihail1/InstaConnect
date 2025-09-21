namespace InstaConnect.Users.Presentation.Features.Users.Models.Requests;

public record UserFilterApiRequest(
    [FromQuery(Name = "firstName")] string FirstName = "",
    [FromQuery(Name = "lastName")] string LastName = "",
    [FromQuery(Name = "name")] string Name = "");

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record GetPostByIdRequest(
    [FromRoute] string Id
);

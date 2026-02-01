namespace InstaConnect.Posts.Domain.Models.Requests;

public record PostsIncludeDescriptor(
    PostsDestinationType DestinationType,
    PostsIncludeType IncludeType)
    : IIncludeDescriptor<PostsDestinationType, PostsIncludeType>;

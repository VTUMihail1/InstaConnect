namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
public interface IPostSortPropertyFactory
{
    IPostSortProperty Create(PostSortProperty sortProperty);
}

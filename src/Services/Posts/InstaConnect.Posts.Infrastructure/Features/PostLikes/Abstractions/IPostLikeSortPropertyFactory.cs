namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;
public interface IPostLikeSortPropertyFactory
{
    IPostLikeSortProperty Create(PostLikeSortProperty sortProperty);
}

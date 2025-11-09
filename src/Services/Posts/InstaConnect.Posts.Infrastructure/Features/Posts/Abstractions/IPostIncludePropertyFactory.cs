namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostIncludePropertyFactory
{
    IEnumerable<IPostIncludeProperty> Create(ICollection<PostIncludeProperty>? includeProperties);
}

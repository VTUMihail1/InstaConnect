using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IPostIncludePropertyFactory
{
    ICollection<IPostIncludeProperty> Create(ICollection<PostIncludeProperty>? includeProperties);
}

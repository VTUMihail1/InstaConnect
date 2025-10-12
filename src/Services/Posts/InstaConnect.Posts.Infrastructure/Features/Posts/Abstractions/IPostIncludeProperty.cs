using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostIncludeProperty : IIncludeProperty<Post>
{
    public PostIncludeProperty IncludeProperty { get; }
}

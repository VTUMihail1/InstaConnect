using InstaConnect.Common.Models.Enums;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;
public interface IPostSortPropertyFactory
{
    IPostSortProperty Create(PostSortProperty sortProperty);
}

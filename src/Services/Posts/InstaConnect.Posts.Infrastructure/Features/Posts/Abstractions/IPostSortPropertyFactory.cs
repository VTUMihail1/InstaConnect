using InstaConnect.Common.Models.Enums;
using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;
internal interface IPostSortPropertyFactory
{
    IPostSortProperty Get(PostSortProperty sortProperty);
}

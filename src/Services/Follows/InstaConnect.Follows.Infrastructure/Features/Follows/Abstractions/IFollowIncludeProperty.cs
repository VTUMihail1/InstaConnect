using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

using MongoDB.Driver;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowIncludeProperty : IIncludeProperty<Follow>
{
    public FollowIncludeProperty IncludeProperty { get; }
}

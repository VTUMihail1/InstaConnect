using InstaConnect.Common.Models.Enums;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;
public interface IPostLikeSortPropertyFactory
{
    IPostLikeSortProperty Create(PostLikeSortProperty sortProperty);
}

using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;
public interface IFollowService
{
    public Task<FollowCollection> GetAllByFollowerAsync(GetAllFollowsByFollowerQuery query, CancellationToken cancellationToken);

    public Task<FollowCollection> GetAllByFollowingAsync(GetAllFollowsByFollowingQuery query, CancellationToken cancellationToken);

    public Task<Follow> GetByIdAsync(GetFollowByIdQuery query, CancellationToken cancellationToken);

    public Task<Follow> AddAsync(AddFollowCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeleteFollowCommand command, CancellationToken cancellationToken);
}

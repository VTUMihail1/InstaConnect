using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
public interface IRefreshTokenService
{
    public Task<SessionToken> IssueAsync(IssueRefreshTokenCommand command, CancellationToken cancellationToken);

    public Task<SessionToken> RotateAsync(RotateRefreshTokenCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeleteRefreshTokenCommand command, CancellationToken cancellationToken);
}

using InstaConnect.Common.Domain.Models.ValueObjects;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Delete;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;

using Mapster;

namespace InstaConnect.Identity.Application.Features.RefreshTokens.Mappings;

public class RefreshTokenApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<IssueRefreshTokenCommandRequest, IssueRefreshTokenCommand>()
            .ConstructUsing(src => new(
                src.Name.Adapt<Name>(),
                src.Password));

        config.NewConfig<SessionToken, IssueRefreshTokenCommandResponse>()
            .ConstructUsing(src => new(
                src.RefreshToken.Adapt<RefreshTokenCommandResponse>(),
                src.AccessToken.Adapt<AccessTokenCommandResponse>()));

        config.NewConfig<RotateRefreshTokenCommandRequest, RotateRefreshTokenCommand>()
            .ConstructUsing(src => new(src.Id.Adapt<RefreshTokenId>()));

        config.NewConfig<SessionToken, RotateRefreshTokenCommandResponse>()
            .ConstructUsing(src => new(
                src.RefreshToken.Adapt<RefreshTokenCommandResponse>(),
                src.AccessToken.Adapt<AccessTokenCommandResponse>()));

        config.NewConfig<DeleteCurrentRefreshTokenCommandRequest, DeleteRefreshTokenCommand>()
            .ConstructUsing(src => new(src.Id.Adapt<RefreshTokenId>()));

        config.NewConfig<RefreshTokenId, RefreshTokenIdPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdPayload>(),
                src.Value));

        config.NewConfig<RefreshTokenIdPayload, RefreshTokenId>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserId>(),
                src.Value));

        config.NewConfig<RefreshToken, RefreshTokenCommandResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<RefreshTokenIdPayload>(),
                src.ExpiresAtUtc));

        config.NewConfig<AccessToken, AccessTokenCommandResponse>()
            .ConstructUsing(src => new(
                src.Id,
                src.Value,
                src.ExpiresAt));
    }
}

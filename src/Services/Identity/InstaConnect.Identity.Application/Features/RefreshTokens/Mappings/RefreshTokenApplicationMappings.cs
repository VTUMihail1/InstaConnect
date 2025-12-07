using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Delete;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;

using Mapster;

namespace InstaConnect.Identity.Application.Features.RefreshTokens.Mappings;

public class RefreshTokenApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<IssueRefreshTokenCommandRequest, IssueRefreshTokenCommand>()
            .ConstructUsing(src => new(
                new(src.Name),
                src.Password));

        config.NewConfig<SessionToken, IssueRefreshTokenCommandResponse>()
            .ConstructUsing(src => new(src.Adapt<RefreshTokenCommandResponse>(config)));

        config.NewConfig<RotateRefreshTokenCommandRequest, RotateRefreshTokenCommand>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.Id),
                                           src.Value)));

        config.NewConfig<SessionToken, RotateRefreshTokenCommandResponse>()
            .ConstructUsing(src => new(src.Adapt<RefreshTokenCommandResponse>(config)));

        config.NewConfig<DeleteCurrentRefreshTokenCommandRequest, DeleteRefreshTokenCommand>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.Id),
                                           src.Value)));

        config.NewConfig<RefreshTokenId, RefreshTokenIdCommandResponse>()
            .ConstructUsing(src => new(
                src.Id.Id,
                src.Value));

        config.NewConfig<SessionToken, RefreshTokenCommandResponse>()
            .ConstructUsing(src => new(
                src.RefreshToken.Id.Adapt<RefreshTokenIdCommandResponse>(config),
                src.AccessToken.Adapt<AccessTokenCommandResponse>(config),
                src.RefreshToken.ExpiresAtUtc));

        config.NewConfig<AccessToken, AccessTokenCommandResponse>()
            .ConstructUsing(src => new(
                src.Id,
                src.Value,
                src.ExpiresAt));
    }
}

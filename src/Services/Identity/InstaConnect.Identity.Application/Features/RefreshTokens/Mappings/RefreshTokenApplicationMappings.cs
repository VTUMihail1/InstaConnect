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
            .ConstructUsing(src => new(
                src.Id.Adapt<RefreshTokenIdCommandResponse>()!,
                src.AccessToken.Adapt<AccessTokenCommandResponse>()!,
                src.ExpiresAtUtc));

        config.NewConfig<RotateRefreshTokenCommandRequest, RotateRefreshTokenCommand>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.Id),
                                           src.Value)));

        config.NewConfig<SessionToken, RotateRefreshTokenCommandResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<RefreshTokenIdCommandResponse>()!,
                src.AccessToken.Adapt<AccessTokenCommandResponse>()!,
                src.ExpiresAtUtc));

        config.NewConfig<DeleteCurrentRefreshTokenCommandRequest, DeleteRefreshTokenCommand>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.Id),
                                           src.Value)));

        config.NewConfig<RefreshToken, RefreshTokenIdCommandResponse>()
            .ConstructUsing(src => new(
                src.Id.Id.Id,
                src.Id.Value));

        config.NewConfig<AccessToken, AccessTokenCommandResponse>()
            .ConstructUsing(src => new(
                src.Value,
                src.ExpiresAtUtc));
    }
}

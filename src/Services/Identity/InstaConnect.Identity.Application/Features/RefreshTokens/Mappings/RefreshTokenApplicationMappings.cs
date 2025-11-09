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
            .ConstructUsing(src => new(src.Name, src.Password));

        config.NewConfig<SessionToken, IssueRefreshTokenCommandResponse>()
            .ConstructUsing(src => new(
                new(src.RefreshToken.Id, src.RefreshToken.Value, src.RefreshToken.ExpiresAt),
                new(src.AccessToken.Id, src.AccessToken.Value, src.AccessToken.ExpiresAt)));

        config.NewConfig<RotateRefreshTokenCommandRequest, RotateRefreshTokenCommand>()
            .ConstructUsing(src => new(src.Id, src.Value));

        config.NewConfig<SessionToken, RotateRefreshTokenCommandResponse>()
            .ConstructUsing(src => new(
                new(src.RefreshToken.Id, src.RefreshToken.Value, src.RefreshToken.ExpiresAt),
                new(src.AccessToken.Id, src.AccessToken.Value, src.AccessToken.ExpiresAt)));

        config.NewConfig<DeleteCurrentRefreshTokenCommandRequest, DeleteRefreshTokenCommand>()
            .ConstructUsing(src => new(src.Id, src.Value));
    }
}

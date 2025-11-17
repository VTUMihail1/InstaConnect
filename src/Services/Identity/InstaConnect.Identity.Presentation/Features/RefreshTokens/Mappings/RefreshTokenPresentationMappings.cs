using AutoMapper;

using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Delete;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;
using InstaConnect.Identity.Application.Features.RefreshTokens.Models;
using InstaConnect.Identity.Application.Features.Users.Models;

using Mapster;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Mappings;

internal class RefreshTokenPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<IssueRefreshTokenApiRequest, IssueRefreshTokenCommandRequest>()
            .ConstructUsing(src => new(
                                       new(src.Name),
                                       src.Body.Password));

        config.NewConfig<IssueRefreshTokenCommandResponse, IssueRefreshTokenApiResponse>()
            .ConstructUsing(src => new(
                new(
                    src.AccessToken.Id,
                    src.AccessToken.Value,
                    src.AccessToken.ExpiresAt)));

        config.NewConfig<RotateRefreshTokenApiRequest, RotateRefreshTokenCommandRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<RefreshTokenIdPayload>()));

        config.NewConfig<RotateRefreshTokenCommandResponse, RotateRefreshTokenApiResponse>()
            .ConstructUsing(src => new(
                new(
                    src.AccessToken.Id,
                    src.AccessToken.Value,
                    src.AccessToken.ExpiresAt)));

        config.NewConfig<DeleteCurrentRefreshTokenApiRequest, DeleteCurrentRefreshTokenCommandRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<RefreshTokenIdPayload>()));

        config.NewConfig<RefreshTokenIdApiPayload, RefreshTokenIdPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdPayload>(),
                src.Value));

        config.NewConfig<RefreshTokenIdPayload, RefreshTokenIdApiPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdApiPayload>(),
                src.Value));
    }
}

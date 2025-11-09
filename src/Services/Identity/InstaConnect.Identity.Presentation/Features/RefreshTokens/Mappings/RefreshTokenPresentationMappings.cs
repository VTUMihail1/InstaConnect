using AutoMapper;

using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Delete;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;
using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Mappings;

internal class RefreshTokenPresentationMappings : Profile
{
    public RefreshTokenPresentationMappings()
    {
        CreateMap<IssueRefreshTokenApiRequest, IssueRefreshTokenCommandRequest>()
            .ConstructUsing(src => new(src.Name, src.Body.Password));

        CreateMap<IssueRefreshTokenCommandResponse, IssueRefreshTokenApiResponse>()
            .ConstructUsing(src => new(
                new(
                    src.AccessToken.Id,
                    src.AccessToken.Value,
                    src.AccessToken.ExpiresAt)));

        CreateMap<RotateRefreshTokenApiRequest, RotateRefreshTokenCommandRequest>()
            .ConstructUsing(src => new(src.Id, src.Value));

        CreateMap<RotateRefreshTokenCommandResponse, RotateRefreshTokenApiResponse>()
            .ConstructUsing(src => new(
                new(
                    src.AccessToken.Id,
                    src.AccessToken.Value,
                    src.AccessToken.ExpiresAt)));

        CreateMap<DeleteCurrentRefreshTokenApiRequest, DeleteCurrentRefreshTokenCommandRequest>()
            .ConstructUsing(src => new(src.Id, src.Value));
    }
}

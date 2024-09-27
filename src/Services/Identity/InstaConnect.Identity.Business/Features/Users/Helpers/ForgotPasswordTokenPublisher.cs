using InstaConnect.Identity.Business.Features.Users.Abstractions;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.Features.Users.Models.Options;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Emails;
using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Business.Features.Users.Helpers;

internal class ForgotPasswordTokenPublisher : IForgotPasswordTokenPublisher
{
    private readonly GatewayOptions _gatewayOptions;
    private readonly IEventPublisher _eventPublisher;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IForgotPasswordTokenFactory _forgotPasswordTokenFactory;
    private readonly IForgotPasswordTokenWriteRepository _forgotPasswordTokenWriteRepository;

    public ForgotPasswordTokenPublisher(
        IOptions<GatewayOptions> gatewayOptions,
        IEventPublisher eventPublisher,
        IInstaConnectMapper instaConnectMapper,
        IForgotPasswordTokenFactory forgotPasswordTokenFactory,
        IForgotPasswordTokenWriteRepository forgotPasswordTokenWriteRepository)
    {
        _gatewayOptions = gatewayOptions.Value;
        _eventPublisher = eventPublisher;
        _instaConnectMapper = instaConnectMapper;
        _forgotPasswordTokenFactory = forgotPasswordTokenFactory;
        _forgotPasswordTokenWriteRepository = forgotPasswordTokenWriteRepository;
    }

    public async Task PublishForgotPasswordTokenAsync(
        CreateForgotPasswordTokenModel createForgotPasswordTokenModel,
        CancellationToken cancellationToken)
    {
        var emailConfirmationToken = _forgotPasswordTokenFactory.GetForgotPasswordToken(createForgotPasswordTokenModel.UserId);
        _forgotPasswordTokenWriteRepository.Add(emailConfirmationToken);

        var userConfirmEmailTokenCreatedEvent = _instaConnectMapper
            .Map<UserForgotPasswordTokenCreatedEvent>((emailConfirmationToken, createForgotPasswordTokenModel, _gatewayOptions));
        await _eventPublisher.PublishAsync(userConfirmEmailTokenCreatedEvent, cancellationToken);
    }
}

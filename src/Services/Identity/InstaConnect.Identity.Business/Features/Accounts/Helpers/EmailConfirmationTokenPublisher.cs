using InstaConnect.Identity.Business.Features.Accounts.Abstractions;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Business.Features.Accounts.Models.Options;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Emails;
using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Business.Features.Accounts.Helpers;

internal class EmailConfirmationTokenPublisher : IEmailConfirmationTokenPublisher
{
    private readonly GatewayOptions _gatewayOptions;
    private readonly IEventPublisher _eventPublisher;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IEmailConfirmationTokenFactory _emailConfirmationTokenFactory;
    private readonly IEmailConfirmationTokenWriteRepository _emailConfirmationTokenWriteRepository;

    public EmailConfirmationTokenPublisher(
        IOptions<GatewayOptions> gatewayOptions,
        IEventPublisher eventPublisher,
        IInstaConnectMapper instaConnectMapper,
        IEmailConfirmationTokenFactory emailConfirmationTokenFactory,
        IEmailConfirmationTokenWriteRepository emailConfirmationTokenWriteRepository)
    {
        _gatewayOptions = gatewayOptions.Value;
        _eventPublisher = eventPublisher;
        _instaConnectMapper = instaConnectMapper;
        _emailConfirmationTokenFactory = emailConfirmationTokenFactory;
        _emailConfirmationTokenWriteRepository = emailConfirmationTokenWriteRepository;
    }

    public async Task PublishEmailConfirmationTokenAsync(
        CreateEmailConfirmationTokenModel createEmailConfirmationTokenModel,
        CancellationToken cancellationToken)
    {
        var emailConfirmationToken = _emailConfirmationTokenFactory.GetEmailConfirmationToken(createEmailConfirmationTokenModel.UserId);
        _emailConfirmationTokenWriteRepository.Add(emailConfirmationToken);

        var userConfirmEmailTokenCreatedEvent = _instaConnectMapper
            .Map<UserConfirmEmailTokenCreatedEvent>((emailConfirmationToken, createEmailConfirmationTokenModel, _gatewayOptions));
        await _eventPublisher.PublishAsync(userConfirmEmailTokenCreatedEvent, cancellationToken);
    }
}

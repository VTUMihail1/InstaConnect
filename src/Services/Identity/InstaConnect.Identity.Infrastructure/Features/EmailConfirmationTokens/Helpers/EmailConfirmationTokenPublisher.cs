using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Contracts.Emails;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers;

internal class EmailConfirmationTokenPublisher : IEmailConfirmationTokenPublisher
{
    private readonly IEventPublisher _eventPublisher;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IEmailConfirmationTokenGenerator _emailConfirmationTokenGenerator;
    private readonly IEmailConfirmationTokenWriteRepository _emailConfirmationTokenWriteRepository;

    public EmailConfirmationTokenPublisher(
        IEventPublisher eventPublisher,
        IInstaConnectMapper instaConnectMapper,
        IEmailConfirmationTokenGenerator emailConfirmationTokenGenerator,
        IEmailConfirmationTokenWriteRepository emailConfirmationTokenWriteRepository)
    {
        _eventPublisher = eventPublisher;
        _instaConnectMapper = instaConnectMapper;
        _emailConfirmationTokenGenerator = emailConfirmationTokenGenerator;
        _emailConfirmationTokenWriteRepository = emailConfirmationTokenWriteRepository;
    }

    public async Task PublishEmailConfirmationTokenAsync(
        CreateEmailConfirmationTokenModel createEmailConfirmationTokenModel,
        CancellationToken cancellationToken)
    {
        var emailConfirmationResponse = _emailConfirmationTokenGenerator.GenerateEmailConfirmationToken(createEmailConfirmationTokenModel.UserId, createEmailConfirmationTokenModel.Email);

        var emailConfirmationToken = _instaConnectMapper.Map<EmailConfirmationToken>(emailConfirmationResponse);
        _emailConfirmationTokenWriteRepository.Add(emailConfirmationToken);

        var userEmailConfirmationTokenCreatedEvent = _instaConnectMapper.Map<UserConfirmEmailTokenCreatedEvent>(emailConfirmationResponse);
        await _eventPublisher.PublishAsync(userEmailConfirmationTokenCreatedEvent, cancellationToken);
    }
}

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Contracts.EmailConfirmationTokens;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Models;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers;

internal class EmailConfirmationTokenPublisher : IEmailConfirmationTokenPublisher
{
    private readonly IEventPublisher _eventPublisher;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IEmailConfirmationTokenGenerator _emailConfirmationTokenGenerator;
    private readonly IEmailConfirmationTokenWriteRepository _emailConfirmationTokenWriteRepository;

    public EmailConfirmationTokenPublisher(
        IEventPublisher eventPublisher,
        IApplicationMapper applicationMapper,
        IEmailConfirmationTokenGenerator emailConfirmationTokenGenerator,
        IEmailConfirmationTokenWriteRepository emailConfirmationTokenWriteRepository)
    {
        _eventPublisher = eventPublisher;
        _applicationMapper = applicationMapper;
        _emailConfirmationTokenGenerator = emailConfirmationTokenGenerator;
        _emailConfirmationTokenWriteRepository = emailConfirmationTokenWriteRepository;
    }

    public async Task PublishEmailConfirmationTokenAsync(
        CreateEmailConfirmationTokenModel createEmailConfirmationTokenModel,
        CancellationToken cancellationToken)
    {
        var emailConfirmationResponse = _emailConfirmationTokenGenerator.GenerateEmailConfirmationToken(createEmailConfirmationTokenModel.UserId, createEmailConfirmationTokenModel.Email);

        var emailConfirmationToken = _applicationMapper.Map<EmailConfirmationToken>(emailConfirmationResponse);
        _emailConfirmationTokenWriteRepository.Add(emailConfirmationToken);

        var userEmailConfirmationTokenCreatedEvent = _applicationMapper.Map<UserConfirmEmailTokenCreatedEvent>(emailConfirmationResponse);
        await _eventPublisher.PublishAsync(userEmailConfirmationTokenCreatedEvent, cancellationToken);
    }
}

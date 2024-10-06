using InstaConnect.Identity.Business.Features.Users.Abstractions;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Helpers;

internal class EmailConfirmationTokenPublisher : IEmailConfirmationTokenPublisher
{
    private readonly IEventPublisher _eventPublisher;
    private readonly IEmailConfirmationTokenFactory _emailConfirmationTokenFactory;
    private readonly IEmailConfirmationTokenWriteRepository _emailConfirmationTokenWriteRepository;
    private readonly IUserConfirmEmailTokenCreatedEventFactory _userConfirmEmailTokenCreatedEventFactory;

    public EmailConfirmationTokenPublisher(
        IEventPublisher eventPublisher,
        IEmailConfirmationTokenFactory emailConfirmationTokenFactory,
        IEmailConfirmationTokenWriteRepository emailConfirmationTokenWriteRepository,
        IUserConfirmEmailTokenCreatedEventFactory userConfirmEmailTokenCreatedEventFactory)
    {
        _eventPublisher = eventPublisher;
        _emailConfirmationTokenFactory = emailConfirmationTokenFactory;
        _emailConfirmationTokenWriteRepository = emailConfirmationTokenWriteRepository;
        _userConfirmEmailTokenCreatedEventFactory = userConfirmEmailTokenCreatedEventFactory;
    }

    public async Task PublishEmailConfirmationTokenAsync(
        CreateEmailConfirmationTokenModel createEmailConfirmationTokenModel,
        CancellationToken cancellationToken)
    {
        var emailConfirmationToken = _emailConfirmationTokenFactory.GetEmailConfirmationToken(createEmailConfirmationTokenModel.UserId);
        _emailConfirmationTokenWriteRepository.Add(emailConfirmationToken);

        var userConfirmEmailTokenCreatedEvent = _userConfirmEmailTokenCreatedEventFactory.GetUserConfirmEmailTokenCreatedEvent(
            createEmailConfirmationTokenModel.UserId,
            createEmailConfirmationTokenModel.Email,
            emailConfirmationToken.Value);
        await _eventPublisher.PublishAsync(userConfirmEmailTokenCreatedEvent, cancellationToken);
    }
}

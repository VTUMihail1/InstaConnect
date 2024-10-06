using InstaConnect.Identity.Business.Features.Users.Abstractions;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Helpers;

internal class ForgotPasswordTokenPublisher : IForgotPasswordTokenPublisher
{
    private readonly IEventPublisher _eventPublisher;
    private readonly IForgotPasswordTokenFactory _forgotPasswordTokenFactory;
    private readonly IForgotPasswordTokenWriteRepository _forgotPasswordTokenWriteRepository;
    private readonly IUserForgotPasswordTokenCreatedEventFactory _userForgotPasswordTokenCreatedEventFactory;

    public ForgotPasswordTokenPublisher(
        IEventPublisher eventPublisher,
        IForgotPasswordTokenFactory forgotPasswordTokenFactory,
        IForgotPasswordTokenWriteRepository forgotPasswordTokenWriteRepository,
        IUserForgotPasswordTokenCreatedEventFactory userForgotPasswordTokenCreatedEventFactory)
    {
        _eventPublisher = eventPublisher;
        _forgotPasswordTokenFactory = forgotPasswordTokenFactory;
        _forgotPasswordTokenWriteRepository = forgotPasswordTokenWriteRepository;
        _userForgotPasswordTokenCreatedEventFactory = userForgotPasswordTokenCreatedEventFactory;
    }

    public async Task PublishForgotPasswordTokenAsync(
        CreateForgotPasswordTokenModel createForgotPasswordTokenModel,
        CancellationToken cancellationToken)
    {
        var forgotPasswordToken = _forgotPasswordTokenFactory.GetForgotPasswordToken(createForgotPasswordTokenModel.UserId);
        _forgotPasswordTokenWriteRepository.Add(forgotPasswordToken);

        var userForgotPasswordTokenCreatedEvent = _userForgotPasswordTokenCreatedEventFactory.GetUserForgotPasswordTokenCreatedEvent(
            createForgotPasswordTokenModel.UserId,
            createForgotPasswordTokenModel.Email,
            forgotPasswordToken.Value);
        await _eventPublisher.PublishAsync(userForgotPasswordTokenCreatedEvent, cancellationToken);
    }
}

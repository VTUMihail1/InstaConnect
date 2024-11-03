using InstaConnect.Identity.Business.Features.Users.Abstractions;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Emails;

namespace InstaConnect.Identity.Business.Features.Users.Helpers;

internal class ForgotPasswordTokenPublisher : IForgotPasswordTokenPublisher
{
    private readonly IEventPublisher _eventPublisher;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IForgotPasswordTokenGenerator _forgotPasswordTokenGenerator;
    private readonly IForgotPasswordTokenWriteRepository _forgotPasswordTokenWriteRepository;

    public ForgotPasswordTokenPublisher(
        IEventPublisher eventPublisher,
        IInstaConnectMapper instaConnectMapper,
        IForgotPasswordTokenGenerator forgotPasswordTokenGenerator,
        IForgotPasswordTokenWriteRepository forgotPasswordTokenWriteRepository)
    {
        _eventPublisher = eventPublisher;
        _instaConnectMapper = instaConnectMapper;
        _forgotPasswordTokenGenerator = forgotPasswordTokenGenerator;
        _forgotPasswordTokenWriteRepository = forgotPasswordTokenWriteRepository;
    }

    public async Task PublishForgotPasswordTokenAsync(
        CreateForgotPasswordTokenModel createForgotPasswordTokenModel,
        CancellationToken cancellationToken)
    {
        var forgotPasswordResponse = _forgotPasswordTokenGenerator.GenerateForgotPasswordToken(createForgotPasswordTokenModel.UserId, createForgotPasswordTokenModel.Email);

        var forgotPasswordToken = _instaConnectMapper.Map<ForgotPasswordToken>(forgotPasswordResponse);
        _forgotPasswordTokenWriteRepository.Add(forgotPasswordToken);

        var userForgotPasswordTokenCreatedEvent = _instaConnectMapper.Map<UserForgotPasswordTokenCreatedEvent>(forgotPasswordResponse);
        await _eventPublisher.PublishAsync(userForgotPasswordTokenCreatedEvent, cancellationToken);
    }
}

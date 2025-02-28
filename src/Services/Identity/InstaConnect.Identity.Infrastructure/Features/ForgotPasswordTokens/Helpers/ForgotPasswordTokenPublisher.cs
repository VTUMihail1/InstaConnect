using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Contracts.ForgotPasswordTokens;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Models;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers;

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

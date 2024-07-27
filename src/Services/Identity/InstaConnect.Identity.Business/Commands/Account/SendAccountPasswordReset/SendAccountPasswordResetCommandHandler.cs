using AutoMapper;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Emails;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Identity.Business.Commands.Account.SendAccountPasswordReset;

public class SendAccountPasswordResetCommandHandler : ICommandHandler<SendAccountPasswordResetCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventPublisher _eventPublisher;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public SendAccountPasswordResetCommandHandler(
        IUnitOfWork unitOfWork,
        IEventPublisher eventPublisher,
        ITokenGenerator tokenGenerator,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _eventPublisher = eventPublisher;
        _tokenGenerator = tokenGenerator;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
    }

    public async Task Handle(
        SendAccountPasswordResetCommand request, 
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var createAccountTokenModel = _instaConnectMapper.Map<CreateAccountTokenModel>(existingUser);
        var token = _tokenGenerator.GeneratePasswordResetToken(createAccountTokenModel);

        var userForgotPasswordTokenCreatedEvent = _instaConnectMapper.Map<UserForgotPasswordTokenCreatedEvent>((token, existingUser));
        await _eventPublisher.PublishAsync(userForgotPasswordTokenCreatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Models;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Abstractions;
using InstaConnect.Shared.Common.Exceptions.Users;

namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;

public class AddForgotPasswordTokenCommandHandler : ICommandHandler<AddForgotPasswordTokenCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IForgotPasswordTokenPublisher _forgotPasswordTokenPublisher;

    public AddForgotPasswordTokenCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository,
        IForgotPasswordTokenPublisher forgotPasswordTokenPublisher)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
        _forgotPasswordTokenPublisher = forgotPasswordTokenPublisher;
    }

    public async Task Handle(
        AddForgotPasswordTokenCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var createForgotPasswordTokenModel = _instaConnectMapper.Map<CreateForgotPasswordTokenModel>(existingUser);
        await _forgotPasswordTokenPublisher.PublishForgotPasswordTokenAsync(createForgotPasswordTokenModel, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

using AutoMapper;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Users.Data.Abstraction;
using InstaConnect.Users.Data.Models;

namespace InstaConnect.Users.Business.Commands.Account.ResendAccountEmailConfirmation;

public class ResendAccountEmailConfirmationCommandHandler : ICommandHandler<ResendAccountEmailConfirmationCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly ITokenRepository _tokenRepository;

    public ResendAccountEmailConfirmationCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        ITokenGenerator tokenGenerator,
        ITokenRepository tokenRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
        _tokenRepository = tokenRepository;
    }

    public async Task Handle(ResendAccountEmailConfirmationCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        if (existingUser.IsEmailConfirmed)
        {
            throw new AccountEmailAlreadyConfirmedException();
        }

        var createAccountTokenModel = _mapper.Map<CreateAccountTokenModel>(existingUser);
        var token = _tokenGenerator.GenerateEmailConfirmationToken(createAccountTokenModel);
        _tokenRepository.Add(token);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

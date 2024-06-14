using AutoMapper;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Abstraction.Repositories;
using InstaConnect.Users.Data.Models.Entities;

namespace InstaConnect.Users.Business.Commands.Account.RegisterAccount;

public class RegisterAccountCommandHandler : ICommandHandler<RegisterAccountCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterAccountCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IPasswordHasher passwordHasher)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
    {
        var existingEmailUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingEmailUser != null)
        {
            throw new AccountEmailAlreadyTakenException();
        }

        var existingNameUser = await _userRepository.GetByNameAsync(request.UserName, cancellationToken);

        if (existingNameUser != null)
        {
            throw new AccountUsernameAlreadyTakenException();
        }

        var user = _mapper.Map<User>(request);
        var passwordHash = _passwordHasher.Hash(request.Password);
        _mapper.Map(passwordHash, user);
        _userRepository.Add(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

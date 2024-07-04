using AutoMapper;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Identity.Business.Commands.Account.RegisterAccount;

public class RegisterAccountCommandHandler : ICommandHandler<RegisterAccountCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IPublishEndpoint _publishEndpoint;

    public RegisterAccountCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IPublishEndpoint publishEndpoint)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _publishEndpoint = publishEndpoint;
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

        var userCreatedEvent = _mapper.Map<UserCreatedEvent>(user);
        await _publishEndpoint.Publish(userCreatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

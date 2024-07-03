using AutoMapper;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;
using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Business.Commands.Account.DeleteCurrentAccount;

public class DeleteCurrentAccountCommandHandler : ICommandHandler<DeleteCurrentAccountCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public DeleteCurrentAccountCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IPublishEndpoint publishEndpoint)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Handle(DeleteCurrentAccountCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        _userRepository.Delete(existingUser);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var userDeletedEvent = _mapper.Map<UserDeletedEvent>(existingUser);
        await _publishEndpoint.Publish(userDeletedEvent, cancellationToken);
    }
}

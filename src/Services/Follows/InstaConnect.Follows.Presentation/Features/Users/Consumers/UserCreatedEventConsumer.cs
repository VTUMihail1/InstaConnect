using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Domain.Features.Users.Models.Entities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Contracts.Users;
using MassTransit;

namespace InstaConnect.Follows.Presentation.Features.Users.Consumers;

internal class UserCreatedEventConsumer : IConsumer<UserCreatedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public UserCreatedEventConsumer(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
    }

    public async Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingUser != null)
        {
            return;
        }

        var user = _instaConnectMapper.Map<User>(context.Message);
        _userWriteRepository.Add(user);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

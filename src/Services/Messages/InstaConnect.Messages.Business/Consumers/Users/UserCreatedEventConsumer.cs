using AutoMapper;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Business.Consumers.Users;

internal class UserCreatedEventConsumer : IConsumer<UserCreatedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserReadRepository _userRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public UserCreatedEventConsumer(
        IUnitOfWork unitOfWork,
        IUserReadRepository userRepository,
        IInstaConnectMapper instaConnectMapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        var existingUser = await _userRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingUser != null)
        {
            return;
        }

        var user = _instaConnectMapper.Map<User>(context.Message);
        _userRepository.Add(user);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

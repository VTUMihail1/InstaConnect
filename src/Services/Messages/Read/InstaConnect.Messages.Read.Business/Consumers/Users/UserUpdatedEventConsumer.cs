using AutoMapper;
using InstaConnect.Messages.Read.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Read.Business.Consumers.Users;

internal class UserUpdatedEventConsumer : IConsumer<UserUpdatedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public UserUpdatedEventConsumer(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IInstaConnectMapper instaConnectMapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task Consume(ConsumeContext<UserUpdatedEvent> context)
    {
        var existingUser = await _userRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingUser == null)
        {
            return;
        }

        _instaConnectMapper.Map(context.Message, existingUser);
        _userRepository.Update(existingUser);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

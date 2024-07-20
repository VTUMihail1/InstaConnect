using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Business.Consumers.Users;

internal class UserUpdatedEventConsumer : IConsumer<UserUpdatedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserReadRepository _userRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public UserUpdatedEventConsumer(
        IUnitOfWork unitOfWork,
        IUserReadRepository userRepository,
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

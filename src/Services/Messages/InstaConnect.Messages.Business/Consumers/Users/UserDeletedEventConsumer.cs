using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Business.Consumers.Users;

internal class UserDeletedEventConsumer : IConsumer<UserDeletedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserReadRepository _userRepository;

    public UserDeletedEventConsumer(
        IUnitOfWork unitOfWork,
        IUserReadRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task Consume(ConsumeContext<UserDeletedEvent> context)
    {
        var existingUser = await _userRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingUser == null)
        {
            return;
        }

        _userRepository.Delete(existingUser);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

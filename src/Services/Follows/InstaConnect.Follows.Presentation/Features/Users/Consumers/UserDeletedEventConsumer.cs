﻿namespace InstaConnect.Follows.Presentation.Features.Users.Consumers;

internal class UserDeletedEventConsumer : IConsumer<UserDeletedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserWriteRepository _userWriteRepository;

    public UserDeletedEventConsumer(
        IUnitOfWork unitOfWork,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _userWriteRepository = userWriteRepository;
    }

    public async Task Consume(ConsumeContext<UserDeletedEvent> context)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingUser == null)
        {
            return;
        }

        _userWriteRepository.Delete(existingUser);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

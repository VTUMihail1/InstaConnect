﻿namespace InstaConnect.Messages.Presentation.Features.Users.Consumers;

internal class UserUpdatedEventConsumer : IConsumer<UserUpdatedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public UserUpdatedEventConsumer(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
    }

    public async Task Consume(ConsumeContext<UserUpdatedEvent> context)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingUser == null)
        {
            return;
        }

        _instaConnectMapper.Map(context.Message, existingUser);
        _userWriteRepository.Update(existingUser);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

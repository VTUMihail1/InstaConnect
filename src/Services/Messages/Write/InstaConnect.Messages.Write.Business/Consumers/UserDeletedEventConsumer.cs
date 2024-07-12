using AutoMapper;
using InstaConnect.Messages.Write.Data.Abstractions;
using InstaConnect.Messages.Write.Data.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Write.Business.Consumers;

public class UserDeletedEventConsumer : IConsumer<UserDeletedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageRepository _messageRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public UserDeletedEventConsumer(
        IUnitOfWork unitOfWork,
        IMessageRepository messageRepository,
        IInstaConnectMapper instaConnectMapper)
    {
        _instaConnectMapper = instaConnectMapper;
        _unitOfWork = unitOfWork;
        _messageRepository = messageRepository;
    }

    public async Task Consume(ConsumeContext<UserDeletedEvent> context)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<MessageFilteredCollectionQuery>(context.Message);
        var existingMessages = await _messageRepository.GetAllFilteredAsync(filteredCollectionQuery, context.CancellationToken);

        _messageRepository.DeleteRange(existingMessages);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

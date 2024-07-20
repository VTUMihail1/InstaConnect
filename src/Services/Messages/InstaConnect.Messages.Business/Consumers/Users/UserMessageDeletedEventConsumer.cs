using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Business.Consumers.Users;

internal class UserMessageDeletedEventConsumer : IConsumer<UserDeletedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageWriteRepository _messageRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public UserMessageDeletedEventConsumer(
        IUnitOfWork unitOfWork,
        IMessageWriteRepository messageRepository,
        IInstaConnectMapper instaConnectMapper)
    {
        _instaConnectMapper = instaConnectMapper;
        _unitOfWork = unitOfWork;
        _messageRepository = messageRepository;
    }

    public async Task Consume(ConsumeContext<UserDeletedEvent> context)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<MessageFilteredCollectionWriteQuery>(context.Message);
        var existingMessages = await _messageRepository.GetAllFilteredAsync(filteredCollectionQuery, context.CancellationToken);

        _messageRepository.DeleteRange(existingMessages);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

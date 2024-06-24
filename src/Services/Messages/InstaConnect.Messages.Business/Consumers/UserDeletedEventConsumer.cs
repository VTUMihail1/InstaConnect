using AutoMapper;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Business.Consumers;
internal class UserDeletedEventConsumer : IConsumer<UserDeletedEvent>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageRepository _messageRepository;

    public UserDeletedEventConsumer(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IMessageRepository messageRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _messageRepository = messageRepository;
    }

    public async Task Consume(ConsumeContext<UserDeletedEvent> context)
    {
        var filteredCollectionQuery = _mapper.Map<MessageFilteredCollectionQuery>(context.Message);
        var existingMessages = await _messageRepository.GetAllAsync(filteredCollectionQuery, context.CancellationToken);

        _messageRepository.DeleteRange(existingMessages);
        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

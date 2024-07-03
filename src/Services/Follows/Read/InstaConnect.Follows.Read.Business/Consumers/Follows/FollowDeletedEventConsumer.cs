using InstaConnect.Follows.Read.Data.Abstractions;
using InstaConnect.Shared.Business.Contracts.Follows;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Follows.Read.Business.Consumers.Follows;

internal class FollowDeletedEventConsumer : IConsumer<FollowDeletedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFollowRepository _followRepository;

    public FollowDeletedEventConsumer(
        IUnitOfWork unitOfWork,
        IFollowRepository followRepository)
    {
        _unitOfWork = unitOfWork;
        _followRepository = followRepository;
    }

    public async Task Consume(ConsumeContext<FollowDeletedEvent> context)
    {
        var existingFollow = await _followRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingFollow == null)
        {
            return;
        }

        _followRepository.Delete(existingFollow);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

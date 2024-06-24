using AutoMapper;
using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Follows.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Follows.Business.Consumers;
internal class UserDeletedEventConsumer : IConsumer<UserDeletedEvent>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFollowRepository _followRepository;

    public UserDeletedEventConsumer(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IFollowRepository followRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _followRepository = followRepository;
    }

    public async Task Consume(ConsumeContext<UserDeletedEvent> context)
    {
        var filteredCollectionQuery = _mapper.Map<FollowFilteredCollectionQuery>(context.Message);
        var existingFollows = await _followRepository.GetAllAsync(filteredCollectionQuery, context.CancellationToken);

        _followRepository.DeleteRange(existingFollows);
        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

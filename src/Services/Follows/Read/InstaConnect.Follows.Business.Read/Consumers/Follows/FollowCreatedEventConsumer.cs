using AutoMapper;
using InstaConnect.Follows.Data.Read.Abstractions;
using InstaConnect.Follows.Data.Read.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Follows;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Follows.Business.Read.Consumers.Follows;

internal class FollowCreatedEventConsumer : IConsumer<FollowCreatedEvent>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFollowRepository _followRepository;

    public FollowCreatedEventConsumer(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IFollowRepository followRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _followRepository = followRepository;
    }

    public async Task Consume(ConsumeContext<FollowCreatedEvent> context)
    {
        var follow = _mapper.Map<Follow>(context.Message);
        _followRepository.Add(follow);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

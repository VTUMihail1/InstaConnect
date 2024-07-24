using AutoMapper;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Read.Business.Consumers.Users;

internal class UserCreatedEventConsumer : IConsumer<UserCreatedEvent>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserReadRepository _userRepository;

    public UserCreatedEventConsumer(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IUserReadRepository userRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        var user = _mapper.Map<User>(context.Message);
        _userRepository.Add(user);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

using AutoMapper;
using InstaConnect.Follows.Data.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Follows.Read.Business.Consumers.Users;

internal class UserUpdatedEventConsumer : IConsumer<UserUpdatedEvent>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserWriteRepository _userWriteRepository;

    public UserUpdatedEventConsumer(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IUserWriteRepository userWriteRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userWriteRepository = userWriteRepository;
    }

    public async Task Consume(ConsumeContext<UserUpdatedEvent> context)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingUser == null)
        {
            return;
        }

        _mapper.Map(context.Message, existingUser);
        _userWriteRepository.Update(existingUser);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

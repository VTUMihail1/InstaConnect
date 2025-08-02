using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Presentation.Features.Users.Consumers;

internal class UserUpdatedEventConsumer : IConsumer<UserUpdatedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserService _userService;
    private readonly IApplicationMapper _applicationMapper;

    public UserUpdatedEventConsumer(
        IUnitOfWork unitOfWork,
        IUserService userService,
        IApplicationMapper applicationMapper)
    {
        _unitOfWork = unitOfWork;
        _userService = userService;
        _applicationMapper = applicationMapper;
    }

    public async Task Consume(ConsumeContext<UserUpdatedEvent> context)
    {
        var command = _applicationMapper.Map<UpdateUserCommand>(context.Message);
        await _userService.UpdateAsync(command, context.CancellationToken);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

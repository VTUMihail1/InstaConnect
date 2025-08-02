using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Presentation.Features.Users.Consumers;

internal class UserDeletedEventConsumer : IConsumer<UserDeletedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserService _userService;
    private readonly IApplicationMapper _applicationMapper;

    public UserDeletedEventConsumer(
        IUnitOfWork unitOfWork,
        IUserService userService,
        IApplicationMapper applicationMapper)
    {
        _unitOfWork = unitOfWork;
        _userService = userService;
        _applicationMapper = applicationMapper;
    }

    public async Task Consume(ConsumeContext<UserDeletedEvent> context)
    {
        var command = _applicationMapper.Map<DeleteUserCommand>(context.Message);
        await _userService.DeleteAsync(command, context.CancellationToken);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}

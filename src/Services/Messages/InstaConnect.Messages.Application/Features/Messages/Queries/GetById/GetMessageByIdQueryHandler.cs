namespace InstaConnect.Messages.Application.Features.Messages.Queries.GetById;

internal class GetMessageByIdQueryHandler : IQueryHandler<GetMessageByIdQuery, MessageQueryViewModel>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IMessageReadRepository _messageReadRepository;

    public GetMessageByIdQueryHandler(
        IApplicationMapper applicationMapper,
        IMessageReadRepository messageReadRepository)
    {
        _applicationMapper = applicationMapper;
        _messageReadRepository = messageReadRepository;
    }

    public async Task<MessageQueryViewModel> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
    {
        var message = await _messageReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (message == null)
        {
            throw new MessageNotFoundException();
        }

        if (message.SenderId != request.CurrentUserId)
        {
            throw new UserForbiddenException();
        }

        var response = _applicationMapper.Map<MessageQueryViewModel>(message);

        return response;
    }
}

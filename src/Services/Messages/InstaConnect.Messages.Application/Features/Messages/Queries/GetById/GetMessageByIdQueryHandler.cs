﻿namespace InstaConnect.Messages.Application.Features.Messages.Queries.GetById;

internal class GetMessageByIdQueryHandler : IQueryHandler<GetMessageByIdQuery, MessageQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IMessageReadRepository _messageReadRepository;

    public GetMessageByIdQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IMessageReadRepository messageReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
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

        var response = _instaConnectMapper.Map<MessageQueryViewModel>(message);

        return response;
    }
}

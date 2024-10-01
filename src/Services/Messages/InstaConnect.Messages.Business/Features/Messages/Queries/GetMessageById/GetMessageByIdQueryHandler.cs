using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Messages.Data.Features.Messages.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Common.Exceptions.Message;
using InstaConnect.Shared.Common.Exceptions.User;

namespace InstaConnect.Messages.Business.Features.Messages.Queries.GetMessageById;

internal class GetMessageByIdQueryHandler : IQueryHandler<GetMessageByIdQuery, MessageQueryViewModel>
{
    private readonly IMessageReadRepository _messageRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public GetMessageByIdQueryHandler(
        IMessageReadRepository messageRepository,
        IInstaConnectMapper instaConnectMapper)
    {
        _messageRepository = messageRepository;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task<MessageQueryViewModel> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
    {
        var message = await _messageRepository.GetByIdAsync(request.Id, cancellationToken);

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

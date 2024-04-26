using AutoMapper;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Data.Abstractions.Repositories;
using InstaConnect.Shared.Business.Exceptions.Message;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Messages.Business.Queries.PostComments.GetPostCommentById
{
    public class GetMessageByIdQueryHandler : IQueryHandler<GetMessageByIdQuery, MessageViewDTO>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public GetMessageByIdQueryHandler(
            IMapper mapper,
            IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
        }

        public async Task<MessageViewDTO> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.GetByIdAsync(request.Id, cancellationToken);

            if (message == null)
            {
                throw new MessageNotFoundException();
            }

            var messageViewDTO = _mapper.Map<MessageViewDTO>(message);

            return messageViewDTO;
        }
    }
}

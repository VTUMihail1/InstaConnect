using AutoMapper;
using InstaConnect.Messages.Data.Abstractions.Repositories;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.RequestClients;

namespace InstaConnect.Messages.Business.Commands.PostComments.DeletePostComment
{
    public class DeleteMessageCommandHandler : ICommandHandler<DeleteMessageCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly IValidateUserByIdRequestClient _requestClient;

        public DeleteMessageCommandHandler(
            IMapper mapper,
            IMessageRepository messageRepository,
            IValidateUserByIdRequestClient requestClient)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _requestClient = requestClient;
        }

        public async Task Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var existingMessage = await _messageRepository.GetByIdAsync(request.Id, cancellationToken);

            if (existingMessage == null)
            {
                throw new MessageNotFoundException();
            }

            var validateUserByIdRequest = _mapper.Map<ValidateUserByIdRequest>(request);
            var validateUserByIdResponse = await _requestClient.GetResponse<ValidateUserByIdResponse>(validateUserByIdRequest, cancellationToken);

            if (!validateUserByIdResponse.Message.IsValid)
            {
                throw new AccountForbiddenException();
            }

            await _messageRepository.DeleteAsync(existingMessage, cancellationToken);
        }
    }
}

using AutoMapper;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Messages.Business.Abstract.Helpers;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Data.Abstractions.Repositories;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.RequestClients;

namespace InstaConnect.Messages.Business.Commands.PostComments.AddPostComment
{
    public class AddMessageCommandHandler : ICommandHandler<AddMessageCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMessageSender _messageSender;
        private readonly IMessageRepository _messageRepository;
        private readonly IGetUserByIdRequestClient _requestClient;

        public AddMessageCommandHandler(
            IMapper mapper,
            IMessageSender messageSender,
            IMessageRepository messageRepository,
            IGetUserByIdRequestClient requestClient)
        {
            _mapper = mapper;
            _messageSender = messageSender;
            _messageRepository = messageRepository;
            _requestClient = requestClient;
        }

        public async Task Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            var getUserByFollowerIdRequest = _mapper.Map<GetUserByIdRequest>(request);
            var getUserByFollowerIdResponse = await _requestClient.GetResponse<GetUserByIdResponse>(getUserByFollowerIdRequest, cancellationToken);

            if (!getUserByFollowerIdResponse.Message.Exists)
            {
                throw new UserNotFoundException();
            }

            var getUserByFollowingIdRequest = _mapper.Map<GetUserByIdRequest>(request);
            var getUserByFollowingIdResponse = await _requestClient.GetResponse<GetUserByIdResponse>(getUserByFollowingIdRequest, cancellationToken);

            if (!getUserByFollowingIdResponse.Message.Exists)
            {
                throw new UserNotFoundException();
            }

            var message = _mapper.Map<Message>(request);
            await _messageRepository.AddAsync(message, cancellationToken);

            var sendMessageDTO = _mapper.Map<SendMessageDTO>(request);
            await _messageSender.SendMessageToUserAsync(sendMessageDTO);
        }
    }
}

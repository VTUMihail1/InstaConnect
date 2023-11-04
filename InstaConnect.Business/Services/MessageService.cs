using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Follow;
using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IMessageRepository _messageRepository;
        private readonly IMessageSender _messageSender;
        private readonly IUserRepository _userRepository;
        private readonly IAccountManager _accountManager;

        public MessageService(
            IMapper mapper,
            IResultFactory resultFactory,
            IMessageRepository messageRepository,
            IMessageSender messageSender,
            IUserRepository userRepository,
            IAccountManager accountManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _messageRepository = messageRepository;
            _messageSender = messageSender;
            _userRepository = userRepository;
            _accountManager = accountManager;
        }

        public async Task<IResult<ICollection<MessageResultDTO>>> GetAllBySenderIdAndReceiverIdAsync(string senderId, string receiverId)
        {
            var existingMessage = await _messageRepository.GetAllAsync(m =>
            (m.SenderId == senderId || m.ReceiverId == senderId) &&
            (m.SenderId == receiverId || m.ReceiverId == receiverId));

            var messageResultDTO = _mapper.Map<ICollection<MessageResultDTO>>(existingMessage);
            var okResult = _resultFactory.GetOkResult(messageResultDTO);

            return okResult;
        }

        public async Task<IResult<MessageResultDTO>> GetByIdAsync(string senderId, string id)
        {
            var existingMessage = await _messageRepository.FindEntityAsync(m => m.Id == id);

            if (existingMessage == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<MessageResultDTO>();

                return notFoundResult;
            }

            var validUser = _accountManager.ValidateUser(senderId, existingMessage.SenderId);

            if (!validUser)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<MessageResultDTO>();

                return forbiddenResult;
            }

            var messageResultDTO = _mapper.Map<MessageResultDTO>(existingMessage);
            var okResult = _resultFactory.GetOkResult(messageResultDTO);

            return okResult;
        }

        public async Task<IResult<MessageResultDTO>> AddAsync(string senderId, MessageAddDTO messageAddDTO)
        {
            var validUser = _accountManager.ValidateUser(senderId, messageAddDTO.SenderId);

            if (!validUser)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<MessageResultDTO>();

                return forbiddenResult;
            }

            var existingSender = await _userRepository.FindEntityAsync(f => f.Id == messageAddDTO.SenderId);

            if (existingSender == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<MessageResultDTO>(InstaConnectErrorMessages.SenderNotFound);

                return badRequestResult;
            }

            var existingRecipient = await _userRepository.FindEntityAsync(f => f.Id == messageAddDTO.ReceiverId);

            if (existingRecipient == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<MessageResultDTO>(InstaConnectErrorMessages.ReceiverNotFound);

                return badRequestResult;
            }

            var message = _mapper.Map<Message>(messageAddDTO);
            await _messageRepository.AddAsync(message);

            await _messageSender.SendMessageToUserAsync(messageAddDTO.ReceiverId, messageAddDTO.Content);

            var noContentResult = _resultFactory.GetNoContentResult<MessageResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<MessageResultDTO>> UpdateAsync(string senderId, string id, MessageUpdateDTO messageUpdateDTO)
        {
            var existingMessage = await _messageRepository.FindEntityAsync(m => m.Id == id);

            if (existingMessage == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<MessageResultDTO>();

                return notFoundResult;
            }

            var validUser = _accountManager.ValidateUser(senderId, existingMessage.SenderId);

            if (!validUser)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<MessageResultDTO>();

                return forbiddenResult;
            }

            _mapper.Map(messageUpdateDTO, existingMessage);
            await _messageRepository.UpdateAsync(existingMessage);

            var noContentResult = _resultFactory.GetNoContentResult<MessageResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<MessageResultDTO>> DeleteAsync(string senderId, string id)
        {
            var existingMessage = await _messageRepository.FindEntityAsync(m => m.Id == id);

            if (existingMessage == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<MessageResultDTO>();

                return notFoundResult;
            }

            var validUser = _accountManager.ValidateUser(senderId, existingMessage.SenderId);

            if (!validUser)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<MessageResultDTO>();

                return forbiddenResult;
            }

            await _messageRepository.DeleteAsync(existingMessage);

            var noContentResult = _resultFactory.GetNoContentResult<MessageResultDTO>();

            return noContentResult;
        }

    }
}

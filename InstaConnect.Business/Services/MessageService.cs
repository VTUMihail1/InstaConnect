using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Extensions;
using InstaConnect.Business.Models.DTOs.CommentLike;
using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Business.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IMessageRepository _messageRepository;
        private readonly IMessageSender _messageSender;
        private readonly UserManager<User> _userManager;

        public MessageService(
            IMapper mapper,
            IResultFactory resultFactory,
            IMessageRepository messageRepository,
            IMessageSender messageSender,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _messageRepository = messageRepository;
            _messageSender = messageSender;
            _userManager = userManager;
        }

        public async Task<ICollection<MessageResultDTO>> GetAllAsync(string senderId, string receiverId)
        {
            var messages = await _messageRepository.GetAllAsync(m =>
            (senderId == default || m.SenderId == senderId) &&
            (receiverId == default || m.ReceiverId == receiverId));

            var messageResultDTOs = _mapper.Map<ICollection<MessageResultDTO>>(messages);

            return messageResultDTOs;
        }
        public async Task<IResult<MessageResultDTO>> GetByIdAsync(string id)
        {
            var existingMessage = await _messageRepository.FindEntityAsync(m => m.Id == id);

            if (existingMessage == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<MessageResultDTO>(InstaConnectErrorMessages.MessageNotFound);

                return notFoundResult;
            }

            var messageResultDTO = _mapper.Map<MessageResultDTO>(existingMessage);
            var okResult = _resultFactory.GetOkResult(messageResultDTO);

            return okResult;
        }

        public async Task<IResult<MessageResultDTO>> GetBySenderIdAndReceiverIdAsync(string senderId, string receiverId)
        {
            var existingMessage = await _messageRepository.FindEntityAsync(m => m.SenderId == senderId && m.ReceiverId == receiverId);

            if (existingMessage == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<MessageResultDTO>(InstaConnectErrorMessages.MessageNotFound);

                return notFoundResult;
            }

            var messageResultDTO = _mapper.Map<MessageResultDTO>(existingMessage);
            var okResult = _resultFactory.GetOkResult(messageResultDTO);

            return okResult;
        }

        public async Task<IResult<MessageResultDTO>> AddAsync(string currentUserId, MessageAddDTO messageAddDTO)
        {
            var doesNotHavePermission = !await _userManager.HasPermissionAsync(currentUserId, messageAddDTO.SenderId);

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<MessageResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            var existingRecipient = await _userManager.FindByIdAsync(messageAddDTO.ReceiverId);

            if (existingRecipient == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<MessageResultDTO>(InstaConnectErrorMessages.ReceiverNotFound);

                return badRequestResult;
            }

            var message = _mapper.Map<Message>(messageAddDTO);
            await _messageRepository.AddAsync(message);

            await _messageSender.SendMessageToUserAsync(messageAddDTO.ReceiverId, message.Content);

            var noContentResult = _resultFactory.GetNoContentResult<MessageResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<MessageResultDTO>> UpdateAsync(string currentUserId, string id, MessageUpdateDTO messageUpdateDTO)
        {
            var existingMessage = await _messageRepository.FindEntityAsync(m => m.Id == id);

            if (existingMessage == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<MessageResultDTO>(InstaConnectErrorMessages.MessageNotFound);

                return notFoundResult;
            }

            var doesNotHavePermission = !await _userManager.HasPermissionAsync(currentUserId, existingMessage.SenderId);

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<MessageResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            _mapper.Map(messageUpdateDTO, existingMessage);
            await _messageRepository.UpdateAsync(existingMessage);

            var noContentResult = _resultFactory.GetNoContentResult<MessageResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<MessageResultDTO>> DeleteBySenderIdAndReceiverIdAsync(string currentUserId, string senderId, string receiverId)
        {
            var doesNotHavePermission = !await _userManager.HasPermissionAsync(currentUserId, senderId);

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<MessageResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            var existingMessage = await _messageRepository.FindEntityAsync(m => m.SenderId == senderId && m.ReceiverId == receiverId);

            if (existingMessage == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<MessageResultDTO>(InstaConnectErrorMessages.MessageNotFound);

                return notFoundResult;
            }

            await _messageRepository.DeleteAsync(existingMessage);

            var noContentResult = _resultFactory.GetNoContentResult<MessageResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<MessageResultDTO>> DeleteAsync(string currentUserId, string id)
        {
            var existingMessage = await _messageRepository.FindEntityAsync(m => m.Id == id);

            if (existingMessage == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<MessageResultDTO>(InstaConnectErrorMessages.MessageNotFound);

                return notFoundResult;
            }

            var doesNotHavePermission = !await _userManager.HasPermissionAsync(currentUserId, existingMessage.SenderId);

            if (doesNotHavePermission)
            {
                var forbiddenResult = _resultFactory.GetForbiddenResult<MessageResultDTO>(InstaConnectErrorMessages.UserHasNoPermission);

                return forbiddenResult;
            }

            await _messageRepository.DeleteAsync(existingMessage);

            var noContentResult = _resultFactory.GetNoContentResult<MessageResultDTO>();

            return noContentResult;
        }

    }
}

using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
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

            public async Task<ICollection<MessageDetailedDTO>> GetAllDetailedAsync()
            {
                var messages = await _messageRepository.GetAllIncludedAsync();
                var messageDetailedDTOs = _mapper.Map<ICollection<MessageDetailedDTO>>(messages);

                return messageDetailedDTOs;
            }

            public async Task<ICollection<MessageDetailedDTO>> GetAllDetailedBySenderIdAsync(string senderId)
            {
                var messages = await _messageRepository.GetAllFilteredIncludedAsync(m => m.SenderId == senderId);
                var messageDetailedDTOs = _mapper.Map<ICollection<MessageDetailedDTO>>(messages);

                return messageDetailedDTOs;
            }

            public async Task<ICollection<MessageDetailedDTO>> GetAllDetailedByReceiverIdAsync(string receiverId)
            {
                var messages = await _messageRepository.GetAllFilteredIncludedAsync(m => m.ReceiverId == receiverId);
                var messageDetailedDTOs = _mapper.Map<ICollection<MessageDetailedDTO>>(messages);

                return messageDetailedDTOs;
            }

            public async Task<IResult<MessageDetailedDTO>> GetDetailedByIdAsync(string id)
            {
                var message = await _messageRepository.FindIncludedAsync(m => m.Id == id);

                if (message == null)
                {
                    var notFoundResult = _resultFactory.GetNotFoundResult<MessageDetailedDTO>(InstaConnectErrorMessages.MessageNotFound);

                    return notFoundResult;
                }

                var messageDetailedDTO = _mapper.Map<MessageDetailedDTO>(message);
                var okResult = _resultFactory.GetOkResult(messageDetailedDTO);

                return okResult;
            }

            public async Task<ICollection<MessageResultDTO>> GetAllAsync()
            {
                var messages = await _messageRepository.GetAllAsync();
                var messageResultDTOs = _mapper.Map<ICollection<MessageResultDTO>>(messages);

                return messageResultDTOs;
            }

            public async Task<ICollection<MessageResultDTO>> GetAllBySenderIdAsync(string senderId)
            {
                var messages = await _messageRepository.GetAllFilteredAsync(m => m.SenderId == senderId);
                var messageResultDTOs = _mapper.Map<ICollection<MessageResultDTO>>(messages);

                return messageResultDTOs;
            }

            public async Task<ICollection<MessageResultDTO>> GetAllByReceiverIdAsync(string receiverId)
            {
                var messages = await _messageRepository.GetAllFilteredAsync(m => m.ReceiverId == receiverId);
                var messageResultDTOs = _mapper.Map<ICollection<MessageResultDTO>>(messages);

                return messageResultDTOs;
            }

            public async Task<IResult<MessageResultDTO>> GetByIdAsync(string id)
            {
                var message = await _messageRepository.FindEntityAsync(m => m.Id == id);

                if (message == null)
                {
                    var notFoundResult = _resultFactory.GetNotFoundResult<MessageResultDTO>(InstaConnectErrorMessages.MessageNotFound);

                    return notFoundResult;
                }

                var messageResultDTO = _mapper.Map<MessageResultDTO>(message);
                var okResult = _resultFactory.GetOkResult(messageResultDTO);

                return okResult;
            }

        public async Task<IResult<MessageResultDTO>> AddAsync(MessageAddDTO messageAddDTO)
        {
            var existingSender = await _userManager.FindByIdAsync(messageAddDTO.SenderId);

            if (existingSender == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<MessageResultDTO>(InstaConnectErrorMessages.SenderNotFound);

                return badRequestResult;
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

        public async Task<IResult<MessageResultDTO>> UpdateAsync(string id, MessageUpdateDTO messageUpdateDTO)
        {
            var existingMessage = await _messageRepository.FindEntityAsync(m => m.Id == id);

            if (existingMessage == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<MessageResultDTO>(InstaConnectErrorMessages.MessageNotFound);

                return notFoundResult;
            }

            _mapper.Map(messageUpdateDTO, existingMessage);
            await _messageRepository.UpdateAsync(existingMessage);

            var noContentResult = _resultFactory.GetNoContentResult<MessageResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<MessageResultDTO>> DeleteAsync(string id)
        {
            var existingMessage = await _messageRepository.FindEntityAsync(m => m.Id == id);

            if (existingMessage == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<MessageResultDTO>(InstaConnectErrorMessages.MessageNotFound);

                return notFoundResult;
            }

            await _messageRepository.DeleteAsync(existingMessage);

            var noContentResult = _resultFactory.GetNoContentResult<MessageResultDTO>();

            return noContentResult;
        }

    }
}

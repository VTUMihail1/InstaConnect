using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
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
        private readonly UserManager<User> _userManager;

        public MessageService(
            IMapper mapper,
            IResultFactory resultFactory,
            IMessageRepository messageRepository,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _messageRepository = messageRepository;
            _userManager = userManager;
        }

        public async Task<ICollection<MessageResultDTO>> GetAllBySenderIdAsync(string senderId)
        {
            var messages = await _messageRepository.GetAllFilteredAsync(p => p.SenderId == senderId);
            var messageResultDTOs = _mapper.Map<ICollection<MessageResultDTO>>(messages);

            return messageResultDTOs;
        }

        public async Task<ICollection<MessageResultDTO>> GetAllByReceiverIdAsync(string receiverId)
        {
            var messages = await _messageRepository.GetAllFilteredAsync(p => p.ReceiverId == receiverId);
            var messageResultDTOs = _mapper.Map<ICollection<MessageResultDTO>>(messages);

            return messageResultDTOs;
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

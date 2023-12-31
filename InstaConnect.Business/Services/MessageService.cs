﻿using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
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
        private readonly IInstaConnectUserManager _instaConnectUserManager;

        public MessageService(
            IMapper mapper,
            IResultFactory resultFactory,
            IMessageRepository messageRepository,
            IMessageSender messageSender,
            IInstaConnectUserManager instaConnectUserManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _messageRepository = messageRepository;
            _messageSender = messageSender;
            _instaConnectUserManager = instaConnectUserManager;
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

        public async Task<IResult<MessageResultDTO>> GetByIdAsync(string userId, string id)
        {
            var existingMessage = await _messageRepository.FindEntityAsync(m => m.Id == id && m.SenderId == userId);

            if (existingMessage == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<MessageResultDTO>();

                return notFoundResult;
            }

            var messageResultDTO = _mapper.Map<MessageResultDTO>(existingMessage);
            var okResult = _resultFactory.GetOkResult(messageResultDTO);

            return okResult;
        }

        public async Task<IResult<MessageResultDTO>> AddAsync(MessageAddDTO messageAddDTO)
        {
            var existingSender = await _instaConnectUserManager.FindByIdAsync(messageAddDTO.SenderId);

            if (existingSender == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<MessageResultDTO>(InstaConnectErrorMessages.SenderNotFound);

                return badRequestResult;
            }

            var existingRecipient = await _instaConnectUserManager.FindByIdAsync(messageAddDTO.ReceiverId);

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

        public async Task<IResult<MessageResultDTO>> UpdateAsync(string userId, string id, MessageUpdateDTO messageUpdateDTO)
        {
            var existingMessage = await _messageRepository.FindEntityAsync(m => m.Id == id && m.SenderId == userId);

            if (existingMessage == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<MessageResultDTO>();

                return notFoundResult;
            }

            _mapper.Map(messageUpdateDTO, existingMessage);
            await _messageRepository.UpdateAsync(existingMessage);

            var noContentResult = _resultFactory.GetNoContentResult<MessageResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<MessageResultDTO>> DeleteAsync(string userId, string id)
        {
            var existingMessage = await _messageRepository.FindEntityAsync(m => m.Id == id && m.SenderId == userId);

            if (existingMessage == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<MessageResultDTO>();

                return notFoundResult;
            }

            await _messageRepository.DeleteAsync(existingMessage);

            var noContentResult = _resultFactory.GetNoContentResult<MessageResultDTO>();

            return noContentResult;
        }

    }
}

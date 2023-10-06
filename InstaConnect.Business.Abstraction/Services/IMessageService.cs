﻿using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing messages.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Retrieves a message by its unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user performing the action.</param>
        /// <param name="id">The unique identifier of the message.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a <see cref="MessageResultDTO"/>.</returns>
        Task<IResult<MessageResultDTO>> GetByIdAsync(string userId, string id);

        /// <summary>
        /// Adds a new message.
        /// </summary>
        /// <param name="messageAddDTO">The data for the new message.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the added <see cref="MessageResultDTO"/>.</returns>
        Task<IResult<MessageResultDTO>> AddAsync(MessageAddDTO messageAddDTO);

        /// <summary>
        /// Updates an existing message by its unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user performing the action.</param>
        /// <param name="id">The unique identifier of the message to update.</param>
        /// <param name="messageUpdateDTO">The data to update the message with.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the updated <see cref="MessageResultDTO"/>.</returns>
        Task<IResult<MessageResultDTO>> UpdateAsync(string userId, string id, MessageUpdateDTO messageUpdateDTO);

        /// <summary>
        /// Deletes a message by its unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user performing the action.</param>
        /// <param name="id">The unique identifier of the message to delete.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the deleted <see cref="MessageResultDTO"/>.</returns>
        Task<IResult<MessageResultDTO>> DeleteAsync(string userId, string id);
    }
}

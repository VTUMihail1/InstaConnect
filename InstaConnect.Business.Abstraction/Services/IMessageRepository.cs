using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing user messages.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Retrieves all user messages based on the sender's ID asynchronously.
        /// </summary>
        /// <param name="senderId">The ID of the sender user.</param>
        /// <returns>A collection of message results.</returns>
        Task<ICollection<MessageResultDTO>> GetAllBySenderIdAsync(string senderId);

        /// <summary>
        /// Retrieves all user messages based on the receiver user's ID asynchronously.
        /// </summary>
        /// <param name="receiverId">The ID of the receiver user.</param>
        /// <returns>A collection of message results.</returns>
        Task<ICollection<MessageResultDTO>> GetAllByReceiverIdAsync(string receiverId);

        /// <summary>
        /// Adds a new message asynchronously.
        /// </summary>
        /// <param name="messageAddDTO">The data for adding a new message.</param>
        /// <returns>The result of the message addition operation.</returns>
        Task<IResult<MessageResultDTO>> AddAsync(MessageAddDTO messageAddDTO);

        /// <summary>
        /// Updates an existing message asynchronously.
        /// </summary>
        /// <param name="id">The ID of the message to update.</param>
        /// <param name="messageUpdateDTO">The data for updating the message.</param>
        /// <returns>The result of the message update operation.</returns>
        Task<IResult<MessageResultDTO>> UpdateAsync(string id, MessageUpdateDTO messageUpdateDTO);

        /// <summary>
        /// Deletes a message asynchronously.
        /// </summary>
        /// <param name="id">The ID of the message to delete.</param>
        /// <returns>The result of the message deletion operation.</returns>
        Task<IResult<MessageResultDTO>> DeleteAsync(string id);
    }
}

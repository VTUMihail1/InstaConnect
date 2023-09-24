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
        /// Retrieves all messages with detailed information.
        /// </summary>
        /// <returns>A collection of detailed message information.</returns>
        Task<ICollection<MessageDetailedDTO>> GetAllDetailedAsync();

        /// <summary>
        /// Retrieves all messages sent by the sender with detailed information.
        /// </summary>
        /// <param name="senderId">The sender's ID to filter by.</param>
        /// <returns>A collection of detailed message information.</returns>
        Task<ICollection<MessageDetailedDTO>> GetAllDetailedBySenderIdAsync(string senderId);

        /// <summary>
        /// Retrieves all messages received by the receiver with detailed information.
        /// </summary>
        /// <param name="receiverId">The receiver's ID to filter by.</param>
        /// <returns>A collection of detailed message information.</returns>
        Task<ICollection<MessageDetailedDTO>> GetAllDetailedByReceiverIdAsync(string receiverId);

        /// <summary>
        /// Retrieves a message by its ID with detailed information.
        /// </summary>
        /// <param name="id">The ID of the message to retrieve.</param>
        /// <returns>The detailed message information or a not-found result.</returns>
        Task<IResult<MessageDetailedDTO>> GetDetailedByIdAsync(string id);

        /// <summary>
        /// Retrieves all messages.
        /// </summary>
        /// <returns>A collection of message information.</returns>
        Task<ICollection<MessageResultDTO>> GetAllAsync();

        /// <summary>
        /// Retrieves all messages sent by the sender.
        /// </summary>
        /// <param name="senderId">The sender's ID to filter by.</param>
        /// <returns>A collection of message information.</returns>
        Task<ICollection<MessageResultDTO>> GetAllBySenderIdAsync(string senderId);

        /// <summary>
        /// Retrieves all messages received by the receiver.
        /// </summary>
        /// <param name="receiverId">The receiver's ID to filter by.</param>
        /// <returns>A collection of message information.</returns>
        Task<ICollection<MessageResultDTO>> GetAllByReceiverIdAsync(string receiverId);

        /// <summary>
        /// Retrieves a message by its ID.
        /// </summary>
        /// <param name="id">The ID of the message to retrieve.</param>
        /// <returns>The message information or a not-found result.</returns>
        Task<IResult<MessageResultDTO>> GetByIdAsync(string id);

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

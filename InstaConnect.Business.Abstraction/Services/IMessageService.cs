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
        /// Retrieves detailed message information by sender ID and receiver ID asynchronously.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        /// <returns>
        /// An asynchronous task that returns a result containing the detailed message information
        /// or an appropriate result based on the outcome of the operation.
        /// </returns>
        Task<IResult<MessageDetailedDTO>> GetDetailedBySenderIdAndReceiverIdAsync(string senderId, string receiverId);

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
        /// Retrieves message information by sender ID and receiver ID asynchronously.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        /// <returns>
        /// An asynchronous task that returns a result containing the message information
        /// or an appropriate result based on the outcome of the operation.
        /// </returns>
        Task<IResult<MessageResultDTO>> GetBySenderIdAndReceiverIdAsync(string senderId, string receiverId);

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
        /// Deletes messages by sender ID and receiver ID asynchronously.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        /// <returns>
        /// An asynchronous task that returns a result indicating the success or failure of the delete operation.
        /// </returns>
        Task<IResult<MessageResultDTO>> DeleteBySenderIdAndReceiverIdAsync(string senderId, string receiverId);

        /// <summary>
        /// Deletes a message asynchronously.
        /// </summary>
        /// <param name="id">The ID of the message to delete.</param>
        /// <returns>The result of the message deletion operation.</returns>
        Task<IResult<MessageResultDTO>> DeleteAsync(string id);
    }
}

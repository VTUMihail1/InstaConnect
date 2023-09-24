using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Provides methods for managing messages.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Gets all messages asynchronously.
        /// </summary>
        /// <returns>A collection of message results.</returns>
        Task<ICollection<MessageResultDTO>> GetAllAsync();

        /// <summary>
        /// Gets all messages sent by a specific sender asynchronously.
        /// </summary>
        /// <param name="senderId">The unique identifier of the sender.</param>
        /// <returns>A collection of message results.</returns>
        Task<ICollection<MessageResultDTO>> GetAllBySenderIdAsync(string senderId);

        /// <summary>
        /// Gets all messages received by a specific receiver asynchronously.
        /// </summary>
        /// <param name="receiverId">The unique identifier of the receiver.</param>
        /// <returns>A collection of message results.</returns>
        Task<ICollection<MessageResultDTO>> GetAllByReceiverIdAsync(string receiverId);

        /// <summary>
        /// Gets a message by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the message.</param>
        /// <returns>A result containing the message.</returns>
        Task<IResult<MessageResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Gets a message by sender and receiver identifiers asynchronously.
        /// </summary>
        /// <param name="senderId">The unique identifier of the sender.</param>
        /// <param name="receiverId">The unique identifier of the receiver.</param>
        /// <returns>A result containing the message.</returns>
        Task<IResult<MessageResultDTO>> GetBySenderIdAndReceiverIdAsync(string senderId, string receiverId);

        /// <summary>
        /// Adds a new message asynchronously.
        /// </summary>
        /// <param name="messageAddDTO">The data for creating a new message.</param>
        /// <returns>A result containing the newly created message.</returns>
        Task<IResult<MessageResultDTO>> AddAsync(MessageAddDTO messageAddDTO);

        /// <summary>
        /// Updates a message by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the message.</param>
        /// <param name="messageUpdateDTO">The data for updating the message.</param>
        /// <returns>A result containing the updated message.</returns>
        Task<IResult<MessageResultDTO>> UpdateAsync(string id, MessageUpdateDTO messageUpdateDTO);

        /// <summary>
        /// Deletes messages by sender and receiver identifiers asynchronously.
        /// </summary>
        /// <param name="senderId">The unique identifier of the sender.</param>
        /// <param name="receiverId">The unique identifier of the receiver.</param>
        /// <returns>A result indicating the success of the operation.</returns>
        Task<IResult<MessageResultDTO>> DeleteBySenderIdAndReceiverIdAsync(string senderId, string receiverId);

        /// <summary>
        /// Deletes a message by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the message.</param>
        /// <returns>A result indicating the success of the operation.</returns>
        Task<IResult<MessageResultDTO>> DeleteAsync(string id);
    }
}

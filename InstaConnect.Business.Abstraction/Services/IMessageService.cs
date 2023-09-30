using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing messages.
    /// </summary>
    public interface IMessageService
    {
		/// <summary>
		/// Retrieves all messages between a sender and a receiver with pagination.
		/// </summary>
		/// <param name="senderId">The ID of the message sender.</param>
		/// <param name="receiverId">The ID of the message receiver.</param>
		/// <param name="page">The page number.</param>
		/// <param name="amount">The number of messages to retrieve per page.</param>
		/// <returns>An <see cref="Task"/> representing the asynchronous operation, containing a collection of <see cref="MessageResultDTO"/>.</returns>
		Task<ICollection<MessageResultDTO>> GetAllAsync(string senderId, string receiverId, int page, int amount);

		/// <summary>
		/// Retrieves a message by its unique identifier.
		/// </summary>
		/// <param name="id">The unique identifier of the message.</param>
		/// <returns>An <see cref="IResult{T}"/> containing a <see cref="MessageResultDTO"/>.</returns>
		Task<IResult<MessageResultDTO>> GetByIdAsync(string id);

        /// <summary>
        /// Retrieves a message by sender ID and receiver ID.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        /// <returns>An <see cref="IResult{T}"/> containing a <see cref="MessageResultDTO"/>.</returns>
        Task<IResult<MessageResultDTO>> GetBySenderIdAndReceiverIdAsync(string senderId, string receiverId);

        /// <summary>
        /// Adds a new message.
        /// </summary>
        /// <param name="currentUserId">The ID of the current user performing the action.</param>
        /// <param name="messageAddDTO">The data for the new message.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the added <see cref="MessageResultDTO"/>.</returns>
        Task<IResult<MessageResultDTO>> AddAsync(string currentUserId, MessageAddDTO messageAddDTO);

        /// <summary>
        /// Updates an existing message by its unique identifier.
        /// </summary>
        /// <param name="currentUserId">The ID of the current user performing the action.</param>
        /// <param name="id">The unique identifier of the message to update.</param>
        /// <param name="messageUpdateDTO">The data to update the message with.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the updated <see cref="MessageResultDTO"/>.</returns>
        Task<IResult<MessageResultDTO>> UpdateAsync(string currentUserId, string id, MessageUpdateDTO messageUpdateDTO);

        /// <summary>
        /// Deletes all messages between a sender and a receiver.
        /// </summary>
        /// <param name="currentUserId">The ID of the current user performing the action.</param>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the deleted <see cref="MessageResultDTO"/>.</returns>
        Task<IResult<MessageResultDTO>> DeleteBySenderIdAndReceiverIdAsync(string currentUserId, string senderId, string receiverId);

        /// <summary>
        /// Deletes a message by its unique identifier.
        /// </summary>
        /// <param name="currentUserId">The ID of the current user performing the action.</param>
        /// <param name="id">The unique identifier of the message to delete.</param>
        /// <returns>An <see cref="IResult{T}"/> containing the deleted <see cref="MessageResultDTO"/>.</returns>
        Task<IResult<MessageResultDTO>> DeleteAsync(string currentUserId, string id);
    }
}

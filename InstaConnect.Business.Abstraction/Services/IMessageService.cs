using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    /// <summary>
    /// Represents an interface for managing and retrieving messages between users.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Asynchronously retrieves a collection of messages sent from a sender to a receiver user.
        /// </summary>
        /// <param name="senderId">The ID of the sender user.</param>
        /// <param name="receiverId">The ID of the receiver user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="ICollection{MessageResultDTO}"/> with the messages sent from the sender to the receiver.</returns>
        Task<IResult<ICollection<MessageResultDTO>>> GetAllBySenderIdAndReceiverIdAsync(string senderId, string receiverId);

        /// <summary>
        /// Asynchronously retrieves a message by its unique identifier, sent by the specified sender user.
        /// </summary>
        /// <param name="senderId">The ID of the sender user.</param>
        /// <param name="id">The unique identifier of the message to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="MessageResultDTO"/> with the message details.</returns>
        Task<IResult<MessageResultDTO>> GetByIdAsync(string senderId, string id);

        /// <summary>
        /// Asynchronously adds a new message sent by the sender user to the receiver user.
        /// </summary>
        /// <param name="senderId">The ID of the sender user.</param>
        /// <param name="messageAddDTO">The data for creating the message.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="MessageResultDTO"/> with the result of the message creation.</returns>
        Task<IResult<MessageResultDTO>> AddAsync(string senderId, MessageAddDTO messageAddDTO);

        /// <summary>
        /// Asynchronously updates a message sent by the sender user, based on the message's unique identifier.
        /// </summary>
        /// <param name="senderId">The ID of the sender user.</param>
        /// <param name="id">The unique identifier of the message to update.</param>
        /// <param name="messageUpdateDTO">The data for updating the message.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="MessageResultDTO"/> with the result of the message update.</returns>
        Task<IResult<MessageResultDTO>> UpdateAsync(string senderId, string id, MessageUpdateDTO messageUpdateDTO);

        /// <summary>
        /// Asynchronously deletes a message sent by the sender user, based on the message's unique identifier.
        /// </summary>
        /// <param name="senderId">The ID of the sender user.</param>
        /// <param name="id">The unique identifier of the message to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IResult{T}"/> of type <see cref="MessageResultDTO"/> with the result of the message deletion.</returns>
        Task<IResult<MessageResultDTO>> DeleteAsync(string senderId, string id);
    }
}

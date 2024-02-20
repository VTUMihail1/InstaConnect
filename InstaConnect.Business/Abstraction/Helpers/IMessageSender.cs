namespace InstaConnect.Business.Abstraction.Helpers
{
    /// <summary>
    /// Represents a service for sending messages to users.
    /// </summary>
    public interface IMessageSender
    {
        /// <summary>
        /// Sends a message to a user asynchronously.
        /// </summary>
        /// <param name="userId">The ID of the user to whom the message will be sent.</param>
        /// <param name="content">The content of the message to be sent.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        Task SendMessageToUserAsync(string userId, string content);
    }
}
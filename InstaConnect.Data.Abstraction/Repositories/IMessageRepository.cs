using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;
using System.Linq.Expressions;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing messages, inheriting from the generic repository for entities of type <see cref="Message"/>.
    /// </summary>
    public interface IMessageRepository : IRepository<Message>
    {
        /// <summary>
        /// Retrieves all messages, including related entities.
        /// </summary>
        /// <returns>A collection of messages with related entities included.</returns>
        Task<ICollection<Message>> GetAllIncludedAsync();

        /// <summary>
        /// Retrieves all messages that satisfy a specified filter expression, including related entities.
        /// </summary>
        /// <param name="expression">The filter expression used to select messages.</param>
        /// <returns>A collection of filtered messages with related entities included.</returns>
        Task<ICollection<Message>> GetAllFilteredIncludedAsync(Expression<Func<Message, bool>> expression);

        /// <summary>
        /// Finds and retrieves a message that matches the specified filter expression, including related entities, asynchronously.
        /// </summary>
        /// <param name="expression">The filter expression used to select the message.</param>
        /// <returns>A task representing the asynchronous operation, which upon completion returns the message that satisfies the provided filter, with related entities included.</returns>
        Task<Message> FindMessageIncludedAsync(Expression<Func<Message, bool>> expression);
        // Additional methods for managing Messages can be added here with appropriate documentation.
    }

}

using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InstaConnect.Data.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly InstaConnectContext _instaConnectContext;

        public MessageRepository(InstaConnectContext instaConnectContext) : base(instaConnectContext)
        {
            _instaConnectContext = instaConnectContext;
        }

        public async Task<ICollection<Message>> GetAllIncludedAsync()
        {
            var messages = await _instaConnectContext.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .ToListAsync();

            return messages;
        }

        public async Task<ICollection<Message>> GetAllFilteredIncludedAsync(Expression<Func<Message, bool>> expression)
        {
            var messages = await _instaConnectContext.Messages
                .Where(expression)
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .ToListAsync();

            return messages;
        }

        public async Task<Message> FindIncludedAsync(Expression<Func<Message, bool>> expression)
        {
            var message = await _instaConnectContext.Messages
                .Where(expression)
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .FirstOrDefaultAsync(expression);

            return message;
        }
    }
}

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

        public override async Task<ICollection<Message>> GetAllAsync(
			Expression<Func<Message, bool>> expression,
			int skipAmount = default,
			int takeAmount = int.MaxValue)
		{
            var messages = await _instaConnectContext.Messages
                .Where(expression)
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
				.Skip(skipAmount)
				.Take(takeAmount)
				.ToListAsync();

            return messages;
        }

        public override async Task<Message> FindEntityAsync(Expression<Func<Message, bool>> expression)
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

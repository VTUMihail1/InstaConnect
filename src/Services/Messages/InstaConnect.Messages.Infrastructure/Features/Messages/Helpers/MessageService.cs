using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Messages.Infrastructure.Features.Messages.Helpers;
internal class MessageService : IMessageService
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public MessageService(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public void Update(Message message, string content)
    {
        var utcNow = _dateTimeProvider.GetUtcNow();
        message.Update(content, utcNow);
    }
}

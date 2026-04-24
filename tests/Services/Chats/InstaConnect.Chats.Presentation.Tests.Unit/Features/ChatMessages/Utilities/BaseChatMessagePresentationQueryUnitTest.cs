using InstaConnect.Chats.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationQueryUnitTest : BaseChatMessageTest
{
    protected IApplicationSender Sender { get; }

    protected IApplicationMapper Mapper { get; }

    protected BaseChatMessagePresentationQueryUnitTest()
    {
        Sender = MockFactory.CreateApplicationSender();
        Mapper = MockFactory.CreateMapper(ChatsPresentationReference.Assembly);
    }
}

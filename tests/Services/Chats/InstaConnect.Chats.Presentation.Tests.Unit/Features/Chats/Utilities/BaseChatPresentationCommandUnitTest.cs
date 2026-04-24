using InstaConnect.Chats.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.Chats.Utilities;

public abstract class BaseChatPresentationCommandUnitTest : BaseChatTest
{
    protected IApplicationSender Sender { get; }

    protected IApplicationMapper Mapper { get; }

    protected BaseChatPresentationCommandUnitTest()
    {
        Sender = MockFactory.CreateApplicationSender();
        Mapper = MockFactory.CreateMapper(ChatsPresentationReference.Assembly);
    }
}

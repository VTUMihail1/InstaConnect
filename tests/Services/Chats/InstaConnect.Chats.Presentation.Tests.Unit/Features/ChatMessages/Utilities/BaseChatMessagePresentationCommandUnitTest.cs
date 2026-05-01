using InstaConnect.Chats.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationCommandUnitTest : BaseChatMessageTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseChatMessagePresentationCommandUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(ChatsPresentationReference.Assembly);
	}
}

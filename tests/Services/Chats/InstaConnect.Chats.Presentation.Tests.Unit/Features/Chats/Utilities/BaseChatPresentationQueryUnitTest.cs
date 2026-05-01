using InstaConnect.Chats.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Unit.Features.Chats.Utilities;

public abstract class BaseChatPresentationQueryUnitTest : BaseChatTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseChatPresentationQueryUnitTest()
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(ChatsPresentationReference.Assembly);
	}
}

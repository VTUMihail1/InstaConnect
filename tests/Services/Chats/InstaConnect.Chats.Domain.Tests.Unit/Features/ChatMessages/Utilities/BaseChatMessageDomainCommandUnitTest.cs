using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Common.Extensions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Tests.Features.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageDomainCommandUnitTest : BaseChatMessageTest
{
	protected IApplicationMapper Mapper { get; }

	protected IGuidProvider GuidProvider { get; }

	protected IChatMessageFactory Factory { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IChatCommandRepository Repository { get; }

	protected IChatMessageCommandRepository MessageRepository { get; }

	protected IChatMessageNotificationService NotificationService { get; }

	protected IChatIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IChatMessageIncludeBuilderFactory MessageIncludeBuilderFactory { get; }

	protected BaseChatMessageDomainCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(ChatsDomainReference.Assembly);
		GuidProvider = DomainMockFactory.CreateGuidProvider();
		Factory = ChatMessageDomainMockFactory.CreateFactory();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		Repository = ChatDomainMockFactory.CreateCommandRepository();
		MessageRepository = ChatMessageDomainMockFactory.CreateCommandRepository();
		NotificationService = ChatMessageDomainMockFactory.CreateNotificationService();
		IncludeBuilderFactory = ChatMessageDomainMockFactory.CreateChatIncludeBuilderFactory();
		MessageIncludeBuilderFactory = ChatMessageDomainMockFactory.CreateIncludeBuilderFactory();
	}
}

using InstaConnect.Chats.Application.Extensions;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.Chats.Utilities;

public abstract class BaseChatApplicationCommandUnitTest : BaseChatTest
{
    protected IApplicationMapper Mapper { get; }

    protected IChatCommandService Service { get; }

    protected BaseChatApplicationCommandUnitTest()
    {
        Mapper = MockFactory.CreateMapper(ChatApplicationReference.Assembly);
        Service = ChatMockFactory.CreateCommandService();
    }
}

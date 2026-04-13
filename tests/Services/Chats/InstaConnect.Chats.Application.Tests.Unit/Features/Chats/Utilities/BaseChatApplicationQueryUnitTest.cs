using InstaConnect.Chats.Application.Extensions;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.Chats.Utilities;

public abstract class BaseChatApplicationQueryUnitTest : BaseChatTest
{
    protected IApplicationMapper Mapper { get; }

    protected IChatQueryService Service { get; }

    protected BaseChatApplicationQueryUnitTest()
    {
        Mapper = MockFactory.CreateMapper(ChatApplicationReference.Assembly);
        Service = ChatMockFactory.CreateQueryService();
    }
}

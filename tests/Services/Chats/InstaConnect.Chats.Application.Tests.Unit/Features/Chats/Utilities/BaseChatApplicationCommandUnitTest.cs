using InstaConnect.Chats.Application.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.Chats.Utilities;

public abstract class BaseChatApplicationCommandUnitTest : BaseChatTest
{
    protected IApplicationMapper Mapper { get; }

    protected IChatCommandService Service { get; }

    protected BaseChatApplicationCommandUnitTest()
    {
        Mapper = MockFactory.CreateMapper(ChatsApplicationReference.Assembly);
        Service = ChatMockFactory.CreateCommandService();
    }
}

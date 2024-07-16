using AutoMapper;
using Bogus;
using InstaConnect.Messages.Write.Business.Abstract;
using InstaConnect.Messages.Write.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Write.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Write.Business.Models;
using InstaConnect.Messages.Write.Business.Utilities;
using InstaConnect.Messages.Write.Data.Abstractions;
using InstaConnect.Messages.Write.Web.Models.Requests.Messages;
using InstaConnect.Messages.Write.Web.Profiles;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Models.Users;
using InstaConnect.Shared.Web.UnitTests.Utilities;
using NSubstitute;

namespace InstaConnect.Messages.Write.Business.UnitTests.Utilities;

public abstract class BaseMessageUnitTest : BaseUnitTest
{
    protected readonly string AddContent;
    protected readonly string UpdateContent;


    protected IInstaConnectSender InstaConnectSender { get; }

    protected ICurrentUserContext CurrentUserContext { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    public BaseMessageUnitTest()
    {
        AddContent = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CONTENT_MAX_LENGTH + MessageBusinessConfigurations.CONTENT_MIN_LENGTH) / 2);
        UpdateContent = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CONTENT_MAX_LENGTH + MessageBusinessConfigurations.CONTENT_MIN_LENGTH) / 2);

        InstaConnectSender = Substitute.For<IInstaConnectSender>();
        CurrentUserContext = Substitute.For<ICurrentUserContext>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                cfg.AddProfile(new MessagesWebProfile()))));

        CurrentUserContext.GetCurrentUser().Returns(new CurrentUserModel
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
        });

        InstaConnectSender.SendAsync(Arg.Any<AddMessageCommand>(), CancellationToken).Returns(new MessageViewModel
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
        });

        InstaConnectSender.SendAsync(Arg.Any<UpdateMessageCommand>(), CancellationToken).Returns(new MessageViewModel
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
        });
    }
}

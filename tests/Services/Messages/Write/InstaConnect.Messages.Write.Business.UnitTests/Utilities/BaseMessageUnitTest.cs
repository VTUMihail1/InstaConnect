using System.Linq.Expressions;
using AutoMapper;
using Bogus;
using InstaConnect.Messages.Write.Business.Abstract;
using InstaConnect.Messages.Write.Business.Profiles;
using InstaConnect.Messages.Write.Business.Utilities;
using InstaConnect.Messages.Write.Data.Abstractions;
using InstaConnect.Messages.Write.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace InstaConnect.Messages.Write.Business.UnitTests.Utilities;

public abstract class BaseMessageUnitTest : BaseUnitTest
{
    protected readonly string ValidId;
    protected readonly string ValidReceiverId;
    protected readonly string ValidContent;
    protected readonly string ValidCurrentUserId;

    protected IUnitOfWork UnitOfWork { get; }

    protected IMessageSender MessageSender { get; }

    protected IEventPublisher EventPublisher { get; }

    protected IMessageRepository MessageRepository { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected ConsumeContext<UserDeletedEvent> UserDeletedEventConsumeContext { get; }

    protected Expression<Func<Message, bool>> ExpectedUserDeletedEventExpression { get; }

    protected IInstaConnectRequestClient<GetUserByIdRequest> GetUserByIdRequestClient { get; }

    public BaseMessageUnitTest()
    {
        var getUserBySenderIdResponse = new GetUserByIdResponse
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME
        };

        var getUserByReceiverIdResponse = new GetUserByIdResponse
        {
            Id = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            UserName = MessageUnitTestConfigurations.EXISTING_RECEIVER_NAME
        };

        UnitOfWork = Substitute.For<IUnitOfWork>();
        MessageSender = Substitute.For<IMessageSender>();
        EventPublisher = Substitute.For<IEventPublisher>();
        MessageRepository = Substitute.For<IMessageRepository>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                cfg.AddProfile(new MessagesBusinessProfile()))));

        UserDeletedEventConsumeContext = Substitute.For<ConsumeContext<UserDeletedEvent>>();
        ExpectedUserDeletedEventExpression = p => p.SenderId == MessageUnitTestConfigurations.EXISTING_SENDER_ID;
        GetUserByIdRequestClient = CreateUserByIdRequestClient(getUserBySenderIdResponse, getUserByReceiverIdResponse);

        ValidId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.ID_MAX_LENGTH + MessageBusinessConfigurations.ID_MIN_LENGTH) / 2);
        ValidReceiverId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH) / 2);
        ValidContent = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CONTENT_MAX_LENGTH + MessageBusinessConfigurations.CONTENT_MIN_LENGTH) / 2);
        ValidCurrentUserId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH) / 2);

        MessageRepository.When(x => x.Add(Arg.Is<Message>(m => m.SenderId == MessageUnitTestConfigurations.EXISTING_SENDER_ID &&
                                                               m.ReceiverId == MessageUnitTestConfigurations.EXISTING_RECEIVER_ID &&
                                                               m.Content == ValidContent)))
                         .Do(ci =>
                              {
                                  var message = ci.Arg<Message>();
                                  message.Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID;
                              });

        MessageRepository.GetByIdAsync(
            MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CancellationToken)
            .Returns(new Message()
            {
                Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
                SenderId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
                ReceiverId = MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID,
                Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
            });
    }
}

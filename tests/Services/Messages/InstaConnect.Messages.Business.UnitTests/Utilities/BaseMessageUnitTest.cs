using System.Linq.Expressions;
using AutoMapper;
using Bogus;
using InstaConnect.Messages.Business.Abstract;
using InstaConnect.Messages.Business.Profiles;
using InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Messages.Data.Models.Filters;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Utilities;

public abstract class BaseMessageUnitTest : BaseUnitTest
{
    protected readonly int ValidPageValue;
    protected readonly int ValidPageSizeValue;

    protected readonly string ValidId;
    protected readonly string ValidContent;
    protected readonly string ValidReceiverId;
    protected readonly string ValidReceiverName;
    protected readonly string ValidSortOrderName;
    protected readonly string ValidCurrentUserId;
    protected readonly string ValidSortPropertyName;

    protected IUnitOfWork UnitOfWork { get; }

    protected IMessageSender MessageSender { get; }

    protected IEnumValidator EnumValidator { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IUserReadRepository UserReadRepository { get; }

    protected IUserWriteRepository UserWriteRepository { get; }

    protected IMessageReadRepository MessageReadRepository { get; }

    protected IMessageWriteRepository MessageWriteRepository { get; }

    protected IEntityPropertyValidator EntityPropertyValidator { get; }

    public BaseMessageUnitTest()
    {
        ValidPageValue = (MessageBusinessConfigurations.PAGE_MAX_VALUE + MessageBusinessConfigurations.PAGE_MIN_VALUE) / 2;
        ValidPageSizeValue = (MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE + MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE) / 2;

        ValidId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.ID_MAX_LENGTH + MessageBusinessConfigurations.ID_MIN_LENGTH) / 2);
        ValidContent = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CONTENT_MAX_LENGTH + MessageBusinessConfigurations.CONTENT_MIN_LENGTH) / 2);
        ValidReceiverId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH) / 2);
        ValidReceiverName = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH + MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH) / 2);
        ValidCurrentUserId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH) / 2);
        ValidSortOrderName = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.SORT_ORDER_MAX_LENGTH + MessageBusinessConfigurations.SORT_ORDER_MIN_LENGTH) / 2);
        ValidSortPropertyName = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.SORT_PROPERTY_NAME_MAX_LENGTH + MessageBusinessConfigurations.SORT_PROPERTY_NAME_MIN_LENGTH) / 2);

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
        EnumValidator = new EnumValidator();
        UserReadRepository = Substitute.For<IUserReadRepository>();
        UserWriteRepository = Substitute.For<IUserWriteRepository>();
        MessageSender = Substitute.For<IMessageSender>();
        MessageReadRepository = Substitute.For<IMessageReadRepository>();
        MessageWriteRepository = Substitute.For<IMessageWriteRepository>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                cfg.AddProfile(new MessagesQueryProfile()))));

        EntityPropertyValidator = new EntityPropertyValidator();

        MessageWriteRepository.When(x => x.Add(Arg.Is<Message>(m => m.SenderId == MessageUnitTestConfigurations.EXISTING_SENDER_ID &&
                                                               m.ReceiverId == MessageUnitTestConfigurations.EXISTING_RECEIVER_ID &&
                                                               m.Content == ValidContent)))
                         .Do(ci =>
                              {
                                  var message = ci.Arg<Message>();
                                  message.Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID;
                              });

        var existingSender = new User(
            MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
            MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE)
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
        };

        var existingReceiver = new User(
            MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            MessageUnitTestConfigurations.EXISTING_RECEIVER_NAME,
            MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE)
        {
            Id = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID
        };

        var existingMessage = new Message(
            ValidContent, 
            MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID, 
            MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID)
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            Sender = new User(
                MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
                MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
                MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
                MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
                MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE)
            {
                Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
            },
            Receiver = new User(
                MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
                MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
                MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
                MessageUnitTestConfigurations.EXISTING_RECEIVER_NAME,
                MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE)
            {
                Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID
            },
        };

        MessageReadRepository.GetByIdAsync(
            MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CancellationToken)
            .Returns(existingMessage);

        UserReadRepository.GetByIdAsync(
            MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            CancellationToken)
            .Returns(existingSender);

        UserReadRepository.GetByIdAsync(
            MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            CancellationToken)
            .Returns(existingReceiver);

        MessageWriteRepository.GetByIdAsync(
            MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CancellationToken)
            .Returns(existingMessage);

        UserWriteRepository.GetByIdAsync(
            MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            CancellationToken)
            .Returns(existingSender);

        UserWriteRepository.GetByIdAsync(
            MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            CancellationToken)
            .Returns(existingReceiver);
    }
}

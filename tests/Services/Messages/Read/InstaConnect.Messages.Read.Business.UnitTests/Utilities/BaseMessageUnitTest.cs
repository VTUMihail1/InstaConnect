using System.Linq.Expressions;
using AutoMapper;
using Bogus;
using InstaConnect.Messages.Read.Business.Profiles;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Read.Business.Utilities;
using InstaConnect.Messages.Read.Data.Abstractions;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Read.Data.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.UnitTests.Utilities;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Messages.Write.Business.UnitTests.Utilities;

public abstract class BaseMessageUnitTest : BaseUnitTest
{
    protected readonly int ValidLimitValue;
    protected readonly int ValidOffsetValue;

    protected readonly string ValidId;
    protected readonly string ValidReceiverId;
    protected readonly string ValidReceiverName;
    protected readonly string ValidSortOrderName;
    protected readonly string ValidCurrentUserId;
    protected readonly string ValidSortPropertyName;

    protected IUnitOfWork UnitOfWork { get; }

    protected IEnumValidator EnumValidator { get; }

    protected IUserRepository UserRepository { get; }

    protected IEventPublisher EventPublisher { get; }

    protected IMessageRepository MessageRepository { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IEntityPropertyValidator EntityPropertyValidator { get; }

    protected IInstaConnectRequestClient<GetUserByIdRequest> GetUserByIdRequestClient { get; }

    public BaseMessageUnitTest()
    {
        ValidLimitValue = (MessageBusinessConfigurations.LIMIT_MAX_VALUE + MessageBusinessConfigurations.LIMIT_MIN_VALUE) / 2;
        ValidOffsetValue = (MessageBusinessConfigurations.OFFSET_MAX_VALUE + MessageBusinessConfigurations.OFFSET_MIN_VALUE) / 2;

        ValidId = Faker.Random.AlphaNumeric((MessageBusinessConfigurations.ID_MAX_LENGTH + MessageBusinessConfigurations.ID_MIN_LENGTH) / 2);
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
        UserRepository = Substitute.For<IUserRepository>();
        EventPublisher = Substitute.For<IEventPublisher>();
        MessageRepository = Substitute.For<IMessageRepository>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg =>
                cfg.AddProfile(new MessagesBusinessProfile()))));

        EntityPropertyValidator = new EntityPropertyValidator();
        GetUserByIdRequestClient = CreateUserByIdRequestClient(getUserBySenderIdResponse, getUserByReceiverIdResponse);

        MessageRepository.When(x => x.Add(Arg.Is<Message>(m => m.SenderId == MessageUnitTestConfigurations.EXISTING_SENDER_ID &&
                                                               m.ReceiverId == MessageUnitTestConfigurations.EXISTING_RECEIVER_ID &&
                                                               m.Content == ValidReceiverName)))
                         .Do(ci =>
                              {
                                  var message = ci.Arg<Message>();
                                  message.Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID;
                              });

        var existingMessage = new Message()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            SenderId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        var existingSender = new User()
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
            FirstName = MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            Email = MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        MessageRepository.GetByIdAsync(
            MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CancellationToken)
            .Returns(existingMessage);

        UserRepository.GetByIdAsync(
            MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            CancellationToken)
            .Returns(existingSender);
    }
}

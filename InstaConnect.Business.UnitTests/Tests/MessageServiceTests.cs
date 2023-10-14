using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Services;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

namespace InstaConnect.Business.UnitTests.Tests
{
    [TestFixture]
    public class MessageServiceTests
    {
        public const string TestExistingMessageId = "ExistingFollowId";
        public const string TestNonExistingMessageId = "NonExistingFollowId";
        public const string TestExistingSenderId = "ExistingFollowerId";
        public const string TestNonExistingSenderId = "NonExistingFollowerId";
        public const string TestExistingReceiverId = "ExistingFollowingId";
        public const string TestNonExistingReceiverId = "NonExistingFolloweingId";

        private IMapper _mapper;
        private IResultFactory _resultFactory;
        private Mock<IMessageRepository> _mockMessageRepository;
        private Mock<IInstaConnectUserManager> _mockInstaConnectUserManager;
        private Mock<IMessageSender> _mockMessageSender;
        private IMessageService _messageService;

        [SetUp]
        public void Setup()
        {

            var testMessages = new List<Message>()
            {
                new Message() 
                {
                    Id = TestExistingMessageId, 
                    SenderId = TestExistingSenderId, 
                    ReceiverId = TestExistingReceiverId
                }
            };

            var testExistingUser = new User();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InstaConnectProfile());
            });

            _mapper = config.CreateMapper();
            _resultFactory = new ResultFactory();
            _mockMessageRepository = new Mock<IMessageRepository>();
            _mockMessageSender = new Mock<IMessageSender>();
            _mockInstaConnectUserManager = new Mock<IInstaConnectUserManager>();
            _messageService = new MessageService(
                _mapper,
                _resultFactory,
                _mockMessageRepository.Object,
                _mockMessageSender.Object,
                _mockInstaConnectUserManager.Object);

            _mockMessageRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Message, bool>>>()))
               .ReturnsAsync((Expression<Func<Message, bool>> expression) => testMessages.Find(new Predicate<Message>(expression.Compile())));

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestExistingSenderId))
                .ReturnsAsync(testExistingUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestExistingReceiverId))
                .ReturnsAsync(testExistingUser);
        }

        [Test]
        [TestCase(TestExistingSenderId, TestNonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestNonExistingSenderId, TestExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestNonExistingSenderId, TestNonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingSenderId, TestExistingMessageId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(string userId, string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _messageService.GetByIdAsync(userId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingSenderId, TestNonExistingReceiverId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestNonExistingSenderId, TestExistingReceiverId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestExistingSenderId, TestNonExistingReceiverId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestExistingSenderId, TestExistingReceiverId, InstaConnectStatusCode.NoContent)]
        public async Task AddAsync_HasArguments_ReturnsExpectedResult(string senderId, string receiverId, InstaConnectStatusCode statusCode)
        {
            // Arrange
            var messageAddDTO = new MessageAddDTO()
            {
                SenderId = senderId,
                ReceiverId = receiverId
            };

            // Act
            var result = await _messageService.AddAsync(messageAddDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingSenderId, TestNonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingSenderId, TestNonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestNonExistingSenderId, TestExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingSenderId, TestExistingMessageId, InstaConnectStatusCode.NoContent)]
        public async Task UpdateAsync_HasId_ReturnsExpectedResult(string senderId, string id, InstaConnectStatusCode statusCode)
        {
            // Arrange
            var messageUpdateDTO = new MessageUpdateDTO();

            // Act
            var result = await _messageService.UpdateAsync(senderId, id, messageUpdateDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingSenderId, TestNonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingSenderId, TestNonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestNonExistingSenderId, TestExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingSenderId, TestExistingMessageId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasId_ReturnsExpectedResult(string senderId, string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _messageService.DeleteAsync(senderId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

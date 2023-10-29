using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
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

namespace InstaConnect.Business.UnitTests.Tests.Services
{
    [TestFixture]
    public class MessageServiceTests
    {
        public const string ExistingMessageId = "ExistingMessageId";
        public const string NonExistingMessageId = "NonExistingMessageId";

        public const string ExistingSenderId = "ExistingSenderId";
        public const string NonExistingSenderId = "NonExistingSenderId";

        public const string ExistingReceiverId = "ExistingReceiverId";
        public const string NonExistingReceiverId = "NonExistingReceiverId";

        private Mock<IMapper> _mockMapper;
        private IResultFactory _resultFactory;
        private Mock<IMessageRepository> _mockMessageRepository;
        private Mock<IInstaConnectUserManager> _mockInstaConnectUserManager;
        private Mock<IMessageSender> _mockMessageSender;
        private IMessageService _messageService;

        public MessageServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockMessageRepository = new Mock<IMessageRepository>();
            _mockMessageSender = new Mock<IMessageSender>();
            _mockInstaConnectUserManager = new Mock<IInstaConnectUserManager>();
            _messageService = new MessageService(
                _mockMapper.Object,
                _resultFactory,
                _mockMessageRepository.Object,
                _mockMessageSender.Object,
                _mockInstaConnectUserManager.Object);
        }

        [SetUp]
        public void Setup()
        {
            var existingMessages = new List<Message>()
            {
                new Message()
                {
                    Id = ExistingMessageId,
                    SenderId = ExistingSenderId,
                    ReceiverId = ExistingReceiverId
                }
            };

            var existingUser = new User();

            _mockMessageRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Message, bool>>>()))
                .ReturnsAsync((Expression<Func<Message, bool>> expression) => existingMessages.Find(new Predicate<Message>(expression.Compile())));

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(ExistingSenderId))
                .ReturnsAsync(existingUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(ExistingReceiverId))
                .ReturnsAsync(existingUser);
        }

        [Test]
        [TestCase(ExistingSenderId, NonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingSenderId, ExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingSenderId, NonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingSenderId, ExistingMessageId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(
            string userId,
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _messageService.GetByIdAsync(userId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingSenderId, NonExistingReceiverId, InstaConnectStatusCode.BadRequest)]
        [TestCase(NonExistingSenderId, ExistingReceiverId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingSenderId, NonExistingReceiverId, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingSenderId, ExistingReceiverId, InstaConnectStatusCode.NoContent)]
        public async Task AddAsync_HasArguments_ReturnsExpectedResult(
            string senderId,
            string receiverId,
            InstaConnectStatusCode statusCode)
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
        [TestCase(NonExistingSenderId, NonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingSenderId, NonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingSenderId, ExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingSenderId, ExistingMessageId, InstaConnectStatusCode.NoContent)]
        public async Task UpdateAsync_HasId_ReturnsExpectedResult(
            string senderId,
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Arrange
            var messageUpdateDTO = new MessageUpdateDTO();

            // Act
            var result = await _messageService.UpdateAsync(senderId, id, messageUpdateDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingSenderId, NonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingSenderId, NonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(NonExistingSenderId, ExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingSenderId, ExistingMessageId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasId_ReturnsExpectedResult(
            string senderId,
            string id,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _messageService.DeleteAsync(senderId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

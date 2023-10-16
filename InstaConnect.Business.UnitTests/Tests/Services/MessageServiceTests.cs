using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Message;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Services;
using InstaConnect.Business.UnitTests.Utilities;
using InstaConnect.Business.UnitTests.Utilities.Services;
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
            _mockMessageRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Message, bool>>>()))
                .ReturnsAsync((Expression<Func<Message, bool>> expression) => TestMessageServiceTestUtilities.TestMessages.Find(new Predicate<Message>(expression.Compile())));

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestMessageServiceTestUtilities.TestExistingSenderId))
                .ReturnsAsync(TestMessageServiceTestUtilities.TestExistingUser);

            _mockInstaConnectUserManager.Setup(s => s.FindByIdAsync(TestMessageServiceTestUtilities.TestExistingReceiverId))
                .ReturnsAsync(TestMessageServiceTestUtilities.TestExistingUser);
        }

        [Test]
        [TestCase(TestMessageServiceTestUtilities.TestExistingSenderId, TestMessageServiceTestUtilities.TestNonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestMessageServiceTestUtilities.TestNonExistingSenderId, TestMessageServiceTestUtilities.TestExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestMessageServiceTestUtilities.TestNonExistingSenderId, TestMessageServiceTestUtilities.TestNonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestMessageServiceTestUtilities.TestExistingSenderId, TestMessageServiceTestUtilities.TestExistingMessageId, InstaConnectStatusCode.OK)]
        public async Task GetById_HasId_ReturnsExpectedResult(string userId, string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _messageService.GetByIdAsync(userId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestMessageServiceTestUtilities.TestNonExistingSenderId, TestMessageServiceTestUtilities.TestNonExistingReceiverId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestMessageServiceTestUtilities.TestNonExistingSenderId, TestMessageServiceTestUtilities.TestExistingReceiverId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestMessageServiceTestUtilities.TestExistingSenderId, TestMessageServiceTestUtilities.TestNonExistingReceiverId, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestMessageServiceTestUtilities.TestExistingSenderId, TestMessageServiceTestUtilities.TestExistingReceiverId, InstaConnectStatusCode.NoContent)]
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
        [TestCase(TestMessageServiceTestUtilities.TestNonExistingSenderId, TestMessageServiceTestUtilities.TestNonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestMessageServiceTestUtilities.TestExistingSenderId, TestMessageServiceTestUtilities.TestNonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestMessageServiceTestUtilities.TestNonExistingSenderId, TestMessageServiceTestUtilities.TestExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestMessageServiceTestUtilities.TestExistingSenderId, TestMessageServiceTestUtilities.TestExistingMessageId, InstaConnectStatusCode.NoContent)]
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
        [TestCase(TestMessageServiceTestUtilities.TestNonExistingSenderId, TestMessageServiceTestUtilities.TestNonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestMessageServiceTestUtilities.TestExistingSenderId, TestMessageServiceTestUtilities.TestNonExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestMessageServiceTestUtilities.TestNonExistingSenderId, TestMessageServiceTestUtilities.TestExistingMessageId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestMessageServiceTestUtilities.TestExistingSenderId, TestMessageServiceTestUtilities.TestExistingMessageId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasId_ReturnsExpectedResult(string senderId, string id, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _messageService.DeleteAsync(senderId, id);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

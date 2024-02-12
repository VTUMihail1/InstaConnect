using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Services;
using Moq;
using NUnit.Framework;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;

namespace InstaConnect.Business.UnitTests.Tests.Services
{
    [TestFixture]
    public class EmailServiceTests
    {
        private const string ValidEmail = "ValidEmail";
        private const string InvalidEmail = "InvalidEmail";

        private readonly IResultFactory _resultFactory;
        private readonly Mock<IEmailSender> _mockEmailSender;
        private readonly Mock<IEmailFactory> _mockEmailFactory;
        private readonly Mock<IEndpointHandler> _mockEndpointHandler;
        private readonly Mock<ITemplateGenerator> _mockTemplateGenerator;
        private readonly IEmailService _emailService;

        public EmailServiceTests()
        {
            _resultFactory = new ResultFactory();
            _mockEmailSender = new Mock<IEmailSender>();
            _mockEmailFactory = new Mock<IEmailFactory>();
            _mockEndpointHandler = new Mock<IEndpointHandler>();
            _mockTemplateGenerator = new Mock<ITemplateGenerator>();
            _emailService = new EmailService(
                _mockEmailSender.Object, 
                _mockEmailFactory.Object, 
                _mockEndpointHandler.Object,
                _mockTemplateGenerator.Object,
                _resultFactory);
        }

        [SetUp]
        public void Setup()
        {
            var okResult = new Response(HttpStatusCode.OK, null, null);
            var badRequestResult = new Response(HttpStatusCode.BadRequest, null, null);

            var validEmail = new SendGridMessage();
            var invalidEmail = new SendGridMessage();

            _mockEmailFactory.Setup(m => m.GetEmail(ValidEmail, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(validEmail);

            _mockEmailFactory.Setup(m => m.GetEmail(InvalidEmail, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(invalidEmail);

            _mockEmailSender.Setup(m => m.SendEmailAsync(validEmail))
                .ReturnsAsync(okResult);

            _mockEmailSender.Setup(m => m.SendEmailAsync(invalidEmail))
                .ReturnsAsync(badRequestResult);
        }

        [Test]
        [TestCase(ValidEmail, InstaConnectStatusCode.NoContent)]
        [TestCase(InvalidEmail, InstaConnectStatusCode.BadRequest)]
        public async Task SendEmailConfirmationAsync_HasArguments_ReturnsExpectedResult(
            string email,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _emailService.SendEmailConfirmationAsync(email, string.Empty, string.Empty);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(ValidEmail, InstaConnectStatusCode.NoContent)]
        [TestCase(InvalidEmail, InstaConnectStatusCode.BadRequest)]
        public async Task SendPasswordResetAsync_HasArguments_ReturnsExpectedResult(
            string email,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _emailService.SendPasswordResetAsync(email, string.Empty, string.Empty);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

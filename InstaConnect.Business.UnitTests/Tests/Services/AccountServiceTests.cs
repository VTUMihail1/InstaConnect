using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.DTOs.Email;
using InstaConnect.Business.Models.DTOs.Token;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Models.Results;
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
    public class AccountServiceTests
    {
        private const string ExistingUserId = "ExistingUserId";
        private const string NonExistingUserId = "NonExistingUserId";
        private const string ExistingUnconfirmedUserId = "ExistingUnconfirmedUserId";
     
        private const string ExistingUserEmail = "ExistingUserEmail";
        private const string NonExistingUserEmail = "NonExistingUserEmail";
        private const string ExistingUnconfirmedUserEmail = "ExistingUserUnconfimerEmail";
        private const string ExistingInvalidUserEmail = "ExistingInvalidUserEmail";

        private const string ExistingUserUsername = "ExistingUserName";
        private const string ExistingUserUnconfirmedEmailUsername = "ExistingUserUnconfirmedEmailUsername";
        private const string NonExistingUserName = "NonExistingUserName";
    
        private const string ExistingUserPassword = "ExistingUserPassword";
        private const string NonExistingUserPassword = "NonExistingUserPassword";
       
        private const string ExistingTokenValue = "ExistingTokenValue";
        private const string NonExistingTokenValue = "NonExistingTokenValue";

        private readonly Mock<IMapper> _mockMapper;
        private readonly IResultFactory _resultFactory;
        private readonly Mock<IEmailService> _mockEmailService;
        private readonly Mock<ITokenService> _mockTokenService;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IAccountManager> _accountManager;
        private readonly IAccountService _accountService;

        public AccountServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockEmailService = new Mock<IEmailService>();
            _mockTokenService = new Mock<ITokenService>();
            _mockUserRepository = new Mock<IUserRepository>();
            _accountManager = new Mock<IAccountManager>();

            _accountService = new AccountService(
                _mockMapper.Object,
                _resultFactory,
                _mockEmailService.Object,
                _mockTokenService.Object,
                _mockUserRepository.Object,
                _accountManager.Object);
        }

        [SetUp]
        public void Setup()
        {
            var existingTokenResultDTO = new TokenResultDTO()
            {
                Value = ExistingTokenValue
            };

            var existingUser = new User()
            {
                Id = ExistingUserId,
                Email = ExistingUserEmail,
                UserName = ExistingUserUsername
            };

            var existingUnconfirmedUser = new User()
            {
                Id = ExistingUnconfirmedUserId,
                Email = ExistingUnconfirmedUserEmail,
                UserName = ExistingUserUnconfirmedEmailUsername
            };

            var еxistingInvalidUser = new User()
            {
                Email = ExistingInvalidUserEmail,
            };

            var existingUsers = new List<User>()
            {
                existingUser,
                existingUnconfirmedUser,
                еxistingInvalidUser
            };

            var tokenOkResult = new OkResult<TokenResultDTO>(existingTokenResultDTO);
            var tokenNoContentResult = new NoContentResult<TokenResultDTO>();
            var tokenBadRequestResult = new NotFoundResult<TokenResultDTO>();

            var emailNoContentResult = new NoContentResult<EmailResultDTO>();
            var emailBadRequestResult = new NotFoundResult<EmailResultDTO>();

            _mockMapper.Setup(m => m.Map<User>(It.IsAny<AccountRegisterDTO>()))
                .Returns((AccountRegisterDTO accountRegistrationDTO) =>
                {
                    var user = new User()
                    {
                        Email = accountRegistrationDTO.Email,
                        UserName = accountRegistrationDTO.Username
                    };

                    return user;
                });

            _mockUserRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync((Expression<Func<User, bool>> expression) => existingUsers.Find(new Predicate<User>(expression.Compile())));

            _accountManager.Setup(m => m.IsEmailConfirmedAsync(existingUser))
                .ReturnsAsync(true);

            _accountManager.Setup(m => m.CheckPasswordAsync(existingUser, ExistingUserPassword)).
                ReturnsAsync(true);

            _accountManager.Setup(m => m.CheckPasswordAsync(existingUnconfirmedUser, ExistingUserPassword)).
                ReturnsAsync(true);

            _mockTokenService.Setup(m => m.DeleteAsync(ExistingTokenValue))
                .ReturnsAsync(tokenNoContentResult);

            _mockTokenService.Setup(m => m.DeleteAsync(It.Is<string>(t => t != ExistingTokenValue)))
                .ReturnsAsync(tokenBadRequestResult);

            _mockEmailService.Setup(m => m.SendPasswordResetAsync(ExistingUserEmail, It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(emailNoContentResult);

            _mockEmailService.Setup(m => m.SendPasswordResetAsync(It.Is<string>(e => e != ExistingUserEmail), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(emailBadRequestResult);

            _mockEmailService.Setup(m => m.SendEmailConfirmationAsync(NonExistingUserEmail, It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(emailNoContentResult);

            _mockEmailService.Setup(m => m.SendEmailConfirmationAsync(ExistingUnconfirmedUserEmail, It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(emailNoContentResult);

            _mockEmailService.Setup(m => m.SendEmailConfirmationAsync(It.Is<string>(e => e != ExistingUnconfirmedUserEmail && e != NonExistingUserEmail), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(emailBadRequestResult);

            _mockTokenService.Setup(m => m.GenerateAccessTokenAsync(It.IsAny<string>())).
                ReturnsAsync(tokenOkResult);

            _mockTokenService.Setup(m => m.GenerateEmailConfirmationTokenAsync(It.IsAny<string>())).
                ReturnsAsync(tokenOkResult);

            _mockTokenService.Setup(m => m.GeneratePasswordResetTokenAsync(It.IsAny<string>())).
                ReturnsAsync(tokenOkResult);
        }

        [Test]
        [TestCase(ExistingUserEmail, ExistingUserUsername, InstaConnectStatusCode.BadRequest)]
        [TestCase(NonExistingUserEmail, ExistingUserUsername, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingInvalidUserEmail, NonExistingUserName, InstaConnectStatusCode.BadRequest)]
        [TestCase(NonExistingUserEmail, NonExistingUserName, InstaConnectStatusCode.NoContent)]
        public async Task SignUpAsync_HasArguments_ReturnsExpectedResult(
            string email,
            string username,
            InstaConnectStatusCode statusCode)
        {
            // Arrange
            var accountRegisterDTO = new AccountRegisterDTO()
            {
                Email = email,
                Username = username,
            };

            // Act
            var result = await _accountService.SignUpAsync(accountRegisterDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserEmail, ExistingUserPassword, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserEmail, NonExistingUserPassword, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUnconfirmedUserEmail, ExistingUserPassword, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserEmail, ExistingUserPassword, InstaConnectStatusCode.OK)]
        public async Task LoginAsync_HasArguments_ReturnsExpectedResult(
            string email,
            string password,
            InstaConnectStatusCode statusCode)
        {
            // Arrange
            var accountLoginDTO = new AccountLoginDTO()
            {
                Email = email,
                Password = password,
            };

            // Act
            var result = await _accountService.LoginAsync(accountLoginDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserEmail, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserEmail, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingInvalidUserEmail, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUnconfirmedUserEmail, InstaConnectStatusCode.NoContent)]
        public async Task ResendEmailConfirmationTokenAsync_HasArguments_ReturnsExpectedResult(
            string email,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _accountService.ResendEmailConfirmationTokenAsync(email);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserEmail, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingInvalidUserEmail, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserEmail, InstaConnectStatusCode.NoContent)]
        public async Task SendPasswordResetTokenByEmailAsync_HasArguments_ReturnsExpectedResult(
            string email,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _accountService.SendPasswordResetTokenByEmailAsync(email);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserId, ExistingTokenValue, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, ExistingTokenValue, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUnconfirmedUserId, NonExistingTokenValue, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUnconfirmedUserId, ExistingTokenValue, InstaConnectStatusCode.NoContent)]
        public async Task ConfirmEmailWithTokenAsync_HasArguments_ReturnsExpectedResult(
            string userId,
            string token,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _accountService.ConfirmEmailWithTokenAsync(userId, token);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserId, ExistingTokenValue, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, NonExistingTokenValue, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, ExistingTokenValue, InstaConnectStatusCode.NoContent)]
        public async Task ResetPasswordWithTokenAsync_HasArguments_ReturnsExpectedResult(
            string userId,
            string token,
            InstaConnectStatusCode statusCode)
        {
            // Arrange
            var accountResetPasswordDTO = new AccountResetPasswordDTO();

            // Act
            var result = await _accountService.ResetPasswordWithTokenAsync(userId, token, accountResetPasswordDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(ExistingUserId, ExistingUserUnconfirmedEmailUsername, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUserId, NonExistingUserName, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingUserId, ExistingUserUsername, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingUnconfirmedUserId, ExistingUserUsername, InstaConnectStatusCode.BadRequest)]
        public async Task EditAsync_HasArguments_ReturnsExpectedResult(
            string userId,
            string username,
            InstaConnectStatusCode statusCode)
        {
            // Arrange
            var accountEditDTO = new AccountEditDTO()
            {
                UserName = username
            };

            // Act
            var result = await _accountService.EditAsync(userId, accountEditDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(NonExistingUserId, InstaConnectStatusCode.NotFound)]
        [TestCase(ExistingUserId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasArguments_ReturnsExpectedResult(
            string userId,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _accountService.DeleteAsync(userId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

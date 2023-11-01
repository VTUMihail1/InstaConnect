using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.DTOs.Token;
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
    public class AccountServiceTests
    {
        public const string ExistingUserId = "ExistingUserId";
        public const string NonExistingUserId = "NonExistingUserId";
        public const string ExistingUnconfirmedUserId = "ExistingUnconfirmedUserId";

        public const string ExistingUserEmail = "ExistingUserEmail";
        public const string NonExistingUserEmail = "NonExistingUserEmail";
        public const string ExistingUnconfirmedUserEmail = "ExistingUserUnconfimerEmail";
        public const string ExistingInvalidUserEmail = "ExistingInvalidUserEmail";

        public const string ExistingUserUsername = "ExistingUserName";
        public const string ExistingUserUnconfirmedEmailUsername = "ExistingUserUnconfirmedEmailUsername";
        public const string NonExistingUserName = "NonExistingUserName";

        public const string ExistingUserPassword = "ExistingUserPassword";
        public const string NonExistingUserPassword = "NonExistingUserPassword";

        public const string ExistingTokenValue = "ExistingTokenValue";
        public const string NonExistingTokenValue = "NonExistingTokenValue";

        private readonly Mock<IMapper> _mockMapper;
        private readonly IResultFactory _resultFactory;
        private readonly Mock<IEmailManager> _mockEmailManager;
        private readonly Mock<ITokenManager> _mockTokenManager;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IAccountManager> _accountManager;
        private readonly IAccountService _accountService;

        public AccountServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockEmailManager = new Mock<IEmailManager>();
            _mockTokenManager = new Mock<ITokenManager>();
            _mockUserRepository = new Mock<IUserRepository>();
            _accountManager = new Mock<IAccountManager>();
            
            _accountService = new AccountService(
                _mockMapper.Object,
                _resultFactory,
                _mockEmailManager.Object,
                _mockTokenManager.Object,
                _mockUserRepository.Object,
                _accountManager.Object);
        }

        [SetUp]
        public void Setup()
        {
            var existingToken = new TokenResultDTO()
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

            _mockTokenManager.Setup(m => m.RemoveAsync(ExistingTokenValue))
                .ReturnsAsync(true);

            _mockEmailManager.Setup(m => m.SendPasswordResetAsync(ExistingUserEmail, It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(true);

            _mockEmailManager.Setup(m => m.SendEmailConfirmationAsync(ExistingUnconfirmedUserEmail, It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(true);

            _mockEmailManager.Setup(m => m.SendEmailConfirmationAsync(NonExistingUserEmail, It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(true);

            _mockTokenManager.Setup(m => m.GenerateAccessToken(It.IsAny<string>())).
                ReturnsAsync(existingToken);

            _mockTokenManager.Setup(m => m.GenerateEmailConfirmationTokenAsync(It.IsAny<string>())).
                ReturnsAsync(existingToken);

            _mockTokenManager.Setup(m => m.GeneratePasswordResetToken(It.IsAny<string>())).
                ReturnsAsync(existingToken);
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
        [TestCase(ExistingUserEmail, ExistingUserPassword, InstaConnectStatusCode.OK)]
        [TestCase(NonExistingUserEmail, ExistingUserPassword, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUnconfirmedUserEmail, ExistingUserPassword, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingUnconfirmedUserEmail, NonExistingUserPassword, InstaConnectStatusCode.BadRequest)]
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
        [TestCase(ExistingUserEmail, InstaConnectStatusCode.BadRequest)]
        [TestCase(NonExistingUserEmail, InstaConnectStatusCode.BadRequest)]
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
        [TestCase(ExistingUserEmail, InstaConnectStatusCode.NoContent)]
        [TestCase(NonExistingUserEmail, InstaConnectStatusCode.BadRequest)]
        [TestCase(ExistingInvalidUserEmail, InstaConnectStatusCode.BadRequest)]
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
        [TestCase(ExistingUnconfirmedUserId, ExistingTokenValue, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingUnconfirmedUserId, NonExistingTokenValue, InstaConnectStatusCode.BadRequest)]
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
        [TestCase(ExistingUserId, ExistingTokenValue, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingUserId, NonExistingTokenValue, InstaConnectStatusCode.BadRequest)]
        [TestCase(NonExistingUserId, ExistingTokenValue, InstaConnectStatusCode.BadRequest)]
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
        [TestCase(ExistingUserId, NonExistingUserName, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingUserId, ExistingUserUsername, InstaConnectStatusCode.NoContent)]
        [TestCase(ExistingUserId, ExistingUserUnconfirmedEmailUsername, InstaConnectStatusCode.BadRequest)]
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

using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Services;
using InstaConnect.Business.UnitTests.Utilities;
using InstaConnect.Business.UnitTests.Utilities.Services;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;


namespace InstaConnect.Business.UnitTests.Tests.Services
{
    [TestFixture]
    public class AccountServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly IResultFactory _resultFactory;
        private readonly Mock<IEmailManager> _mockEmailManager;
        private readonly Mock<ITokenManager> _mockTokenManager;
        private readonly Mock<IInstaConnectUserManager> _mockInstaConnectUserManager;
        private readonly IAccountService _accountService;

        public AccountServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockEmailManager = new Mock<IEmailManager>();
            _mockTokenManager = new Mock<ITokenManager>();
            _mockInstaConnectUserManager = new Mock<IInstaConnectUserManager>();
            _accountService = new AccountService(
                _mockMapper.Object,
                _resultFactory,
                _mockEmailManager.Object,
                _mockTokenManager.Object,
                _mockInstaConnectUserManager.Object);
        }

        [SetUp]
        public void Setup()
        {
            _mockMapper.Setup(m => m.Map<User>(TestAccountServiceUtilities.TestExistingAccountRegistrationDTO))
                .Returns(TestAccountServiceUtilities.TestExistingUser);

            _mockMapper.Setup(m => m.Map<User>(TestAccountServiceUtilities.TestNonExistingAccountRegistrationDTOWithValidEmailProvider))
                .Returns(TestAccountServiceUtilities.TestNonExistingUserWithValidEmailProvider);

            _mockMapper.Setup(m => m.Map<User>(TestAccountServiceUtilities.TestNonExistingAccountRegistrationDTOWithInvalidEmailProvider))
                .Returns(TestAccountServiceUtilities.TestNonExistingUserWithInvalidEmailProvider);

            _mockMapper.Setup(m => m.Map<User>(TestAccountServiceUtilities.TestNonExistingAccountRegistrationDTOWithInvalidPassword))
                .Returns(TestAccountServiceUtilities.TestNonExistingUserWithValidEmailProvider);

            _mockMapper.Setup(m => m.Map<User>(TestAccountServiceUtilities.TestNonExistingAccountRegistrationDTOWithInvalidEmail))
                .Returns(TestAccountServiceUtilities.TestNonExistingUserWithInvalidEmail);

            _mockMapper.Setup(m => m.Map<User>(TestAccountServiceUtilities.TestNonExistingAccountRegistrationDTOWithInvalidUsername))
                .Returns(TestAccountServiceUtilities.TestNonExistingUserWithInvalidUsername);

            _mockInstaConnectUserManager.Setup(m => m.FindByIdAsync(TestAccountServiceUtilities.TestExistingUserId))
                .ReturnsAsync(TestAccountServiceUtilities.TestExistingUser);

            _mockInstaConnectUserManager.Setup(m => m.FindByIdAsync(TestAccountServiceUtilities.TestExistingUserIdWithUnconfirmedEmail))
                .ReturnsAsync(TestAccountServiceUtilities.TestExistingUserWithUnconfirmedEmail);

            _mockInstaConnectUserManager.Setup(m => m.FindByNameAsync(TestAccountServiceUtilities.TestExistingUserUsername))
                .ReturnsAsync(TestAccountServiceUtilities.TestExistingUser);

            _mockInstaConnectUserManager.Setup(m => m.FindByEmailAsync(TestAccountServiceUtilities.TestExistingUserEmail))
                .ReturnsAsync(TestAccountServiceUtilities.TestExistingUser);

            _mockInstaConnectUserManager.Setup(m => m.FindByEmailAsync(TestAccountServiceUtilities.TestNonExistingUserInvalidEmailProvider))
                .ReturnsAsync(TestAccountServiceUtilities.TestNonExistingUserWithInvalidEmailProvider);

            _mockInstaConnectUserManager.Setup(m => m.FindByEmailAsync(TestAccountServiceUtilities.TestExistingUserUnconfirmedEmail))
                .ReturnsAsync(TestAccountServiceUtilities.TestExistingUserWithUnconfirmedEmail);

            _mockInstaConnectUserManager.Setup(m => m.FindByIdAsync(TestAccountServiceUtilities.TestExistingUserId))
                .ReturnsAsync(TestAccountServiceUtilities.TestExistingUser);

            _mockInstaConnectUserManager.Setup(m => m.IsEmailConfirmedAsync(TestAccountServiceUtilities.TestExistingUser))
                .ReturnsAsync(true);

            _mockInstaConnectUserManager.Setup(m => m.CreateAsync(TestAccountServiceUtilities.TestNonExistingUserWithValidEmailProvider, TestAccountServiceUtilities.TestNonExistingValidUserPassword))
                .ReturnsAsync(IdentityResult.Success);

            _mockInstaConnectUserManager.Setup(m => m.CreateAsync(TestAccountServiceUtilities.TestNonExistingUserWithInvalidEmailProvider, TestAccountServiceUtilities.TestNonExistingValidUserPassword))
                .ReturnsAsync(IdentityResult.Success);

            _mockInstaConnectUserManager.Setup(m => m.CreateAsync(TestAccountServiceUtilities.TestNonExistingUserWithValidEmailProvider, TestAccountServiceUtilities.TestNonExistingInvalidUserPassword))
                .ReturnsAsync(IdentityResult.Failed());

            _mockInstaConnectUserManager.Setup(m => m.CreateAsync(TestAccountServiceUtilities.TestNonExistingUserWithInvalidUsername, TestAccountServiceUtilities.TestNonExistingValidUserPassword))
                .ReturnsAsync(IdentityResult.Failed());

            _mockInstaConnectUserManager.Setup(m => m.CreateAsync(TestAccountServiceUtilities.TestNonExistingUserWithInvalidEmail, TestAccountServiceUtilities.TestNonExistingValidUserPassword))
                .ReturnsAsync(IdentityResult.Failed());

            _mockInstaConnectUserManager.Setup(m => m.GenerateEmailConfirmationTokenAsync(It.IsAny<User>()))
                .ReturnsAsync(TestAccountServiceUtilities.TestInvalidUserToken);

            _mockInstaConnectUserManager.Setup(m => m.GeneratePasswordResetTokenAsync(It.IsAny<User>()))
                .ReturnsAsync(TestAccountServiceUtilities.TestInvalidUserToken);

            _mockTokenManager.Setup(m => m.RemoveAsync(TestAccountServiceUtilities.TestValidUserToken))
                .ReturnsAsync(true);

            _mockInstaConnectUserManager.Setup(m => m.ResetPasswordAsync(TestAccountServiceUtilities.TestExistingUser, TestAccountServiceUtilities.TestInvalidUserToken, TestAccountServiceUtilities.TestNonExistingValidUserPassword))
                .ReturnsAsync(IdentityResult.Failed());

            _mockInstaConnectUserManager.Setup(m => m.ResetPasswordAsync(TestAccountServiceUtilities.TestExistingUser, TestAccountServiceUtilities.TestValidUserToken, TestAccountServiceUtilities.TestNonExistingValidUserPassword))
                .ReturnsAsync(IdentityResult.Success);

            _mockEmailManager.Setup(m => m.SendPasswordResetAsync(TestAccountServiceUtilities.TestExistingUserEmail, TestAccountServiceUtilities.TestExistingUserId, It.IsAny<string>()))
                .ReturnsAsync(true);

            _mockEmailManager.Setup(m => m.SendEmailConfirmationAsync(TestAccountServiceUtilities.TestExistingUserUnconfirmedEmail, TestAccountServiceUtilities.TestExistingUserIdWithUnconfirmedEmail, It.IsAny<string>()))
                .ReturnsAsync(true);

            _mockEmailManager.Setup(m => m.SendEmailConfirmationAsync(TestAccountServiceUtilities.TestNonExistingUserValidEmailProvider, TestAccountServiceUtilities.TestNonExistingUserId, It.IsAny<string>()))
                .ReturnsAsync(true);

			_mockInstaConnectUserManager.Setup(m => m.CheckPasswordAsync(TestAccountServiceUtilities.TestExistingUser, TestAccountServiceUtilities.TestExistingUserPassword)).
                ReturnsAsync(true);

			_mockInstaConnectUserManager.Setup(m => m.CheckPasswordAsync(TestAccountServiceUtilities.TestExistingUserWithUnconfirmedEmail, TestAccountServiceUtilities.TestExistingUserPassword)).
                ReturnsAsync(true);

            _mockTokenManager.Setup(m => m.GenerateAccessToken(It.IsAny<string>())).
                ReturnsAsync(TestAccountServiceUtilities.TestValidToken);

			_mockTokenManager.Setup(m => m.GenerateEmailConfirmationToken(It.IsAny<string>())).
				ReturnsAsync(TestAccountServiceUtilities.TestValidToken);

			_mockTokenManager.Setup(m => m.GeneratePasswordResetToken(It.IsAny<string>())).
				ReturnsAsync(TestAccountServiceUtilities.TestValidToken);
		}

        [Test]
        public async Task SignUpAsync_HasInvalidUsername_ReturnsBadRequestResult()
        {
            // Act
            var result = await _accountService.SignUpAsync(TestAccountServiceUtilities.TestNonExistingAccountRegistrationDTOWithInvalidUsername);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(InstaConnectStatusCode.BadRequest));
        }

        [Test]
        public async Task SignUpAsync_HasInvalidEmail_ReturnsBadRequestResult()
        {
            // Act
            var result = await _accountService.SignUpAsync(TestAccountServiceUtilities.TestNonExistingAccountRegistrationDTOWithInvalidEmail);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(InstaConnectStatusCode.BadRequest));
        }

        [Test]
        public async Task SignUpAsync_HasInvalidPassword_ReturnsBadRequestResult()
        {
            // Act
            var result = await _accountService.SignUpAsync(TestAccountServiceUtilities.TestNonExistingAccountRegistrationDTOWithInvalidPassword);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(InstaConnectStatusCode.BadRequest));
        }

        [Test]
        public async Task SignUpAsync_HasInvalidEmailProvider_ReturnsBadRequestResult()
        {
            // Act
            var result = await _accountService.SignUpAsync(TestAccountServiceUtilities.TestNonExistingAccountRegistrationDTOWithInvalidEmailProvider);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(InstaConnectStatusCode.BadRequest));
        }

        [Test]
        public async Task SignUpAsync_HasValidArguments_ReturnsNoContentResult()
        {
            // Act
            var result = await _accountService.SignUpAsync(TestAccountServiceUtilities.TestNonExistingAccountRegistrationDTOWithValidEmailProvider);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(InstaConnectStatusCode.NoContent));
        }

        [Test]
        [TestCase(TestAccountServiceUtilities.TestExistingUserEmail, TestAccountServiceUtilities.TestExistingUserPassword, InstaConnectStatusCode.OK)]
        [TestCase(TestAccountServiceUtilities.TestNonExistingUserEmail, TestAccountServiceUtilities.TestExistingUserPassword, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestAccountServiceUtilities.TestExistingUserUnconfirmedEmail, TestAccountServiceUtilities.TestExistingUserPassword, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestAccountServiceUtilities.TestNonExistingUserEmail, TestAccountServiceUtilities.TestNonExistingValidUserPassword, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestAccountServiceUtilities.TestExistingUserUnconfirmedEmail, TestAccountServiceUtilities.TestNonExistingValidUserPassword, InstaConnectStatusCode.BadRequest)]
        public async Task LoginAsync_HasArguments_ReturnsExpectedResult(string email, string password, InstaConnectStatusCode statusCode)
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
        [TestCase(TestAccountServiceUtilities.TestExistingUserEmail, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestAccountServiceUtilities.TestNonExistingUserEmail, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestAccountServiceUtilities.TestNonExistingUserInvalidEmailProvider, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestAccountServiceUtilities.TestExistingUserUnconfirmedEmail, InstaConnectStatusCode.NoContent)]
        public async Task ResendEmailConfirmationTokenAsync_HasArguments_ReturnsExpectedResult(string email, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _accountService.ResendEmailConfirmationTokenAsync(email);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestAccountServiceUtilities.TestExistingUserEmail, InstaConnectStatusCode.NoContent)]
        [TestCase(TestAccountServiceUtilities.TestNonExistingUserEmail, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestAccountServiceUtilities.TestNonExistingUserInvalidEmailProvider, InstaConnectStatusCode.BadRequest)]
        public async Task SendPasswordResetTokenByEmailAsync_HasArguments_ReturnsExpectedResult(string email, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _accountService.SendPasswordResetTokenByEmailAsync(email);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestAccountServiceUtilities.TestNonExistingUserId, TestAccountServiceUtilities.TestValidUserToken, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestAccountServiceUtilities.TestExistingUserId, TestAccountServiceUtilities.TestValidUserToken, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestAccountServiceUtilities.TestExistingUserIdWithUnconfirmedEmail, TestAccountServiceUtilities.TestValidUserToken, InstaConnectStatusCode.NoContent)]
        [TestCase(TestAccountServiceUtilities.TestExistingUserIdWithUnconfirmedEmail, TestAccountServiceUtilities.TestInvalidUserToken, InstaConnectStatusCode.BadRequest)]
        public async Task ConfirmEmailWithTokenAsync_HasArguments_ReturnsExpectedResult(string userId, string token, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _accountService.ConfirmEmailWithTokenAsync(userId, token);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestAccountServiceUtilities.TestExistingUserId, TestAccountServiceUtilities.TestValidUserToken, InstaConnectStatusCode.NoContent)]
        [TestCase(TestAccountServiceUtilities.TestExistingUserId, TestAccountServiceUtilities.TestInvalidUserToken, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestAccountServiceUtilities.TestNonExistingUserId, TestAccountServiceUtilities.TestValidUserToken, InstaConnectStatusCode.BadRequest)]
        public async Task ResetPasswordWithTokenAsync_HasArguments_ReturnsExpectedResult(string userId, string token, InstaConnectStatusCode statusCode)
        {
            // Arrange
            var accountResetPasswordDTO = new AccountResetPasswordDTO()
            {
                Password = TestAccountServiceUtilities.TestNonExistingValidUserPassword
            };

            // Act
            var result = await _accountService.ResetPasswordWithTokenAsync(userId, token, accountResetPasswordDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestAccountServiceUtilities.TestExistingUserId, TestAccountServiceUtilities.TestNonExistingValidUserUsername, InstaConnectStatusCode.NoContent)]
        [TestCase(TestAccountServiceUtilities.TestExistingUserId, TestAccountServiceUtilities.TestExistingUserUsername, InstaConnectStatusCode.NoContent)]
        [TestCase(TestAccountServiceUtilities.TestExistingUserIdWithUnconfirmedEmail, TestAccountServiceUtilities.TestExistingUserUsername, InstaConnectStatusCode.BadRequest)]
        public async Task EditAsync_HasArguments_ReturnsExpectedResult(string userId, string username, InstaConnectStatusCode statusCode)
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
        [TestCase(TestAccountServiceUtilities.TestNonExistingUserId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestAccountServiceUtilities.TestExistingUserId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasArguments_ReturnsExpectedResult(string userId, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _accountService.DeleteAsync(userId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Services;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;


namespace InstaConnect.Business.UnitTests.Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        public const string TestExistingUserId = "ExistingUserId";
        public const string TestExistingUserIdWithUnconfirmedEmail = "ExistingUserIdWithUnconfirmedEmail";
        public const string TestNonExistingUserId = "NonExistingUserId";
        public const string TestExistingUserEmail = "ExistingUserEmail";
        public const string TestNonExistingUserEmail = "NonExistingUserEmail";
        public const string TestExistingUserWithUnconfirmedEmail = "ExistingUserUnconfimerEmail";
        public const string TestNonExistingUserWithValidEmailProvider = "NonExistingUserWithValidEmailProvider";
        public const string TestNonExistingUserWithInvalidEmailProvider = "NonExistingUserWithInvalidEmailProvider";
        public const string TestExistingUserUsername = "ExistingUserUsername";
        public const string TestExistingUserUsernameWithUnconfirmedEmail = "ExistingUserUsernameWithUnconfirmedEmail";
        public const string TestNonExistingValidUserUsername = "NonExistingValidUserUsername";
        public const string TestNonExistingInvalidUserUsername = "NonExistingInvalidUserUsername";
        public const string TestExistingUserPassword = "ExistingUserValidPassword";
        public const string TestNonExistingValidUserPassword = "NonExistingValidUserPassword";
        public const string TestNonExistingInvalidUserPassword = "NonExistingInvalidUserPassword";
        public const string TestValidUserToken = "ValidUserToken";
        public const string TestInvalidUserToken = "InvalidUserToken";

        public static readonly AccountRegistrationDTO TestExistingAccountRegistrationDTO = new AccountRegistrationDTO()
        {
            Email = TestExistingUserEmail,
            Username = TestExistingUserUsername,
            Password = TestExistingUserPassword
        };

        public static readonly AccountRegistrationDTO TestNonExistingAccountRegistrationDTOWithValidEmailProvider = new AccountRegistrationDTO()
        {
            Email = TestNonExistingUserWithValidEmailProvider,
            Username = TestNonExistingValidUserUsername,
            Password = TestNonExistingValidUserPassword
        };

        public static readonly AccountRegistrationDTO TestNonExistingAccountRegistrationDTOWithInvalidEmailProvider = new AccountRegistrationDTO()
        {
            Email = TestNonExistingUserWithInvalidEmailProvider,
            Username = TestNonExistingValidUserUsername,
            Password = TestNonExistingValidUserPassword
        };

        public static readonly AccountRegistrationDTO TestNonExistingAccountRegistrationDTOWithInvalidPassword = new AccountRegistrationDTO()
        {
            Email = TestNonExistingUserWithValidEmailProvider,
            Username = TestNonExistingValidUserUsername,
            Password = TestNonExistingInvalidUserPassword
        };

        public static readonly AccountRegistrationDTO TestNonExistingAccountRegistrationDTOWithInvalidEmail = new AccountRegistrationDTO()
        {
            Email = TestExistingUserEmail,
            Username = TestNonExistingValidUserUsername,
            Password = TestNonExistingValidUserPassword
        };

        public static readonly AccountRegistrationDTO TestNonExistingAccountRegistrationDTOWithInvalidUsername = new AccountRegistrationDTO()
        {
            Email = TestNonExistingUserWithValidEmailProvider,
            Username = TestExistingUserUsername,
            Password = TestNonExistingValidUserPassword
        };

        private Mock<IMapper> _mockMapper;
        private IResultFactory _resultFactory;
        private Mock<IEmailManager> _mockEmailManager;
        private Mock<ITokenManager> _mockTokenManager;
        private Mock<IInstaConnectUserManager> _mockInstaConnectUserManager;
        private Mock<IInstaConnectSignInManager> _mockInstaConnectSignInManager;
        private Mock<ITokenCryptographer> _mockTokenCryptographer;
        private IAccountService _accountService;

        [SetUp]
        public void Setup()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockEmailManager = new Mock<IEmailManager>();
            _mockTokenManager = new Mock<ITokenManager>();
            _mockInstaConnectUserManager = new Mock<IInstaConnectUserManager>();
            _mockInstaConnectSignInManager = new Mock<IInstaConnectSignInManager>();
            _mockTokenCryptographer = new Mock<ITokenCryptographer>();
            _accountService = new AccountService(
                _mockMapper.Object, 
                _resultFactory, 
                _mockEmailManager.Object, 
                _mockTokenManager.Object, 
                _mockInstaConnectUserManager.Object, 
                _mockInstaConnectSignInManager.Object,
                _mockTokenCryptographer.Object);

            var testExistingUser = new User()
            {
                Id = TestExistingUserId,
                Email = TestExistingUserEmail,
                UserName = TestExistingUserUsername
            };

            var testExistingUserWithUnconfirmedEmail = new User()
            {
                Id = TestExistingUserIdWithUnconfirmedEmail,
                Email = TestExistingUserWithUnconfirmedEmail,
                UserName = TestExistingUserUsernameWithUnconfirmedEmail
            };

            var testNonExistingUserWithValidEmailProvider = new User()
            {
                Id = TestNonExistingUserId,
                Email = TestNonExistingUserWithValidEmailProvider,
                UserName = TestNonExistingValidUserUsername
            };

            var testNonExistingUserWithInvalidEmailProvider = new User()
            {
                Id = TestNonExistingUserId,
                Email = TestNonExistingUserWithInvalidEmailProvider,
                UserName = TestNonExistingValidUserUsername
            };

            var testNonExistingUserWithInvalidPassword = new User()
            {
                Id = TestNonExistingUserId,
                Email = TestNonExistingUserWithValidEmailProvider,
                UserName = TestNonExistingValidUserUsername
            };

            var testNonExistingUserWithInvalidEmail = new User()
            {
                Id = TestNonExistingUserId,
                Email = TestExistingUserEmail,
                UserName = TestNonExistingValidUserUsername
            };

            var testNonExistingUserWithInvalidUsername = new User()
            {
                Id = TestNonExistingUserId,
                Email = TestNonExistingUserWithValidEmailProvider,
                UserName = TestExistingUserUsername
            };

            _mockInstaConnectUserManager.Setup(m => m.FindByIdAsync(TestExistingUserId))
                .ReturnsAsync(testExistingUser);

            _mockInstaConnectUserManager.Setup(m => m.FindByIdAsync(TestExistingUserIdWithUnconfirmedEmail))
                .ReturnsAsync(testExistingUserWithUnconfirmedEmail);

            _mockInstaConnectUserManager.Setup(m => m.FindByNameAsync(TestExistingUserUsername))
                .ReturnsAsync(testExistingUser);

            _mockInstaConnectUserManager.Setup(m => m.FindByEmailAsync(TestExistingUserEmail))
                .ReturnsAsync(testExistingUser);

            _mockInstaConnectUserManager.Setup(m => m.FindByEmailAsync(TestNonExistingUserWithInvalidEmailProvider))
                .ReturnsAsync(testNonExistingUserWithInvalidEmailProvider);

            _mockInstaConnectUserManager.Setup(m => m.FindByEmailAsync(TestExistingUserWithUnconfirmedEmail))
                .ReturnsAsync(testExistingUserWithUnconfirmedEmail);

            _mockInstaConnectUserManager.Setup(m => m.FindByIdAsync(TestExistingUserId))
                .ReturnsAsync(testExistingUser);

            _mockInstaConnectUserManager.Setup(m => m.IsEmailConfirmedAsync(testExistingUser))
                .ReturnsAsync(true);

            _mockInstaConnectUserManager.Setup(m => m.CreateAsync(testNonExistingUserWithValidEmailProvider, TestNonExistingValidUserPassword))
                .ReturnsAsync(IdentityResult.Success);

            _mockInstaConnectUserManager.Setup(m => m.CreateAsync(testNonExistingUserWithInvalidEmailProvider, TestNonExistingValidUserPassword))
                .ReturnsAsync(IdentityResult.Success);

            _mockInstaConnectUserManager.Setup(m => m.CreateAsync(testNonExistingUserWithValidEmailProvider, TestNonExistingInvalidUserPassword))
                .ReturnsAsync(IdentityResult.Failed());

            _mockInstaConnectUserManager.Setup(m => m.CreateAsync(testNonExistingUserWithInvalidUsername, TestNonExistingValidUserPassword))
                .ReturnsAsync(IdentityResult.Failed());

            _mockInstaConnectUserManager.Setup(m => m.CreateAsync(testNonExistingUserWithInvalidEmail, TestNonExistingValidUserPassword))
                .ReturnsAsync(IdentityResult.Failed());

            _mockMapper.Setup(m => m.Map<User>(TestExistingAccountRegistrationDTO))
                .Returns(testExistingUser);

            _mockMapper.Setup(m => m.Map<User>(TestNonExistingAccountRegistrationDTOWithValidEmailProvider))
                .Returns(testNonExistingUserWithValidEmailProvider);

            _mockMapper.Setup(m => m.Map<User>(TestNonExistingAccountRegistrationDTOWithInvalidEmailProvider))
                .Returns(testNonExistingUserWithInvalidEmailProvider);

            _mockMapper.Setup(m => m.Map<User>(TestNonExistingAccountRegistrationDTOWithInvalidPassword))
                .Returns(testNonExistingUserWithValidEmailProvider);

            _mockMapper.Setup(m => m.Map<User>(TestNonExistingAccountRegistrationDTOWithInvalidEmail))
                .Returns(testNonExistingUserWithInvalidEmail);

            _mockMapper.Setup(m => m.Map<User>(TestNonExistingAccountRegistrationDTOWithInvalidUsername))
                .Returns(testNonExistingUserWithInvalidUsername);

            _mockInstaConnectUserManager.Setup(m => m.GenerateEmailConfirmationTokenAsync(It.IsAny<User>()))
                .ReturnsAsync(TestInvalidUserToken);

            _mockInstaConnectUserManager.Setup(m => m.GeneratePasswordResetTokenAsync(It.IsAny<User>()))
                .ReturnsAsync(TestInvalidUserToken);

            _mockInstaConnectUserManager.Setup(m => m.ConfirmEmailAsync(testExistingUserWithUnconfirmedEmail, TestValidUserToken))
                .ReturnsAsync(IdentityResult.Success);

            _mockInstaConnectUserManager.Setup(m => m.ConfirmEmailAsync(testExistingUserWithUnconfirmedEmail, TestInvalidUserToken))
                .ReturnsAsync(IdentityResult.Failed());

            _mockInstaConnectUserManager.Setup(m => m.ConfirmEmailAsync(testExistingUser, TestValidUserToken))
                .ReturnsAsync(IdentityResult.Failed());

            _mockInstaConnectUserManager.Setup(m => m.ResetPasswordAsync(testExistingUser, TestInvalidUserToken, TestNonExistingValidUserPassword))
                .ReturnsAsync(IdentityResult.Failed());

            _mockInstaConnectUserManager.Setup(m => m.ResetPasswordAsync(testExistingUser, TestValidUserToken, TestNonExistingValidUserPassword))
                .ReturnsAsync(IdentityResult.Success);

            _mockEmailManager.Setup(m => m.SendPasswordResetAsync(TestExistingUserEmail, TestExistingUserId, TestInvalidUserToken))
                .ReturnsAsync(true);

            _mockEmailManager.Setup(m => m.SendEmailConfirmationAsync(TestExistingUserWithUnconfirmedEmail, TestExistingUserIdWithUnconfirmedEmail, TestInvalidUserToken))
                .ReturnsAsync(true);

            _mockEmailManager.Setup(m => m.SendEmailConfirmationAsync(TestNonExistingUserWithValidEmailProvider, TestNonExistingUserId, TestInvalidUserToken))
                .ReturnsAsync(true);

            _mockEmailManager.Setup(m => m.SendEmailConfirmationAsync(TestNonExistingUserWithInvalidEmailProvider, TestNonExistingUserId, TestInvalidUserToken))
                .ReturnsAsync(false);

            _mockInstaConnectSignInManager.Setup(m => m.PasswordSignInAsync(testExistingUser, TestExistingUserPassword, false, false)).
                ReturnsAsync(SignInResult.Success);

            _mockInstaConnectSignInManager.Setup(m => m.PasswordSignInAsync(testExistingUserWithUnconfirmedEmail, TestExistingUserPassword, false, false)).
                ReturnsAsync(SignInResult.Success);

            _mockInstaConnectSignInManager.Setup(m => m.PasswordSignInAsync(testExistingUserWithUnconfirmedEmail, TestNonExistingValidUserPassword, false, false)).
                ReturnsAsync(SignInResult.Failed);

            _mockInstaConnectSignInManager.Setup(m => m.PasswordSignInAsync(testExistingUser, TestNonExistingValidUserPassword, false, false)).
                ReturnsAsync(SignInResult.Failed);

            _mockTokenCryptographer.Setup(m => m.DecodeToken(TestValidUserToken))
                .Returns(TestValidUserToken);

            _mockTokenCryptographer.Setup(m => m.DecodeToken(TestInvalidUserToken))
                .Returns(TestInvalidUserToken);
        }

        [Test]
        public async Task SignUpAsync_HasInvalidUsername_ReturnsBadRequestResult()
        {
            // Act
            var result = await _accountService.SignUpAsync(TestNonExistingAccountRegistrationDTOWithInvalidUsername);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(InstaConnectStatusCode.BadRequest));
        }

        [Test]
        public async Task SignUpAsync_HasInvalidEmail_ReturnsBadRequestResult()
        {
            // Act
            var result = await _accountService.SignUpAsync(TestNonExistingAccountRegistrationDTOWithInvalidEmail);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(InstaConnectStatusCode.BadRequest));
        }

        [Test]
        public async Task SignUpAsync_HasInvalidPassword_ReturnsBadRequestResult()
        {
            // Act
            var result = await _accountService.SignUpAsync(TestNonExistingAccountRegistrationDTOWithInvalidPassword);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(InstaConnectStatusCode.BadRequest));
        }

        [Test]
        public async Task SignUpAsync_HasInvalidEmailProvider_ReturnsBadRequestResult()
        {
            // Act
            var result = await _accountService.SignUpAsync(TestNonExistingAccountRegistrationDTOWithInvalidEmailProvider);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(InstaConnectStatusCode.BadRequest));
        }

        [Test]
        public async Task SignUpAsync_HasValidArguments_ReturnsNoContentResult()
        {
            // Act
            var result = await _accountService.SignUpAsync(TestNonExistingAccountRegistrationDTOWithValidEmailProvider);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(InstaConnectStatusCode.NoContent));
        }

        [Test]
        [TestCase(TestExistingUserEmail, TestExistingUserPassword, InstaConnectStatusCode.OK)]
        [TestCase(TestNonExistingUserEmail, TestExistingUserPassword, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestExistingUserWithUnconfirmedEmail, TestExistingUserPassword, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestNonExistingUserEmail, TestNonExistingValidUserPassword, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestExistingUserWithUnconfirmedEmail, TestNonExistingValidUserPassword, InstaConnectStatusCode.BadRequest)]
        public async Task LoginAsync_HasValidArguments_ReturnsExprectedResult(string email, string password, InstaConnectStatusCode statusCode)
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
        [TestCase(TestExistingUserEmail, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestNonExistingUserEmail, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestNonExistingUserWithInvalidEmailProvider, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestExistingUserWithUnconfirmedEmail, InstaConnectStatusCode.NoContent)]
        public async Task ResendEmailConfirmationTokenAsync_HasValidArguments_ReturnsExprectedResult(string email, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _accountService.ResendEmailConfirmationTokenAsync(email);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestExistingUserEmail, InstaConnectStatusCode.NoContent)]
        [TestCase(TestNonExistingUserEmail, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestNonExistingUserWithInvalidEmailProvider, InstaConnectStatusCode.BadRequest)]
        public async Task SendPasswordResetTokenByEmailAsync_HasValidArguments_ReturnsExprectedResult(string email, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _accountService.SendPasswordResetTokenByEmailAsync(email);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingUserId, TestValidUserToken, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestExistingUserId, TestValidUserToken ,InstaConnectStatusCode.BadRequest)]
        [TestCase(TestExistingUserIdWithUnconfirmedEmail, TestValidUserToken, InstaConnectStatusCode.NoContent)]
        [TestCase(TestExistingUserIdWithUnconfirmedEmail, TestInvalidUserToken, InstaConnectStatusCode.BadRequest)]
        public async Task ConfirmEmailWithTokenAsync_HasValidArguments_ReturnsExprectedResult(string userId, string token ,InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _accountService.ConfirmEmailWithTokenAsync(userId, token);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingUserId, TestValidUserToken, InstaConnectStatusCode.BadRequest)]
        [TestCase(TestExistingUserId, TestValidUserToken, InstaConnectStatusCode.NoContent)]
        [TestCase(TestExistingUserId, TestInvalidUserToken, InstaConnectStatusCode.BadRequest)]
        public async Task ResetPasswordWithTokenAsync_HasValidArguments_ReturnsExprectedResult(string userId, string token, InstaConnectStatusCode statusCode)
        {
            // Arrange
            var accountResetPasswordDTO = new AccountResetPasswordDTO()
            {
                Password = TestNonExistingValidUserPassword
            };

            // Act
            var result = await _accountService.ResetPasswordWithTokenAsync(userId, token, accountResetPasswordDTO);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(TestNonExistingUserId, TestNonExistingValidUserUsername, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingUserId, TestNonExistingValidUserUsername, InstaConnectStatusCode.NoContent)]
        [TestCase(TestExistingUserId, TestExistingUserUsername, InstaConnectStatusCode.NoContent)]
        [TestCase(TestExistingUserIdWithUnconfirmedEmail, TestExistingUserUsername, InstaConnectStatusCode.BadRequest)]
        public async Task EditAsync_HasValidArguments_ReturnsExprectedResult(string userId, string username,InstaConnectStatusCode statusCode)
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
        [TestCase(TestNonExistingUserId, InstaConnectStatusCode.NotFound)]
        [TestCase(TestExistingUserId, InstaConnectStatusCode.NoContent)]
        public async Task DeleteAsync_HasValidArguments_ReturnsExprectedResult(string userId, InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _accountService.DeleteAsync(userId);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Services;
using InstaConnect.Data.Abstraction.Factories;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Business.UnitTests.Tests.Services
{
    public class TokenServiceTests
    {
        private const string ExistingTokenValue = "ExistingTokenValue";
        private const string NonExistingTokenValue = "NonExistingTokenValue";

        private readonly Mock<IMapper> _mockMapper;
        private readonly IResultFactory _resultFactory;
        private readonly Mock<ITokenGenerator> _mockTokenGenerator;
        private readonly Mock<ITokenFactory> _mockTokenFactory;
        private readonly Mock<ITokenRepository> _mockTokenRepository;
        private readonly ITokenService _tokenService;

        public TokenServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _resultFactory = new ResultFactory();
            _mockTokenRepository = new Mock<ITokenRepository>();
            _mockTokenGenerator = new Mock<ITokenGenerator>();
            _mockTokenFactory = new Mock<ITokenFactory>();
            _tokenService = new TokenService(
                _mockMapper.Object, 
                _resultFactory,
                _mockTokenRepository.Object,
                _mockTokenGenerator.Object,
                _mockTokenFactory.Object
                );
        }

        [SetUp]
        public void SetUp() 
        {
            var existingToken = new Token()
            {
                Value = ExistingTokenValue
            };

            var existingTokens = new List<Token>()
            {
                existingToken
            };

            _mockTokenRepository.Setup(m => m.FindEntityAsync(It.IsAny<Expression<Func<Token, bool>>>()))
               .ReturnsAsync((Expression<Func<Token, bool>> expression) => existingTokens.Find(new Predicate<Token>(expression.Compile())));
        }

        [Test]
        [TestCase(ExistingTokenValue, InstaConnectStatusCode.OK)]
        [TestCase(NonExistingTokenValue, InstaConnectStatusCode.NotFound)]
        public async Task GetByValueAsync_HasValue_ReturnsExpectedResult(
            string value,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _tokenService.GetByValueAsync(value);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }

        [Test]
        [TestCase(ExistingTokenValue, InstaConnectStatusCode.NoContent)]
        [TestCase(NonExistingTokenValue, InstaConnectStatusCode.NotFound)]
        public async Task DeleteAsync_HasValue_ReturnsExpectedResult(
            string value,
            InstaConnectStatusCode statusCode)
        {
            // Act
            var result = await _tokenService.DeleteAsync(value);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(statusCode));
        }
    }
}

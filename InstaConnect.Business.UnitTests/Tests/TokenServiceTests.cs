using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.AutoMapper;
using InstaConnect.Business.Factories;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Services;
using InstaConnect.Business.UnitTests.Constants;
using InstaConnect.Data.Abstraction.Repositories;
using Moq;
using NUnit.Framework;

namespace InstaConnect.Business.UnitTests.Tests
{
    [TestFixture]
    public class TokenServiceTests
    {
        private IMapper _mapper;
        private IResultFactory _resultFactory;
        private ITokenService _tokenService;
        private Mock<ITokenHandler> _tokenHandlerMock;
        private Mock<ITokenRepository> _tokenRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<InstaConnectProfile>();
            });

            _mapper = config.CreateMapper();
            _resultFactory = new ResultFactory();
            _tokenHandlerMock = new Mock<ITokenHandler>();
            _tokenRepositoryMock = new Mock<ITokenRepository>();
            _tokenService = new TokenService(_mapper, _tokenRepositoryMock.Object, _tokenHandlerMock.Object, _resultFactory);

            _tokenRepositoryMock
                .Setup(s => s.FindEntityAsync(s => s.Value == TokenTestConstants.TestExistingTokenValue))
                .ReturnsAsync(TokenTestConstants.TestExistingToken);

            _tokenRepositoryMock
                .Setup(s => s.FindEntityAsync(s => s.Value == TokenTestConstants.TestNonExistingTokenValue))
                .ReturnsAsync(TokenTestConstants.TestNonExistingToken);
        }

        [Test]
        [TestCase(TokenTestConstants.TestExistingTokenValue, InstaConnectStatusCode.OK)]
        [TestCase(TokenTestConstants.TestNonExistingTokenValue, InstaConnectStatusCode.Unauthorized)]
        public async Task GetByValueAsync_HasDifferentValues_ReturnsExpectedStatusCode(string value, InstaConnectStatusCode instaConnectStatusCode)
        {
            // Act
            var result = await _tokenService.GetByValueAsync(value);

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(instaConnectStatusCode));
        }
    }
}

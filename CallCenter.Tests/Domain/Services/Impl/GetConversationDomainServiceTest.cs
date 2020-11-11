using Domain.Models;
using Domain.Services;
using Domain.Services.Impl;
using System.Collections.Generic;
using CallCenter.Tests.Domain.Services.Fake;

namespace CallCenter.Tests.Domain.Services.Impl
{
    using Infrastructure.Services;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class GetConversationDomainServiceTest
    {
        [Test]
        public void GetConversationDomainService_IsNotNull_Conversations()
        {
            var sut = GetSut(
                out Mock<IReadFileAppService> readFileAppServiceMock,
                out Mock<IGetRatingDomainService> getRatingDomainServiceMock);

            readFileAppServiceMock.Setup(x => x.GetFileContent(It.IsAny<string>())).Returns(FakeMessages.Messages);

            getRatingDomainServiceMock.Setup(x => x.GetRating(It.IsAny<List<string>>())).Returns(new Rating
            {
                Starts = 3
            });

            var result = sut.GetConversation();
            Assert.IsNotNull(result);

            readFileAppServiceMock.Verify(x => x.GetFileContent(It.IsAny<string>()), Times.Once);
            getRatingDomainServiceMock.Verify(x => x.GetRating(It.IsAny<List<string>>()), Times.Exactly(5));


        }

        private IGetConversationDomainService GetSut(
            out Mock<IReadFileAppService> readFileAppServiceMock,
            out Mock<IGetRatingDomainService> getRatingDomainServiceMock)
        {
            readFileAppServiceMock = new Mock<IReadFileAppService>(MockBehavior.Strict);
            getRatingDomainServiceMock = new Mock<IGetRatingDomainService>(MockBehavior.Strict);
            return new GetConversationDomainService(readFileAppServiceMock.Object, getRatingDomainServiceMock.Object);
        }
    }
}

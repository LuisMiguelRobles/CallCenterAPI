using System;
using CallCenter.Tests.Domain.Services.Fake;
using Domain.Helpers;
using Domain.Services;
using Domain.Services.Impl;
using Moq;

namespace CallCenter.Tests.Domain.Services.Impl
{
    using NUnit.Framework;
    [TestFixture]
    public class GetRatingDomainServiceTest
    {
        [Test]
        public void GetRatingDomainService_IsNotNull_Rating()
        {
            var sut = GetSut(out Mock<IDomainHelper> domainHelperMock);
            domainHelperMock.Setup(x => x.GeDateTime(It.IsAny<string>())).Returns(DateTime.Now);
            var result = sut.GetRating(FakeMessages.Messages());
            Assert.IsNotNull(result);

            domainHelperMock.Verify(x => x.GeDateTime(It.IsAny<string>()), Times.Exactly(2));
        }

        private IGetRatingDomainService GetSut(out Mock<IDomainHelper> domainHelperMock)
        {
            domainHelperMock= new Mock<IDomainHelper>(MockBehavior.Strict);
            return new GetRatingDomainService(domainHelperMock.Object);
        }
    }
}

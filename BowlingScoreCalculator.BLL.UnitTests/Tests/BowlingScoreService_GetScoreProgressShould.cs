using BowlingScoreCalculator.BLL.Models.Request;
using BowlingScoreCalculator.BLL.Models.Response;
using BowlingScoreCalculator.BLL.Services;
using BowlingScoreCalculator.BLL.UnitTests.TestData;
using BowlingScoreCalculator.Core.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace BowlingScoreCalculator.BLL.UnitTests.Tests
{
    [TestClass]
    public class BowlingScoreService_GetScoreProgressShould
    {
        private BowlingScoreService bowlingScoreService;

        [TestInitialize]
        public void TestInitialize()
        {
            bowlingScoreService = new BowlingScoreService();
        }

        [DynamicData(nameof(BowlingScoreService_GetScoreProgressShould_TestData.GetReturnExpectedResponseTestData), typeof(BowlingScoreService_GetScoreProgressShould_TestData), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void GetScoreProgress_ReturnExpectedResponse(GetScoreProgressRequest request, GetScoreProgressResponse expectedResponse)
        {
            GetScoreProgressResponse result = bowlingScoreService.GetScoreProgress(request);

            Assert.AreEqual(expectedResponse.GameCompleted, result.GameCompleted);
            CollectionAssert.AreEqual((ICollection)expectedResponse.FrameProgressScores, (ICollection)result.FrameProgressScores);
        }

        [DynamicData(nameof(BowlingScoreService_GetScoreProgressShould_TestData.GetThrowBusinessArgumentExceptionTestData), typeof(BowlingScoreService_GetScoreProgressShould_TestData), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void GetScoreProgress_ThrowBusinessArgumentException_IfGetScoreProgressRequestIsInvalid(GetScoreProgressRequest request)
        {
            Assert.ThrowsException<BusinessArgumentException>(() => bowlingScoreService.GetScoreProgress(request));
        }
    }
}

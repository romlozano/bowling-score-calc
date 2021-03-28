using BowlingScoreCalculator.BLL.Models.Request;
using BowlingScoreCalculator.BLL.Models.Response;
using System.Collections.Generic;

namespace BowlingScoreCalculator.BLL.UnitTests.TestData
{
    public class BowlingScoreService_GetScoreProgressShould_TestData
    {
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { GetPerfectGameRequest, GetPerfectGameResponse };
            yield return new object[] { GetGutterBallGameRequest, GetGutterBallGameResponse };
            yield return new object[] { GetSixFramesCompletedAllThrowsOneRequest, GetSixFramesCompletedAllThrowsOneResponse };
            yield return new object[] { GetSevenFramesCompletedWithSpareAndStrikesRequest, GetSevenFramesCompletedWithSpareAndStrikesResponse };
            // TODO: Handle gutter ball game
        }

        private static GetScoreProgressRequest GetPerfectGameRequest => new GetScoreProgressRequest
        {
            PinsDowned = new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }
        };
        private static GetScoreProgressResponse GetPerfectGameResponse => new GetScoreProgressResponse
        {
            FrameProgressScores = new List<string> { "30", "60", "90", "120", "150", "180", "210", "240", "270", "300" },
            GameCompleted = true
        };
        private static GetScoreProgressRequest GetGutterBallGameRequest => new GetScoreProgressRequest
        {
            PinsDowned = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };
        private static GetScoreProgressResponse GetGutterBallGameResponse => new GetScoreProgressResponse
        {
            FrameProgressScores = new List<string> { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
            GameCompleted = true
        };
        private static GetScoreProgressRequest GetSixFramesCompletedAllThrowsOneRequest => new GetScoreProgressRequest
        {
            PinsDowned = new List<int> { 1,1,1,1,1,1,1,1,1,1,1,1 }
        };
        private static GetScoreProgressResponse GetSixFramesCompletedAllThrowsOneResponse => new GetScoreProgressResponse
        {
            FrameProgressScores = new List<string> { "2", "4", "6", "8", "10", "12" },
            GameCompleted = false
        };
        private static GetScoreProgressRequest GetSevenFramesCompletedWithSpareAndStrikesRequest => new GetScoreProgressRequest
        {
            PinsDowned = new List<int> { 1, 1, 1, 1, 9, 1, 2, 8, 9, 1, 10, 10 }
        };
        private static GetScoreProgressResponse GetSevenFramesCompletedWithSpareAndStrikesResponse => new GetScoreProgressResponse
        {
            FrameProgressScores = new List<string> { "2", "4", "16", "35", "55", "*", "*" },
            GameCompleted = false
        };
    }
}

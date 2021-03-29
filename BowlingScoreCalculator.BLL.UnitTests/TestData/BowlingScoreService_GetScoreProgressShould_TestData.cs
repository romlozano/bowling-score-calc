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
            yield return new object[] { GetNoSpareNoStrikeCompletedGameRequest, GetNoSpareNoStrikeCompletedGameResponse };
            yield return new object[] { GetAllSparesCompletedGameRequest, GetAllSparesCompletedGameResponse };
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
            PinsDowned = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
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
        private static GetScoreProgressRequest GetNoSpareNoStrikeCompletedGameRequest => new GetScoreProgressRequest
        {
            PinsDowned = new List<int> { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 }
        };
        private static GetScoreProgressResponse GetNoSpareNoStrikeCompletedGameResponse => new GetScoreProgressResponse
        {
            FrameProgressScores = new List<string> { "3", "6", "9", "12", "15", "18", "21", "24", "27", "30" },
            GameCompleted = true
        };
        private static GetScoreProgressRequest GetAllSparesCompletedGameRequest => new GetScoreProgressRequest
        {
            PinsDowned = new List<int> { 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1 }
        };
        private static GetScoreProgressResponse GetAllSparesCompletedGameResponse => new GetScoreProgressResponse
        {
            FrameProgressScores = new List<string> { "11", "22", "33", "44", "55", "66", "77", "88", "99", "110" },
            GameCompleted = true
        };
    }
}

using BowlingScoreCalculator.BLL.Models.Request;
using BowlingScoreCalculator.BLL.Models.Response;
using System.Collections.Generic;

namespace BowlingScoreCalculator.BLL.UnitTests.TestData
{
    public class BowlingScoreService_GetScoreProgressShould_TestData
    {
        public static IEnumerable<object[]> GetReturnExpectedResponseTestData()
        {
            yield return new object[] { PerfectGameRequest, PerfectGameResponse };
            yield return new object[] { GutterBallGameRequest, GutterBallGameResponse };
            yield return new object[] { SixFramesCompletedAllThrowsOneRequest, SixFramesCompletedAllThrowsOneResponse };
            yield return new object[] { SevenFramesCompletedWithSpareAndStrikesRequest, SevenFramesCompletedWithSpareAndStrikesResponse };
            yield return new object[] { NoSpareNoStrikeCompletedGameRequest, NoSpareNoStrikeCompletedGameResponse };
            yield return new object[] { AllSparesCompletedGameRequest, AllSparesCompletedGameResponse };
        }

        public static IEnumerable<object[]> GetThrowBusinessArgumentExceptionTestData()
        {
            yield return new object[] { RequestWithItemBelowMinValue };
            yield return new object[] { RequestWithItemAboveMaxValue };
        }

        private static GetScoreProgressRequest PerfectGameRequest => new GetScoreProgressRequest
        {
            PinsDowned = new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }
        };
        private static GetScoreProgressResponse PerfectGameResponse => new GetScoreProgressResponse
        {
            FrameProgressScores = new List<string> { "30", "60", "90", "120", "150", "180", "210", "240", "270", "300" },
            GameCompleted = true
        };
        private static GetScoreProgressRequest GutterBallGameRequest => new GetScoreProgressRequest
        {
            PinsDowned = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };
        private static GetScoreProgressResponse GutterBallGameResponse => new GetScoreProgressResponse
        {
            FrameProgressScores = new List<string> { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
            GameCompleted = true
        };
        private static GetScoreProgressRequest SixFramesCompletedAllThrowsOneRequest => new GetScoreProgressRequest
        {
            PinsDowned = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };
        private static GetScoreProgressResponse SixFramesCompletedAllThrowsOneResponse => new GetScoreProgressResponse
        {
            FrameProgressScores = new List<string> { "2", "4", "6", "8", "10", "12" },
            GameCompleted = false
        };
        private static GetScoreProgressRequest SevenFramesCompletedWithSpareAndStrikesRequest => new GetScoreProgressRequest
        {
            PinsDowned = new List<int> { 1, 1, 1, 1, 9, 1, 2, 8, 9, 1, 10, 10 }
        };
        private static GetScoreProgressResponse SevenFramesCompletedWithSpareAndStrikesResponse => new GetScoreProgressResponse
        {
            FrameProgressScores = new List<string> { "2", "4", "16", "35", "55", "*", "*" },
            GameCompleted = false
        };
        private static GetScoreProgressRequest NoSpareNoStrikeCompletedGameRequest => new GetScoreProgressRequest
        {
            PinsDowned = new List<int> { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 }
        };
        private static GetScoreProgressResponse NoSpareNoStrikeCompletedGameResponse => new GetScoreProgressResponse
        {
            FrameProgressScores = new List<string> { "3", "6", "9", "12", "15", "18", "21", "24", "27", "30" },
            GameCompleted = true
        };
        private static GetScoreProgressRequest AllSparesCompletedGameRequest => new GetScoreProgressRequest
        {
            PinsDowned = new List<int> { 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1 }
        };
        private static GetScoreProgressResponse AllSparesCompletedGameResponse => new GetScoreProgressResponse
        {
            FrameProgressScores = new List<string> { "11", "22", "33", "44", "55", "66", "77", "88", "99", "110" },
            GameCompleted = true
        };
        private static GetScoreProgressRequest RequestWithItemBelowMinValue => new GetScoreProgressRequest
        {
            PinsDowned = new List<int> { 1, 9, 1, 9, -1, 9 }
        };
        private static GetScoreProgressRequest RequestWithItemAboveMaxValue => new GetScoreProgressRequest
        {
            PinsDowned = new List<int> { 1, 9, 1, 9, 11, 9 }
        };
    }
}

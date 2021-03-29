using BowlingScoreCalculator.BLL.Models.Request;
using BowlingScoreCalculator.BLL.Models.Response;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScoreCalculator.BLL.Services
{
    public class BowlingScoreService : IBowlingScoreService
    {
        // TODO: Refactor the following const to appSettings.json
        const int PinCount = 10;
        const int MaxFramesCount = 10;
        const string PendingIndicator = "*";

        public GetScoreProgressResponse GetScoreProgress(GetScoreProgressRequest request)
        {
            GetScoreProgressResponse response = new GetScoreProgressResponse();
            List<int> pinsDowned = request.PinsDowned.ToList();
            int frameProgressScore = 0;
            int completedFrameCount = 0;
            bool isBonusThrow = false;
            // TODO: Refactor and optimise this if possible
            for (int index = 0; index < pinsDowned.Count; index++)
            {
                int currentPinDowned = pinsDowned[index];
                bool isStrike = currentPinDowned == PinCount;
                bool isSpare = false;
                
                if (isStrike == false && (index + 1) < pinsDowned.Count)
                {
                    isSpare = currentPinDowned + pinsDowned[index + 1] == PinCount;
                }
                
                if (isBonusThrow)
                {
                    continue;
                }

                if (isStrike)
                {
                    bool canCompleteStrike = (index + 2) < pinsDowned.Count;
                    if (canCompleteStrike)
                    {
                        int score = PinCount + pinsDowned[index + 1] + pinsDowned[index + 2];
                        frameProgressScore += score;
                        response.FrameProgressScores.Add(frameProgressScore.ToString());
                        completedFrameCount++;
                    }
                    else
                    {
                        response.FrameProgressScores.Add(PendingIndicator);
                    }
                }
                else if (isSpare)
                {
                    bool canCompleteSpare = (index + 2) < pinsDowned.Count;
                    if (canCompleteSpare)
                    {
                        int score = currentPinDowned + pinsDowned[index + 1] + pinsDowned[index + 2];
                        frameProgressScore += score;
                        response.FrameProgressScores.Add(frameProgressScore.ToString());
                        completedFrameCount++;
                        index++;
                    }
                    else
                    {
                        response.FrameProgressScores.Add(PendingIndicator);
                    }
                }
                else
                {
                    if ((index + 1) < pinsDowned.Count)
                    {
                        int score = currentPinDowned + pinsDowned[index + 1];
                        frameProgressScore += score;
                        response.FrameProgressScores.Add(frameProgressScore.ToString());
                        completedFrameCount++;
                        index++;
                    }
                    else
                    {
                        int score = currentPinDowned;
                        frameProgressScore += score;
                        response.FrameProgressScores.Add(frameProgressScore.ToString());
                    }
                }
                isBonusThrow = completedFrameCount == MaxFramesCount && (isSpare || isStrike);
            }
            response.GameCompleted = completedFrameCount == MaxFramesCount;

            return response;
        }
    }
}

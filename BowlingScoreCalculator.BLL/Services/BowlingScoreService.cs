using BowlingScoreCalculator.BLL.Models.Request;
using BowlingScoreCalculator.BLL.Models.Response;
using BowlingScoreCalculator.Core.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScoreCalculator.BLL.Services
{
    public class BowlingScoreService : IBowlingScoreService
    {
        // TODO: Refactor the following const to appSettings.json
        const int MinPinCount = 0;
        const int MaxPinCount = 10;
        const int MaxFramesCount = 10;
        const int MaxThrowsCount = 21;
        const string PendingIndicator = "*";

        public GetScoreProgressResponse GetScoreProgress(GetScoreProgressRequest request)
        {
            if (request.PinsDowned.Any(p => p > MaxPinCount || p < MinPinCount))
            {
                throw new BusinessArgumentException("A pin count is outside of allowable values", nameof(request.PinsDowned));
            }

            List<int> pinsDowned = request.PinsDowned.ToList();
            if (pinsDowned.Count > MaxThrowsCount)
            {
                throw new BusinessArgumentException("Total number of throws exceeds the maximum value", nameof(request.PinsDowned));
            }

            GetScoreProgressResponse response = new GetScoreProgressResponse();
            int frameProgressScore = 0;
            int completedFrameCount = 0;
            bool isBonusThrow = false;
            // TODO: Refactor and optimise this if possible
            for (int index = 0; index < pinsDowned.Count; index++)
            {
                int currentPinDowned = pinsDowned[index];
                bool isStrike = currentPinDowned == MaxPinCount;
                bool isSpare = false;
                
                if (isStrike == false && (index + 1) < pinsDowned.Count)
                {
                    isSpare = currentPinDowned + pinsDowned[index + 1] == MaxPinCount;
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
                        int score = MaxPinCount + pinsDowned[index + 1] + pinsDowned[index + 2];
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

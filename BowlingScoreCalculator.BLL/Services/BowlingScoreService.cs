using BowlingScoreCalculator.BLL.Models.Request;
using BowlingScoreCalculator.BLL.Models.Response;
using System.Collections.Generic;

namespace BowlingScoreCalculator.BLL.Services
{
    public class BowlingScoreService : IBowlingScoreService
    {
        public GetScoreProgressResponse GetScoreProgress(GetScoreProgressRequest request)
        {
            return new GetScoreProgressResponse
            {

            };
        }
    }
}

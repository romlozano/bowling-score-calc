using BowlingScoreCalculator.BLL.Models.Request;
using BowlingScoreCalculator.BLL.Models.Response;

namespace BowlingScoreCalculator.BLL.Services
{
    public interface IBowlingScoreService
    {
        GetScoreProgressResponse GetScoreProgress(GetScoreProgressRequest request);
    }
}

using System.Collections.Generic;

namespace BowlingScoreCalculator.BLL.Models.Response
{
    public class GetScoreProgressResponse
    {
        public GetScoreProgressResponse()
        {
            FrameProgressScores = new List<string>();
        }

        public ICollection<string> FrameProgressScores { get; set; }
        public bool GameCompleted { get; set; }
    }
}

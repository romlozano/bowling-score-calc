using System.Collections.Generic;

namespace BowlingScoreCalculator.WebAPI.Models.Response
{
    public class GetScoreProgressResponse
    {
        public GetScoreProgressResponse()
        {
            FrameProgressScores = new List<string>();
        }

        /// <summary>
        /// Shows frame progress scores
        /// '*' is used for pending scores
        /// </summary>
        public ICollection<string> FrameProgressScores { get; set; }
        /// <summary>
        /// Indicates if the game is completed
        /// </summary>
        public bool GameCompleted { get; set; }
    }
}

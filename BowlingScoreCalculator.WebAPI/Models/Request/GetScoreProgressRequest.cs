using System.Collections.Generic;

namespace BowlingScoreCalculator.WebAPI.Models.Request
{
    public class GetScoreProgressRequest
    {
        /// <summary>
        /// An array of pin count for each throw
        /// </summary>
        public IEnumerable<int> PinsDowned { get; set; }
    }
}

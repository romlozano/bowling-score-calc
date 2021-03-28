using System.Collections.Generic;

namespace BowlingScoreCalculator.BLL.Models.Request
{
    public class GetScoreProgressRequest
    {
        public IEnumerable<int> PinsDowned { get; set; }
    }
}

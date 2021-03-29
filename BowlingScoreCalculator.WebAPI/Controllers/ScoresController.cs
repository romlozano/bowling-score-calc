using BowlingScoreCalculator.BLL.Services;
using BowlingScoreCalculator.WebAPI.Models.Request;
using BowlingScoreCalculator.WebAPI.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BowlingScoreCalculator.WebAPI.Controllers
{
    [Route("scores")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly IBowlingScoreService bowlingScoreService;

        public ScoresController(IBowlingScoreService bowlingScoreService)
        {
            this.bowlingScoreService = bowlingScoreService;
        }

        // POST /scores
        /// <summary>
        /// Gets the frame progress scores with a flag indicating if the game is completed
        /// </summary>
        /// <param name="request">GetScoreProgressRequest</param>
        /// <returns>GetScoreProgressResponse</returns>
        /// <response code="200">GetScoreProgressResponse</response>
        /// <response code="400"></response>
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetScoreProgressResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<GetScoreProgressResponse> GetScores(GetScoreProgressRequest request)
        {
            GetScoreProgressResponse response = bowlingScoreService.GetScoreProgress(request);

            return Ok();
        }
    }
}

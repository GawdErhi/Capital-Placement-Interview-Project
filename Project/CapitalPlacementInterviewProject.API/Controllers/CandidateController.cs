using CapitalPlacementInterviewProject.API.DTO;
using CapitalPlacementInterviewProject.API.HelperModels;
using Microsoft.AspNetCore.Mvc;
using ILogger = CapitalPlacementInterviewProject.API.Services.Contracts.ILogger;

namespace CapitalPlacementInterviewProject.API.Controllers
{
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger _logger;
        public CandidateController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions([FromQuery]string programDetailId)
        {
            try
            {
                return Ok(await Task.FromResult(true));
            }catch(Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponseModel<string> { Error = true, Errors = new List<string> { "something went wrong, please try again later" }, Data = null });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SubmitApplication([FromBody]ProgramCandidateDTO programCandidate)
        {
            try
            {
                return Ok(await Task.FromResult(true));
            }catch(Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponseModel<string> { Error = true, Errors = new List<string> { "something went wrong, please try again later" }, Data = null });
            }
        }
    }
}

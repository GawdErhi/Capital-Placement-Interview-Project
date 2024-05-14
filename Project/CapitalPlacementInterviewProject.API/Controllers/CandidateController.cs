using CapitalPlacementInterviewProject.API.Controllers.Handlers.Contracts;
using CapitalPlacementInterviewProject.API.DTO;
using CapitalPlacementInterviewProject.API.Extensions;
using CapitalPlacementInterviewProject.API.HelperModels;
using Microsoft.AspNetCore.Mvc;
using ILogger = CapitalPlacementInterviewProject.API.Services.Contracts.ILogger;

namespace CapitalPlacementInterviewProject.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateHandler _handler;
        private readonly ILogger _logger;
        public CandidateController(ICandidateHandler handler, ILogger logger)
        {
            _handler = handler;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions([FromQuery]string programDetailId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(programDetailId)) { return StatusCode(StatusCodes.Status400BadRequest, new APIResponseModel<string> { Error = true, Errors = new List<string> { "No program detail specified" }, Data = null }); }
                return Ok(await _handler.GetQuestions(programDetailId));
            }catch(Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponseModel<string> { Error = true, Errors = new List<string> { "something went wrong, please try again later" }, Data = null });
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> SubmitApplication([FromBody]ProgramCandidateDTO programCandidate)
        {
            try
            {
                if (!ModelState.IsValid) { return BadRequest(new APIResponseModel<string> { Error = true, Errors = ModelState.GetErrors(), Data = null }); }
                return Ok(await _handler.ValidateAndSubmitApplication(programCandidate));
            }catch(Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponseModel<string> { Error = true, Errors = new List<string> { "something went wrong, please try again later" }, Data = null });
            }
        }
    }
}

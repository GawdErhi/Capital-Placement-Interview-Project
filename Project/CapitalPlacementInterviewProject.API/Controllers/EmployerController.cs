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
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerHandler _handler;
        private readonly ILogger _logger;
        public EmployerController(IEmployerHandler handler, ILogger logger)
        {
            _handler = handler;
            _logger = logger;
        }


        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateProgramAndApplicationForm([FromBody]ProgramDetailDTO programDetail)
        {
            try
            {
                if (!ModelState.IsValid) { return BadRequest(new APIResponseModel<string> { Error = true, Errors = ModelState.GetErrors(), Data = null }); }
                return Ok(await _handler.ValidateThenCreateProgramAndApplicationForm(programDetail));
            }catch(Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponseModel<string> { Error = true, Errors = new List<string> { "something went wrong, please try again later" }, Data = null });
            }
        }

        [HttpPut]
        [Consumes("application/json")]
        public async Task<IActionResult> EditApplicationQuestion([FromBody] ProgramDetailQuestionTypeDTO questionType)
        {
            try
            {
                if (!ModelState.IsValid) { return BadRequest(new APIResponseModel<string> { Error = true, Errors = ModelState.GetErrors(), Data = null }); }
                return Ok(await _handler.EditQuestion(questionType));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponseModel<string> { Error = true, Errors = new List<string> { "something went wrong, please try again later" }, Data = null });
            }
        }
    }
}

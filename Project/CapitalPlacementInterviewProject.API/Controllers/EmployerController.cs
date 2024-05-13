using CapitalPlacementInterviewProject.API.DTO;
using CapitalPlacementInterviewProject.API.HelperModels;
using Microsoft.AspNetCore.Mvc;
using ILogger = CapitalPlacementInterviewProject.API.Services.Contracts.ILogger;

namespace CapitalPlacementInterviewProject.API.Controllers
{
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly ILogger _logger;
        public EmployerController(ILogger logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProgramAndApplicationForm([FromBody]ProgramDetailDTO programDetail)
        {
            try
            {
                return Ok(await Task.FromResult(() => true));
            }catch(Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponseModel<string> { Error = true, Errors = new List<string> { "something went wrong, please try again later" }, Data = null });
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditApplicationQuestion([FromBody] ProgramDetailQuestionTypeDTO questionType)
        {
            try
            {
                return Ok(await Task.FromResult(() => true));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponseModel<string> { Error = true, Errors = new List<string> { "something went wrong, please try again later" }, Data = null });
            }
        }
    }
}

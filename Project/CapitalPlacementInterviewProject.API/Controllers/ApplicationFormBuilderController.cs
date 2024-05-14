using CapitalPlacementInterviewProject.API.Controllers.Handlers.Contracts;
using CapitalPlacementInterviewProject.API.DTO;
using CapitalPlacementInterviewProject.API.Extensions;
using CapitalPlacementInterviewProject.API.HelperModels;
using CapitalPlacementInterviewProject.API.Models;
using Microsoft.AspNetCore.Mvc;
using ILogger = CapitalPlacementInterviewProject.API.Services.Contracts.ILogger;

namespace CapitalPlacementInterviewProject.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ApplicationFormBuilderController : ControllerBase
    {
        private readonly IApplicationFormBuilderHandler _handler;
        private readonly ILogger _logger;
        public ApplicationFormBuilderController(IApplicationFormBuilderHandler handler, ILogger logger)
        {
            _handler = handler;
            _logger = logger;
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddPersonalInfoField([FromBody] PersonalInfoFieldDTO personalInfoField)
        {
            try
            {
                if (!ModelState.IsValid) { return BadRequest(new APIResponseModel<string> { Error = true, Errors = ModelState.GetErrors(), Data = null }); }
                return Ok(await _handler.CreatePersonalInfoField(personalInfoField));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponseModel<string> { Error = true, Errors = new List<string> { "something went wrong, please try again later" }, Data = null });
            }
        }

        [HttpGet]
        public async Task<IActionResult> PersonalInfoFields()
        {
            try
            {
                return Ok(await _handler.GetPersonalInfoFields());
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponseModel<string> { Error = true, Errors = new List<string> { "something went wrong, please try again later" }, Data = null });
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddQuestionType([FromBody] QuestionTypeDTO questionType)
        {
            try
            {
                if (!ModelState.IsValid) { return BadRequest(new APIResponseModel<string> { Error = true, Errors = ModelState.GetErrors(), Data = null }); }
                return Ok(await _handler.CreateQuestionType(questionType));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponseModel<string> { Error = true, Errors = new List<string> { "something went wrong, please try again later" }, Data = null });
            }
        }

        [HttpGet]
        public async Task<IActionResult> QuestionTypes()
        {
            try
            {
                return Ok(await _handler.GetQuestionTypes());
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponseModel<string> { Error = true, Errors = new List<string> { "something went wrong, please try again later" }, Data = null });
            }
        }
    }
}

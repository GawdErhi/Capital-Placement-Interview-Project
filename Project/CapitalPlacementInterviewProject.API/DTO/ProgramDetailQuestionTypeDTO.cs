using System.ComponentModel.DataAnnotations;

namespace CapitalPlacementInterviewProject.API.DTO
{
    public class ProgramDetailQuestionTypeDTO
    {
        [Required]
        public string Id { get; set; }

        public string ProgramDetailId { get; set; }

        public string QuestionTypeId { get; set; }

        public string QuestionTypeName { get; set; }

        public string Question { get; set; }

        public int MaxAllowedChoices { get; set; }

        public bool EnableOtherOption { get; set; }

        public List<ProgramDetailQuestionTypeChoiceDTO> Choices { get; set; }
    }
}

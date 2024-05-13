using System.ComponentModel.DataAnnotations;

namespace CapitalPlacementInterviewProject.API.DTO
{
    public class ProgramDetailDTO
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public List<ProgramDetailPersonalInfoFieldDTO> PersonalInfoFields { get; set; }

        public List<ProgramDetailQuestionTypeDTO> Questions { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CapitalPlacementInterviewProject.API.DTO
{
    public class ProgramCandidateDTO
    {
        public string Id { get; set; }

        [Required]
        public string ProgramDetailId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Nationality { get; set; }

        public string CurrentResidence { get; set; }

        public string IdNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public List<ProgramCandidateQuestionTypeAnswerDTO> Answers { get; set; }
    }
}

namespace CapitalPlacementInterviewProject.API.DTO
{
    public class ProgramDetailQuestionTypeDTO
    {
        public string Id { get; set; }

        public string ProgramDetailId { get; set; }

        public string QuestionTypeId { get; set; }

        public string Question { get; set; }

        public int MaxAllowedChoices { get; set; }

        public bool EnableOtherOption { get; set; }
    }
}

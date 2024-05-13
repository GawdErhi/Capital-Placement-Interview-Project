namespace CapitalPlacementInterviewProject.API.Models
{
    public class ProgramDetailQuestionType : BaseModel
    {
        public virtual string ProgramDetailId { get; set; }

        public virtual string QuestionTypeId { get; set; }

        public virtual string Question { get; set; }

        public virtual int MaxAllowedChoices { get; set; }

        public virtual bool EnableOtherOption { get; set; }
    }
}

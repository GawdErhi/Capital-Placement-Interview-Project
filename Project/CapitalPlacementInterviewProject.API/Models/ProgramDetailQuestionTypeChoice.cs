namespace CapitalPlacementInterviewProject.API.Models
{
    public class ProgramDetailQuestionTypeChoice : BaseModel
    {
        public virtual string ProgramDetailQuestionTypeId { get; set; }

        public virtual string Choice { get; set; }
    }
}

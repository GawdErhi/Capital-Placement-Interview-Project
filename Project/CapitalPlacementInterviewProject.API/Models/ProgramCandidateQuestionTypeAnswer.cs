namespace CapitalPlacementInterviewProject.API.Models
{
    public class ProgramCandidateQuestionTypeAnswer : BaseModel
    {
        public virtual string ProgramCandidateId { get; set; }

        public virtual string ProgramDetailQuestionTypeId { get; set; }

        public virtual string Answer { get; set; }
    }
}

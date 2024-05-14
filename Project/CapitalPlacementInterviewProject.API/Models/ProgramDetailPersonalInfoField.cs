namespace CapitalPlacementInterviewProject.API.Models
{
    public class ProgramDetailPersonalInfoField : BaseModel
    {
        public virtual string ProgramDetailId { get; set; }

        public virtual string PersonalInfoFieldId { get; set; }

        public  virtual bool Internal { get; set; }
    }
}

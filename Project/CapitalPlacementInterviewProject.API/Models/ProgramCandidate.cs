namespace CapitalPlacementInterviewProject.API.Models
{
    public class ProgramCandidate : BaseModel
    {
        public virtual string ProgramDetailId { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Email { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string Nationality { get; set; }

        public virtual string CurrentResidence { get; set; }

        public virtual string IdNumber { get; set; }

        public virtual DateTime DateOfBirth { get; set; }

        public virtual string Gender { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CapitalPlacementInterviewProject.API.DTO
{
    public class PersonalInfoFieldDTO
    {
        public string Id { get; set; }

        [Required]
        public string FieldName { get; set; }
    }
}

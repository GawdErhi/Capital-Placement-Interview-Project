using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CapitalPlacementInterviewProject.API.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static List<string> GetErrors(this ModelStateDictionary modelStateDictionary)
        {
            List<string> errors = new List<string>();
            foreach (var value in modelStateDictionary.Values)
            {
                errors.AddRange(value.Errors.Select(x => x.ErrorMessage));
            }
            return errors;
        }
    }
}

namespace CapitalPlacementInterviewProject.API.HelperModels
{
    public class APIResponseModel<T>
    {
        public bool Error { get; set; }

        public List<string> Errors { get; set; }

        public T Data { get; set; }
    }
}

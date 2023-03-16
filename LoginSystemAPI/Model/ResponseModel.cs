namespace LoginSystemAPI.Model
{
    public class ResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; } = null!;
        public object data { get; set; } = null!;
    }
}

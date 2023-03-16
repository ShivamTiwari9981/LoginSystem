namespace LoginSystemAPI.Model
{
    public class BaseViewModel
    {
        public string Status { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

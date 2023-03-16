namespace LoginSystemAPI.Model
{
    public class UserViewModel: BaseViewModel
    {
        public string UsrNam { get; set; } = null!;
        public string UsrPwd { get; set; } = null!;
        public string UsrMobile { get; set; } = null!;
        public string UsrEmail { get; set; } = null!;
        public int? RoleId { get; set; }
    }
}

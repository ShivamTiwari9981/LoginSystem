namespace LoginSystemAPI.Model
{
    public class ModuleViewModel
    {
        public int module_id { get; set; }
        public string? module_nam { get; set; }
        public string? module_img { get; set; }
        public string? status { get; set; }
        public List<SubModuleViewModel> subModule { get; set;}
        public ModuleViewModel() { 
        subModule= new List<SubModuleViewModel>();
        }
    }

    public class SubModuleViewModel
    {
        public int module_id { get; set; }
        public int view_id { get; set; }
        public string? view_nam { get; set; }
        public string? module_img { get; set; }
        public string? status { get; set; }
        public string? actionLink { get; set; }
        public SubModuleViewModel() { }
    }

}

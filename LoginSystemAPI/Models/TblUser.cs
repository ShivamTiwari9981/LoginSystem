using System;
using System.Collections.Generic;

namespace LoginSystemAPI.Models
{
    public partial class TblUser
    {
        public int UsrId { get; set; }
        public string UsrNam { get; set; } = null!;
        public string UsrPwd { get; set; } = null!;
        public string UsrMobile { get; set; } = null!;
        public string UsrEmail { get; set; } = null!;
        public string UsrType { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int? RoleId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

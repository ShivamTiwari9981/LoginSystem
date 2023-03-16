using System;
using System.Collections.Generic;

namespace LoginSystemAPI.Models
{
    public partial class TblRole
    {
        public int RoleId { get; set; }
        public string? RoleDisc { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

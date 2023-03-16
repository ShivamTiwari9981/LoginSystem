using System;
using System.Collections.Generic;

namespace LoginSystemAPI.Models
{
    public partial class TblGender
    {
        public string GenderCd { get; set; } = null!;
        public string GenderName { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace LoginSystemAPI.Models
{
    public partial class TblState
    {
        public string StateCd { get; set; } = null!;
        public string StateName { get; set; } = null!;
        public string CountryCd { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

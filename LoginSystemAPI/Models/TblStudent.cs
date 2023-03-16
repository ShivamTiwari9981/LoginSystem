using System;
using System.Collections.Generic;

namespace LoginSystemAPI.Models
{
    public partial class TblStudent
    {
        public int StudentId { get; set; }
        public string StudentFirstNam { get; set; } = null!;
        public string StudentLastNam { get; set; } = null!;
        public string? StudentEmail { get; set; }
        public string StudentMobile { get; set; } = null!;
        public string GenderCd { get; set; } = null!;
        public string CountryCd { get; set; } = null!;
        public string StateCd { get; set; } = null!;
        public string CityCd { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

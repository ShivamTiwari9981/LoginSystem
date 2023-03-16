using System;
using System.Collections.Generic;

namespace LoginSystemAPI.Models
{
    public partial class TblCity
    {
        public string CityCd { get; set; } = null!;
        public string CityName { get; set; } = null!;
        public string StateCd { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

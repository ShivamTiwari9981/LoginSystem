using System;
using System.Collections.Generic;

namespace LoginSystemAPI.Models
{
    public partial class TblCountry
    {
        public string CountryCd { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
